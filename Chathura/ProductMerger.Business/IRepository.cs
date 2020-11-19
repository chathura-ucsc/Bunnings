using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMerger.Business
{
    public interface IRepository
    {
        /// <summary>
        ///  This will give all the items in the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> GetAll<T>();

        /// <summary>
        ///  This will update/save the given list of objects in a file with time-stamp.
        ///  File name will be the classname with a time stamp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        void Update<T>(List<T> data);
    }
}
