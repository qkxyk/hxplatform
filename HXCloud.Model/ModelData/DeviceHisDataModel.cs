using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class DeviceHisDataModel:IAggregateRoot
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; } = DateTime.Now;
        public string DataContent { get; set; }//数据包内容
        public string DataTitle { get; set; }//数据包主题

        public string Token { get; set; }//标示数据属于那个组织
        public virtual GroupModel Group { get; set; }

        public string DeviceSn { get; set; }//设备序列号//设备标示，用来表示设备数据那个设备
        public virtual DeviceModel Device { get; set; }

    }
}
