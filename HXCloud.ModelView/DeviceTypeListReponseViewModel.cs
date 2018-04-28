using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceTypeListReponseViewModel : ResponseBase
    {
        public DeviceTypeListReponseViewModel()
        {
            List = new List<DeviceTypeViewModel>();
        }
        public List<DeviceTypeViewModel> List { get; set; }
    }
}
