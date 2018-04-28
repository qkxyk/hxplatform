using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DevicePanelTypeListViewModel : ResponseBase
    {
        public DevicePanelTypeListViewModel()
        {
            list = new List<DevicePanelTypeViewModel>();
        }
        public List<DevicePanelTypeViewModel> list { get; set; }
    }
}
