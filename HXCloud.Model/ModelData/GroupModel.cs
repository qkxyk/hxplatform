using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //组织表
    public class GroupModel : IAggregateRoot
    {
        public string Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }

        //需要关联其他的数据
        public virtual ICollection<UserModel> User { get; set; }
        public virtual ICollection<RoleModel> Role { get; set; }
        public virtual ICollection<ProjectModel> Project { get; set; }
        public virtual ICollection<ClientModel> Client { get; set; }
        public virtual ICollection<SysMenuModel> SysMenu { get; set; }

        public virtual ICollection<DeviceModel> Device { get; set; }
        public virtual ICollection<DeviceOnlineModel> DeviceOnline { get; set; }
        public virtual ICollection<DeviceHisDataModel> DeviceHisData { get; set; }
        public virtual ICollection<DeviceAlarmModel> DeviceAlarm { get; set; }
        public virtual ICollection<DeviceTypeModel> DeviceType { get; set; }
        public virtual ICollection<DevicePanelTypeModel> DevicePanelType { get; set; }

    }
}
