using System;

namespace ProductMerger.Business
{
    public class Supplier
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CompanyId { get; private set; }

        private Supplier(int id,
            string name,
            int companyId)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;

            Validate();
        }

        private void Validate()
        {
            if (Id < 1)
            {
                throw new Exception("Invalid id for the supplier.");
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception("SKU of the Product cannot be null, empty or white-space.");
            }

            if (CompanyId < 1)
            {
                throw new Exception("Invalid company id for the supplier.");
            }
        }

        public static Supplier Create(int id,
            string name,
            int companyId)
        {
            return new Supplier(id,
                name,
                companyId);
        }
    }
}
