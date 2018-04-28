using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DevicePanelListViewModel:ResponseBase
    {
        public DevicePanelListViewModel()
        {
            list = new List<DevicePanelViewModel>();
        }
        public List<DevicePanelViewModel> list { get; set; }
    }
}
