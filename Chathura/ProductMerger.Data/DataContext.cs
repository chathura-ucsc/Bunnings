using System;
using ProductMerger.Business;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace ProductMerger.Data
{
    internal class DataContext
    {
        internal static List<Company> Companies { get; set; }
        internal static List<Product> Products { get; set; }
        internal static List<Supplier> Suppliers { get; set; }
        internal static List<SupplierProductBarcode> SupplierProductBarcodes { get; set; }

        static DataContext()
        {
            LoadFromCsv();
        }

        private static void LoadFromCsv()
        {
            Companies = new List<Company>
            {
                Company.Create(Constants.CompanyAId, Constants.CompanyAName),
                Company.Create(Constants.CompanyBId, Constants.CompanyBName)
            };

            Products = File.ReadLines("..\\..\\..\\..\\input\\catalogA.csv").Skip(1).Select(line =>
                Product.Create(line.Split(',')[0], line.Split(',')[1], Constants.CompanyAId)).ToList();
            Products.AddRange(File.ReadLines("..\\..\\..\\..\\input\\catalogB.csv").Skip(1).Select(line =>
                Product.Create(line.Split(',')[0], line.Split(',')[1], Constants.CompanyBId)).ToList());

            Suppliers = File.ReadLines("..\\..\\..\\..\\input\\suppliersA.csv").Skip(1).Select(line =>
                Supplier.Create(int.Parse(line.Split(',')[0]), line.Split(',')[1], Constants.CompanyAId)).ToList();
            Suppliers.AddRange(File.ReadLines("..\\..\\..\\..\\input\\suppliersB.csv").Skip(1).Select(line =>
                Supplier.Create(int.Parse(line.Split(',')[0]), line.Split(',')[1], Constants.CompanyBId)).ToList());

            SupplierProductBarcodes = File.ReadLines("..\\..\\..\\..\\input\\barcodesA.csv").Skip(1).Select(line =>
                SupplierProductBarcode.Create(int.Parse(line.Split(',')[0]), line.Split(',')[1], line.Split(',')[2], Constants.CompanyAId)).ToList();
            SupplierProductBarcodes.AddRange(File.ReadLines("..\\..\\..\\..\\input\\barcodesB.csv").Skip(1).Select(line =>
                SupplierProductBarcode.Create(int.Parse(line.Split(',')[0]), line.Split(',')[1], line.Split(',')[2], Constants.CompanyBId)).ToList());
        }

        internal static int SaveChanges<T>(List<T> data)
        {
            var lines = new List<string>();

            var props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();

            var header = string.Join(",", props.ToList().Select(x => x.Name));

            lines.Add(header); //set the header using property names

            var values = data.Select(value => string.Join(",", header.Split(',')
                .Select(a => value?.GetType().GetProperty(a)?.GetValue(value, null))));

            lines.AddRange(values); // add the values

            File.WriteAllLines($"..\\..\\..\\..\\output\\merged_products_{DateTime.Now.Ticks}.csv", lines.ToArray());

            return 0;
        }

        internal static List<T> GetAllItems<T>()
        {
            if (typeof(Company) == typeof(T))
                return Companies.Cast<T>().ToList();

            if (typeof(Product) == typeof(T))
                return Products.Cast<T>().ToList();

            if (typeof(Supplier) == typeof(T))
                return Suppliers.Cast<T>().ToList();

            if (typeof(SupplierProductBarcode) == typeof(T))
                return SupplierProductBarcodes.Cast<T>().ToList();

            return null;
        }
    }
}

