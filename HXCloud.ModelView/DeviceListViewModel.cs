using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceListViewModel : ResponseBase
    {
        public DeviceListViewModel()
        {
            list = new List<DeviceViewModel>();
        }
        public List<DeviceViewModel> list { get; set; }
    }
}
