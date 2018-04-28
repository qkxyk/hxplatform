using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceVideoListViewModel:ResponseBase
    {
        public DeviceVideoListViewModel()
        {
            list = new List<DeviceVideoViewModel>();
        }
        public List<DeviceVideoViewModel> list { get; set; }
    }
}
