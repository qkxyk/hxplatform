using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class DeviceControlDataModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string ControlName { get; set; }
        public string DataValue { get; set; }//设备设置值

        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }

        public int PanelId { get; set; }
        public virtual DevicePanelModel DevicePanel { get; set; }

        public int DataDefineId { get; set; }//对应设备数据栏位编号（和设备栏位对应关系为1：N）
        public virtual DeviceDataDefineModel DeviceDataDefine { get; set; }
    }
}
