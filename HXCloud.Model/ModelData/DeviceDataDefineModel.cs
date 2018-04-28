using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class DeviceDataDefineModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string DataKey { get; set; }//数据标示
        public string DataName { get; set; }//数据名称
        public string Unit { get; set; }//单位
        public string DataType { get; set; }//数据类型
        public string DefaultValue { get; set; }//默认值

        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }

        public int PanelId { get; set; }
        public virtual DevicePanelModel DevicePanel { get; set; }

        public virtual ICollection<DeviceControlDataModel> DeviceControl { get; set; }
    }
}
