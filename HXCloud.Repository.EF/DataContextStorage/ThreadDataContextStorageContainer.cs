using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace HXCloud.Repository.EF.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable _hxDataContext = new Hashtable();
        public HXContext GetDataContext()
        {
            HXContext hxContext = null;
            if (_hxDataContext.Contains(GetThreadName()))
            {
                hxContext = (HXContext)_hxDataContext[GetThreadName()];
            }
            return hxContext;
        }

        public void Store(HXContext hxContext)
        {
            if (_hxDataContext.Contains(GetThreadName()))
            {
                _hxDataContext[GetThreadName()] = hxContext;
            }
            else
            {
                _hxDataContext.Add(GetThreadName(), hxContext);
            }
        }
        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
