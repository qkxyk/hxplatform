using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceBaseDataViewModel : ResponseBase
    {
        public int Id { get; set; }
        public string DataName { get; set; }
        public string DataType { get; set; }
        public string DataValue { get; set; }
        
        public string DeviceSn { get; set; }
        public string Token { get; set; }

        public int PanelId { get; set; }
    }
}
