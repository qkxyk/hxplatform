using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
   public class DeviceImageModelMap:EntityTypeConfiguration<DeviceImageModel>
    {
        public DeviceImageModelMap()
        {
            ToTable("DeviceImage").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.Device).WithMany(a => a.DeviceImage).HasForeignKey(a => a.DeviceSn);
            HasRequired(a => a.DevicePanel).WithMany(a => a.DeviceImage).HasForeignKey(a => a.PanelId);
        }
    }
}
