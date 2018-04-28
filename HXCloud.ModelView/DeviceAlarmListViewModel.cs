using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceAlarmListViewModel : ResponseBase
    {
        public DeviceAlarmListViewModel()
        {
            list = new List<DeviceAlarmViewModel>();
        }
        public List<DeviceAlarmViewModel> list { get; set; }
    }
}
