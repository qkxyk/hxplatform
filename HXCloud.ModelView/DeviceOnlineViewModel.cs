using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DeviceOnlineViewModel : ResponseBase
    {
        public string DeviceSn { get; set; }
        public string Token { get; set; }
        
        //public int Id { get; set; }
        public DateTime dt { get; set; } = DateTime.Now;//设备上次在线时间
        public string DataContent { get; set; }
        public string DataTitle { get; set; }
        public int TypeId { get; set; }//设备的类型，便于分类统计
    }
}
