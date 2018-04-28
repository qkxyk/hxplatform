using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class DeviceOnlineModelMap : EntityTypeConfiguration<DeviceOnlineModel>
    {
        public DeviceOnlineModelMap()
        {
            
            ToTable("DeviceOnline").HasKey(a => a.DeviceSn);
           // this.Property(a => a.DeviceId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            //1对1关系
            //HasRequired(b => b.Device).WithRequiredDependent(a => a.DeviceOnline).WillCascadeOnDelete(false);
        //.WithMany()
        //.HasForeignKey(b => b.DeviceId);

            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.DeviceOnline).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
            
        }
    }
}
