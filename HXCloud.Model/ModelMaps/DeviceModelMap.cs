using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class DeviceModelMap : EntityTypeConfiguration<DeviceModel>
    {
        public DeviceModelMap()
        {
            ToTable("Device").HasKey(a => a.DeviceSn);
            // this.Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //1对1关系
            HasOptional(u => u.DeviceOnline).WithRequired(ux => ux.Device);


            //HasRequired(a => a.DeviceOnline).WithRequiredPrincipal(a => a.Device);

            //  HasOptional(s => s.DeviceOnline).WithRequired(a => a.Device); // Mark Address property optional in Student entity
            //WithRequired(ad => ad.DeviceId); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.Device).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
            HasOptional(a => a.Project).WithMany(a => a.Device).HasForeignKey(a => a.ProjectId).WillCascadeOnDelete(false);
            //HasRequired(a => a.Project).WithMany(a => a.Device).HasForeignKey(a => a.ProjectId).WillCascadeOnDelete(false);
            HasRequired(a => a.DeviceType).WithMany(a => a.Device).HasForeignKey(a => a.TypeId).WillCascadeOnDelete(false);
        }
    }
}
