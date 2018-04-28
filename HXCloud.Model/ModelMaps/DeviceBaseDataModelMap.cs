using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class DeviceBaseDataModelMap : EntityTypeConfiguration<DeviceBaseDataModel>
    {
        public DeviceBaseDataModelMap()
        {
            ToTable("DeviceBaseData").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.DevicePanel).WithMany(a => a.DeviceBaseData).HasForeignKey(a => a.PanelId);
            HasRequired(a => a.Device).WithMany(a => a.DeviceBaseData).HasForeignKey(a => a.DeviceSn);
        }
    }
}
