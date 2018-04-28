using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
  public  class DeviceTypeModelMap:EntityTypeConfiguration<DeviceTypeModel>
    {
        public DeviceTypeModelMap()
        {
            ToTable("DeviceType").HasKey(a => a.Id);

            //一对多自反关系
           // HasRequired(a => a.Parent).WithMany(a => a.Child).HasForeignKey(a => a.ParentId).WillCascadeOnDelete(false);
            HasOptional(a => a.Parent).WithMany(a => a.Child).HasForeignKey(a => a.ParentId);
            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.DeviceType).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
        }
    }
}
