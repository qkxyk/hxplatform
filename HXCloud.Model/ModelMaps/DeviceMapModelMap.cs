using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
   public class DeviceMapModelMap:EntityTypeConfiguration<DeviceMapModel>
    {
        public DeviceMapModelMap()
        {
            ToTable("DeviceMap").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.Device).WithMany(a => a.DeviceMap).HasForeignKey(a => a.DeviceSn);
            HasRequired(a => a.DevicePanel).WithMany(a => a.DeviceMap).HasForeignKey(a => a.PanelId);
        }
    }
}
