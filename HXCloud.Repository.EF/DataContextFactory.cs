using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Repository.EF.DataContextStorage;

namespace HXCloud.Repository.EF
{
   public class DataContextFactory
    {
        public static HXContext GetDataContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();
            HXContext hxContext = _dataContextStorageContainer.GetDataContext();
            if (hxContext==null)
            {
                hxContext = new HXContext();
            }
            else
            {
                hxContext = new HXContext();
                _dataContextStorageContainer.Store(hxContext);
            }
            return hxContext;
        }
    }
}
