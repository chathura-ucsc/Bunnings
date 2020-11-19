using System.Collections.Generic;
using System.Linq;

namespace ProductMerger.Business
{
    public class MergeProductsBusinessService
    {
        private readonly List<Product> _products;
        private readonly List<SupplierProductBarcode> _supplierProductBarcodes;

        public MergeProductsBusinessService(List<Product> products,
            List<SupplierProductBarcode> supplierProductBarcodes)
        {
            _products = products;
            _supplierProductBarcodes = supplierProductBarcodes;
        }

        public List<MergedProduct> MergeProducts()
        {

            var barCodesFromCompanyA = _supplierProductBarcodes
                .Where(s => s.CompanyId == Constants.CompanyAId)
                .ToList();

            var barCodesFromCompanyB = _supplierProductBarcodes
                .Where(s => s.CompanyId == Constants.CompanyBId)
                .ToList();

            var productsFromCompanyB = _products.Where(s => s.CompanyId == Constants.CompanyBId).ToList();

            foreach (var barCodeFromA in barCodesFromCompanyA)
            {
                var similarProductInB = barCodesFromCompanyB.SingleOrDefault(s => s.Barcode == barCodeFromA.Barcode);

                if (similarProductInB != null) // if the same product is found from company b, that product has to be removed from the list
                {
                    productsFromCompanyB.RemoveAll(s => s.SKU == similarProductInB.SKU);
                }
            }

            var finalProductList = _products.Where(s => s.CompanyId == Constants.CompanyAId).ToList();

            finalProductList.AddRange(productsFromCompanyB);

            return finalProductList
                .Select(s => MergedProduct.Create(s.SKU, s.Description, s.CompanyId))
                .ToList();
        }
    }
}
