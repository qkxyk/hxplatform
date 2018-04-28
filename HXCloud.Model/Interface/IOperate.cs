using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public interface IOperate : IBase<OperateModel>
    {
        IEnumerable<OperateModel> FindBy();
    }
}
