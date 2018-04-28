using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //设备在线状态表，和设备表一一对应
    public class DeviceOnlineModel:IAggregateRoot
    {        
        public string DeviceSn { get; set; }
        public DateTime dt { get; set; } = DateTime.Now;//设备上次在线时间
        public string DataContent { get; set; }
        public string DataTitle { get; set; }

        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }

        public virtual DeviceModel Device { get; set; }
        
    }
}
