using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class DeviceAlarmModelMap : EntityTypeConfiguration<DeviceAlarmModel>
    {
        public DeviceAlarmModelMap()
        {
            ToTable("DeviceAlarm").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.Device).WithMany(a => a.DeviceAlarm).HasForeignKey(a => a.DeviceSn).WillCascadeOnDelete(false);
            HasRequired(a => a.Group).WithMany(a => a.DeviceAlarm).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
        }
    }
}
