using System;

namespace ProductMerger.Business
{
    public class SupplierProductBarcode
    {
        public int SupplierId { get; private set; }
        public string SKU { get; private set; }
        public string Barcode { get; private set; }
        public int CompanyId { get; private set; }

        private SupplierProductBarcode(int supplierId,
            string sku,
            string barcode,
            int companyId)
        {
            SupplierId = supplierId;
            SKU = sku;
            Barcode = barcode;
            CompanyId = companyId;

            Validate();
        }

        private void Validate()
        {
            if (SupplierId < 1)
            {
                throw new Exception("Invalid supplier id provided for barcode.");
            }

            if (string.IsNullOrWhiteSpace(SKU))
            {
                throw new Exception("SKU cannot be null, empty or white-space for barcode.");
            }

            if (string.IsNullOrWhiteSpace(Barcode))
            {
                throw new Exception("Barcode cannot be null, empty or white-space.");
            }

            if (CompanyId < 1)
            {
                throw new Exception("Invalid company id for barcode.");
            }
        }

        public static SupplierProductBarcode Create(int supplierId,
            string sku,
            string barcode,
            int companyId)
        {
            return new SupplierProductBarcode(supplierId,
                sku,
                barcode,
                companyId);
        }
    }
}
