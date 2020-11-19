using System;

namespace ProductMerger.Business
{
    public class MergedProduct
    {
        public string SKU { get; private set; }
        public string Description { get; private set; }
        public int CompanyId { get; private set; }
        public string CompanyName { get; private set; }

        private MergedProduct(string sku,
            string description,
            int companyId)
        {
            SKU = sku;
            Description = description;
            CompanyId = companyId;

            switch (companyId)
            {
                case Constants.CompanyAId:
                    CompanyName = Constants.CompanyAName;
                    break;
                case Constants.CompanyBId:
                    CompanyName = Constants.CompanyBName;
                    break;
                default:
                    break;
            }

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(SKU))
            {
                throw new Exception("SKU of the Merged Product cannot be null, empty or white-space.");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new Exception("Description of the Merged Product cannot be null, empty or white-space.");
            }

            if (string.IsNullOrWhiteSpace(CompanyName))
            {
                throw new Exception("Invalid company name for the merged product.");
            }
        }

        public static MergedProduct Create(string sku,
            string description,
            int companyId)
        {
            return new MergedProduct(sku,
                description,
                companyId);
        }
    }
}
