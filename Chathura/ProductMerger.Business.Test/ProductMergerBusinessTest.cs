using System;
using Xunit;

namespace ProductMerger.Business.Test
{
    public class ProductMergerBusinessTest
    {    
        [Fact]
        public void TestProductMerge()
        {
            var merger = new MergeProductsBusinessService(Bootstrap.Products,
                Bootstrap.SupplierProductBarcodes);

            var result = merger.MergeProducts();

            Assert.Equal(8, result.Count);
        }
    }
}
