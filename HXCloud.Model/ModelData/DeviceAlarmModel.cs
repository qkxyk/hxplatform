using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class DeviceAlarmModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string AlarmTitle { get; set; }
        public string AlarmDesc { get; set; }//报警描述

        public DateTime Dt { get; set; } = DateTime.Now;//报警发生时间

        public string Handler { get; set; }//报警处理人
        public string Comment { get; set; }//报警处理意见
        public Nullable<DateTime> HandleDt { get; set; }//报警处理时间

        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }
        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }
    }
}
