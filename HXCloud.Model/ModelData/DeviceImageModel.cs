using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //设备图片
   public class DeviceImageModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string url { get; set; }

        public string DeviceSn { get; set; }//设备序列号
        public virtual DeviceModel Device { get; set; }

        public int PanelId { get; set; }
        public virtual DevicePanelModel DevicePanel { get; set; }
    }
}
