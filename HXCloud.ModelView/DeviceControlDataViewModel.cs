using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceControlDataViewModel:ResponseBase
    {
        public string DeviceSn { get; set; }
        public string Token { get; set; }
        public int Id { get; set; }
        public string ControlName { get; set; }
        public string DataValue { get; set; }//设备设置值
        
        public int PanelId { get; set; }

        public int DataDefineId { get; set; }//对应设备数据栏位编号（和设备栏位对应关系为1：N）
    }
}
