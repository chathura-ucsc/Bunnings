using System;

namespace ProductMerger.Business
{
    public class Product
    {
        public string SKU { get; private set; }
        public string Description { get; private set; }
        public int CompanyId { get; private set; }

        private Product(string sku, 
            string description, 
            int companyId)
        {
            SKU = sku;
            Description = description;
            CompanyId = companyId;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(SKU))
            {
                throw new Exception("SKU of the Product cannot be null, empty or white-space.");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new Exception("Description of the Product cannot be null, empty or white-space.");
            }

            if (CompanyId < 1)
            {
                throw new Exception("Invalid company id for the product.");
            }
        }

        public static Product Create(string sku,
            string description,
            int companyId)
        {
            return new Product(sku,
                description,
                companyId);
        }
    }
}
