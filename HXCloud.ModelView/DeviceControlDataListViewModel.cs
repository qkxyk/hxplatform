using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceControlDataListViewModel : ResponseBase
    {
        public DeviceControlDataListViewModel()
        {
            list = new List<DeviceControlDataViewModel>();
        }
        public List<DeviceControlDataViewModel> list { get; set; }
    }
}
