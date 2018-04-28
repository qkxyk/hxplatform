using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceImageListViewModel:ResponseBase
    {
        public DeviceImageListViewModel()
        {
            list = new List<DeviceImageViewModel>();
        }
        public List<DeviceImageViewModel> list { get; set; }
    }
}
