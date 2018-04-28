using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
  public  class DeviceAlarmViewModel:ResponseBase
    {
        public string DeviceSn { get; set; }
        public string Token { get; set; }
        
        public string AlarmTitle { get; set; }
        public string AlarmDesc { get; set; }//报警描述

        public DateTime Dt { get; set; } = DateTime.Now;//报警发生时间

        public string Handler { get; set; }//报警处理人
        public string Comment { get; set; }//报警处理意见
        public Nullable<DateTime> HandleDt { get; set; }//报警处理时间

        public int TypeId { get; set; }//设备类型
        
    }
}
