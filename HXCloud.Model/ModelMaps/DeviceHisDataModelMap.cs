using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
   public class DeviceHisDataModelMap:EntityTypeConfiguration<DeviceHisDataModel>
    {
        public DeviceHisDataModelMap()
        {
            ToTable("DeviceHisData").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.DeviceHisData).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
            HasRequired(a => a.Device).WithMany(a => a.DeviceHisData).HasForeignKey(a => a.DeviceSn).WillCascadeOnDelete(false);
        }
    }
}
