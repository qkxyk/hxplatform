using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //数据面板(数据归类)
    public class DevicePanelModel : IAggregateRoot
    {
        public int Id { get; set; }
        public string PanelName { get; set; }

        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }

        public int? TypeId { get; set; }
        public virtual DevicePanelTypeModel DevicePanelType { get; set; }

        public virtual ICollection<DeviceDataDefineModel> DeviceDataDefine { get; set; }
        public virtual ICollection<DeviceMapModel> DeviceMap { get; set; }
        public virtual ICollection<DeviceControlDataModel> DeviceControlData { get; set; }
        public virtual ICollection<DeviceVideoModel> DeviceVideo { get; set; }
        public virtual ICollection<DeviceImageModel> DeviceImage { get; set; }
        public virtual ICollection<DeviceBaseDataModel> DeviceBaseData { get; set; }
    }
}
