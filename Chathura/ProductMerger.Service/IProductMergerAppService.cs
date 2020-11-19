namespace ProductMerger.Service
{
    public interface IProductMergerAppService
    {
        /// <summary>
        ///  This will merge products of the given parent company and child company,
        /// if the given product exist in both companies,
        /// it will give the precedence to the parent company
        /// and eliminate any duplicates, the out put will be stored in a file with a time stamp
        /// </summary>
        /// <param name="parentCompanyId"></param>
        /// <param name="childCompanyId"></param>
        void MergeProducts(int parentCompanyId, int childCompanyId);
    }
}
