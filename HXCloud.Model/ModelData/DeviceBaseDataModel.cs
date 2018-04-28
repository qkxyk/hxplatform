using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //设备基础数据
    public class DeviceBaseDataModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string DataName { get; set; }
        public string DataType { get; set; }
        public string DataValue { get; set; }

        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }

        public int PanelId { get; set; }
        public virtual DevicePanelModel DevicePanel { get; set; }
    }
}
