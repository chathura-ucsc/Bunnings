using ProductMerger.Business;
using System.Collections.Generic;

namespace ProductMerger.Data
{
    public class Repository : IRepository
    {
        public Repository()
        {
        }

        public List<T> GetAll<T>() => DataContext.GetAllItems<T>();

        public void Update<T>(List<T> data) 
        {
            DataContext.SaveChanges(data);
        }
    }
}
