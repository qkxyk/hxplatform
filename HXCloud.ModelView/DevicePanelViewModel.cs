using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DevicePanelViewModel : ResponseBase
    {
        public int Id { get; set; }
        public string PanelName { get; set; }
        public int TypeId { get; set; }

        public string Token { get; set; }
        public string DeviceSn { get; set; }
    }
}
