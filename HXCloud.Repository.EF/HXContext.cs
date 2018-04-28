using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HXCloud.Model;
using HXCloud.Model.ModelMaps;

namespace HXCloud.Repository.EF
{
    public class HXContext : DbContext
    {
        public HXContext() : base("HXContext")
        {

        }
        public DbSet<UserModel> User { get; set; }
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<GroupModel> Group { get; set; }
        public DbSet<UserRoleModel> UserRole { get; set; }
        public DbSet<RoleProjectModel> RoleProject { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<ProjectAffiliateModel> ProjectAffiliate { get; set; }
        public DbSet<OperateModel> Operate { get; set; }
        public DbSet<SysMenuModel> SysMenu { get; set; }
        public DbSet<RoleSysMenuModel> RoleSysMenu { get; set; }


        public DbSet<DeviceOnlineModel> DeviceOnline { get; set; }
        public DbSet<DeviceAlarmModel> DeviceAlarm { get; set; }
        public DbSet<DeviceHisDataModel> DeviceHisData { get; set; }
        public DbSet<DeviceDataDefineModel> DeviceDataDefine { get; set; }
        public DbSet<DeviceModel> Device { get; set; }
        public DbSet<DevicePanelModel> DevicePanel { get; set; }
        public DbSet<DeviceBaseDataModel> DeviceBaseData { get; set; }
        public DbSet<DeviceImageModel> DeviceImage { get; set; }
        public DbSet<DeviceMapModel> DeviceMap { get; set; }
        public DbSet<DeviceControlDataModel> DeviceControlData { get; set; }
        public DbSet<DeviceVideoModel> DeviceVideo { get; set; }
        public DbSet<DeviceTypeModel> DeviceType { get; set; }
        public DbSet<DevicePanelTypeModel> DevicePanelType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroupModelMap());
            modelBuilder.Configurations.Add(new UserModelMap());
            modelBuilder.Configurations.Add(new RoleModelMap());
            modelBuilder.Configurations.Add(new UserRoleModelMap());
            modelBuilder.Configurations.Add(new ClientModelMap());
            modelBuilder.Configurations.Add(new ProjectModelMap());
            modelBuilder.Configurations.Add(new RoleProjectModelMap());
            modelBuilder.Configurations.Add(new ProjectAffiliateModelMap());
            modelBuilder.Configurations.Add(new OperateModelMap());
            modelBuilder.Configurations.Add(new SysMenuModelMap());
            modelBuilder.Configurations.Add(new RoleSysMenuModelMap());

            modelBuilder.Configurations.Add(new DeviceModelMap());
            modelBuilder.Configurations.Add(new DevicePanelModelMap());
            modelBuilder.Configurations.Add(new DeviceOnlineModelMap());
            modelBuilder.Configurations.Add(new DeviceAlarmModelMap());
            modelBuilder.Configurations.Add(new DeviceHisDataModelMap());
            modelBuilder.Configurations.Add(new DeviceBaseDataModelMap());
            modelBuilder.Configurations.Add(new DeviceImageModelMap());
            modelBuilder.Configurations.Add(new DeviceDataDefineModelMap());
            modelBuilder.Configurations.Add(new DeviceMapModelMap());
            modelBuilder.Configurations.Add(new DeviceControlDataModelMap());
            modelBuilder.Configurations.Add(new DeviceVideoModelMap());
            modelBuilder.Configurations.Add(new DeviceTypeModelMap());
            modelBuilder.Configurations.Add(new DevicePanelTypeModelMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
