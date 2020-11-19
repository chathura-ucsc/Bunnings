using System.Collections.Generic;

namespace ProductMerger.Business.Test
{
    internal static class Bootstrap
    {
        internal static List<Company> Companies { get; set; }
        internal static List<Product> Products { get; set; }
        internal static List<Supplier> Suppliers { get; set; }
        internal static List<SupplierProductBarcode> SupplierProductBarcodes { get; set; }

        static Bootstrap()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Companies = new List<Company>
            {
                Company.Create(Constants.CompanyAId, Constants.CompanyAName),
                Company.Create(Constants.CompanyBId, Constants.CompanyBName)
            };

            Products = new List<Product>()
            {
                Product.Create("sku1","test sku1", Constants.CompanyAId),
                Product.Create("sku2","test sku1", Constants.CompanyAId),
                Product.Create("sku3","test sku1", Constants.CompanyAId),
                Product.Create("sku4","test sku1", Constants.CompanyAId),
                Product.Create("sku5","test sku1", Constants.CompanyBId),
                Product.Create("sku1","test sku1", Constants.CompanyBId),
                Product.Create("sku2","test sku1", Constants.CompanyBId),
                Product.Create("sku3","test sku1", Constants.CompanyBId),
                Product.Create("sku4","test sku1", Constants.CompanyBId),
                Product.Create("sku6","test sku1", Constants.CompanyBId),
            };

            Suppliers = new List<Supplier>()
            {
                Supplier.Create(1, "test 1", Constants.CompanyAId),
                Supplier.Create(2, "test 1", Constants.CompanyAId),
                Supplier.Create(3, "test 1", Constants.CompanyAId),
                Supplier.Create(4, "test 1", Constants.CompanyAId),
                Supplier.Create(1, "test 1", Constants.CompanyBId),
                Supplier.Create(2, "test 1", Constants.CompanyBId),
                Supplier.Create(3, "test 1", Constants.CompanyBId),
                Supplier.Create(4, "test 1", Constants.CompanyBId),
                Supplier.Create(5, "test 1", Constants.CompanyBId),
            };

            SupplierProductBarcodes = new List<SupplierProductBarcode>()
            {
                SupplierProductBarcode.Create(1, "sku1", "abc1", Constants.CompanyAId),
                SupplierProductBarcode.Create(2, "sku2", "abc2", Constants.CompanyAId),
                SupplierProductBarcode.Create(3, "sku1", "abc3", Constants.CompanyAId),
                SupplierProductBarcode.Create(4, "sku1", "abc4", Constants.CompanyAId),
                SupplierProductBarcode.Create(1, "sku3", "abc5", Constants.CompanyAId),
                SupplierProductBarcode.Create(1, "sku4", "abc6", Constants.CompanyAId),
                SupplierProductBarcode.Create(1, "sku1", "abc1", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku2", "abc2", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku3", "abc33", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku4", "abc44", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku5", "abc55", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku6", "abc66", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku6", "abc77", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku1", "abc111", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku1", "abc12343", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku1", "abc90", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku6", "abcsadff", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku5", "qaqawrf", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku3", "qwrqwerdsrt", Constants.CompanyBId),
                SupplierProductBarcode.Create(1, "sku1", "abc12431234324", Constants.CompanyBId)
            };
        }
    }
}
