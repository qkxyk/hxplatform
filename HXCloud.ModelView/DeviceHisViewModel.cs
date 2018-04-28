using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceHisViewModel:ResponseBase
    {
        public string DeviceSn { get; set; }
        public string Token { get; set; }

        public int Id { get; set; }
        public DateTime Dt { get; set; } = DateTime.Now;
        public string DataContent { get; set; }//数据包内容
        public string DataTitle { get; set; }//数据包主题       
        
    }
}
