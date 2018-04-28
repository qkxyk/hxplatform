using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceOnlineListViewModel : ResponseBase
    {
        public DeviceOnlineListViewModel()
        {
            list = new List<DeviceOnlineViewModel>();
        }
        public List<DeviceOnlineViewModel> list { get; set; }
    }
}
