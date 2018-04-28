using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceViewModel : ResponseBase
    {
        public string DeviceSn { get; set; }//设备序列号
        public string DeviceNo { get; set; }//设备编号
        public string DeviceName { get; set; }//设备名称
        public DateTime ProductTime { get; set; } = DateTime.Now;//生产日期
        public DateTime UseTime { get; set; } = DateTime.Now;//投入使用日期      
        public string DeviceDescription { get; set; }//设备描述
                                                     //public int Primary { get; set; }//设备是否主站，1为主站，其他为从站

        public string Position { get; set; }//设备的位置信息

        public string Token { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public int TypeId { get; set; }//设备类型
    }
}
