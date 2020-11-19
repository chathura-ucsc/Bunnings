using System;

namespace ProductMerger.Business
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Company(int id, string name)
        {
            Id = id;
            Name = name;

            Validate();
        }

        private void Validate()
        {
            if (Id < 1)
            {
                throw new Exception("Invalid id provided for the company.");
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception("Company name cannot be null, empty or white-space.");
            }
        }

        public static Company Create(int id, string name)
        {
            return new Company(id, name);
        }
    }
}
