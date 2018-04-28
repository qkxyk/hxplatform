using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HXCloud.Repository.EF.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private string _dataContextKey = "DataContext";
        public HXContext GetDataContext()
        {
            HXContext objectContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                objectContext = (HXContext)HttpContext.Current.Items[_dataContextKey];
            return objectContext;
        }

        public void Store(HXContext hxContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                HttpContext.Current.Items[_dataContextKey] = hxContext;
            }
            else
            {
                HttpContext.Current.Items.Add(_dataContextKey, hxContext);
            }
        }
    }
}
