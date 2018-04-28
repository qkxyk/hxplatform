using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class DevicePanelModelMap : EntityTypeConfiguration<DevicePanelModel>
    {
        public DevicePanelModelMap()
        {
            ToTable("DevicePanel").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.Device).WithMany(a => a.DevicePanel).HasForeignKey(a => a.DeviceSn).WillCascadeOnDelete(false);

            HasOptional(a => a.DevicePanelType).WithMany(a => a.DevicePanel).HasForeignKey(a => a.TypeId);
        }
    }
}
