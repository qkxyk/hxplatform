using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceMapListViewModel : ResponseBase
    {
        public DeviceMapListViewModel()
        {
            list = new List<DeviceMapViewModel>();
        }
        public List<DeviceMapViewModel> list { get; set; }
    }
}
