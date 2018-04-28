using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceDataDefineListViewModel:ResponseBase
    {
        public DeviceDataDefineListViewModel()
        {
            list = new List<DeviceDataDefineViewModel>();
        }
        public List<DeviceDataDefineViewModel> list { get; set; }
    }
}
