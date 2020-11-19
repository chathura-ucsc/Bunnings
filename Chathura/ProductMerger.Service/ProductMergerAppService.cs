using System;
using System.Linq;
using ProductMerger.Business;

namespace ProductMerger.Service
{
    public class ProductMergerAppService : IProductMergerAppService
    {
        private readonly IRepository _repository;

        public ProductMergerAppService(IRepository repository)
        {
            _repository = repository;
        }

        public void MergeProducts(int parentCompanyId, int childCompanyId)
        {
            var parentCompany = _repository.GetAll<Company>()
                .SingleOrDefault(s => s.Id == parentCompanyId);

            if (parentCompany == null)
            {
                throw new Exception("Given parent company cannot be found.");
            }

            var childCompany = _repository.GetAll<Company>()
                .SingleOrDefault(s => s.Id == childCompanyId);

            if (childCompany == null)
            {
                throw new Exception("Given child company cannot be found.");
            }

            var businessService = new MergeProductsBusinessService(_repository.GetAll<Product>(),
                _repository.GetAll<SupplierProductBarcode>());

            var mergedProducts = businessService.MergeProducts();

            _repository.Update<MergedProduct>(mergedProducts);
        }
    }
}
