using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceMapViewModel:ResponseBase
    {
        public string DeviceSn { get; set; }
        public string Token { get; set; }
        public int Id { get; set; }
        public string Position { get; set; }
        
        public int PanelId { get; set; }
    }
}
