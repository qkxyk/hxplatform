using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceImageViewModel:ResponseBase
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string url { get; set; }
        
        public string Token { get; set; }
        public string DeviceSn { get; set; }

        public int PanelId { get; set; }
    }
}
