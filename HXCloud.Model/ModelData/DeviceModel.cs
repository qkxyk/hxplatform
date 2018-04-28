using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace HXCloud.Model
{
    public class DeviceModel : IAggregateRoot
    {

        //  public int Id { get; set; }//设备标识
        public string DeviceSn { get; set; }//设备序列号
        public string DeviceName { get; set; }//设备名称
        public DateTime ProductTime { get; set; } = DateTime.Now;//生产日期
        public DateTime UseTime { get; set; } = DateTime.Now;//投入使用日期
        //添加设备功率 20180212
        //public string DevicePower { get; set; }//装机功率
        //public string DeviceRunPower { get; set; }//运行功率
        //public string DeviceAddress { get; set; }//设备地址
        public string DeviceDescription { get; set; }//设备描述

        //2018-4-16新增设备编号，原来的设备序列号改为系统自动生成，guid转换为字符串,设备编号为手动输入和设备关联，系统中可以存在不同组织相同设备编号的设备
        //设备表中新增验证权限的项目编号,设备权限验证时只需验证此编号即可。
        public string DeviceNo { get; set; }//设备编号
        public int PId { get; set; }//验证设备权限的项目编号（不用递归）
        public  string Position { get; set; }//设备的位置坐标

        //public DateTime ScrapTime { get; set; }= DateTime.Now;//报废日期
        //public int Primary { get; set; }//设备是否主站，1为主站，其他为从站

        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }
        public int TypeId { get; set; }//设备类型
        public virtual DeviceTypeModel DeviceType { get; set; }

        public virtual DeviceOnlineModel DeviceOnline { get; set; }

        public virtual ICollection<DeviceHisDataModel> DeviceHisData { get; set; }
        public virtual ICollection<DeviceAlarmModel> DeviceAlarm { get; set; }
        public virtual ICollection<DeviceBaseDataModel> DeviceBaseData { get; set; }
        public virtual ICollection<DevicePanelModel> DevicePanel { get; set; }
        public virtual ICollection<DeviceDataDefineModel> DeviceDataDefine { get; set; }
        public virtual ICollection<DeviceImageModel> DeviceImage { get; set; }
        public virtual ICollection<DeviceVideoModel> DeviceVideo { get; set; }
        public virtual ICollection<DeviceControlDataModel> DeviceControlData { get; set; }
        public virtual ICollection<DeviceMapModel> DeviceMap { get; set; }
    }
}
