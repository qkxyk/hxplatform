using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Repository.EF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        HXContext GetDataContext();
        void Store(HXContext hxContext);
    }
}
