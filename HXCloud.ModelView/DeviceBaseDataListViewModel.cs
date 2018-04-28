using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceBaseDataListViewModel:ResponseBase
    {
        public DeviceBaseDataListViewModel()
        {
            list = new List<DeviceBaseDataViewModel>();
        }
        public List<DeviceBaseDataViewModel> list { get; set; }
    }
}
