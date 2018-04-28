using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceHisListViewModel:ResponseBase
    {
        public List<DeviceHisViewModel > list { get; set; }
        public DeviceHisListViewModel()
        {
            list = new List<DeviceHisViewModel>();
        }
    }
}
