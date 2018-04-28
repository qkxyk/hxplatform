using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
  public  class DeviceDataDefineModelMap:EntityTypeConfiguration<DeviceDataDefineModel>
    {
        public DeviceDataDefineModelMap()
        {
            ToTable("DeviceDataDefine");
            //1对多关系
            HasRequired(a => a.Device).WithMany(a => a.DeviceDataDefine).HasForeignKey(a => a.DeviceSn).WillCascadeOnDelete(false);
            HasRequired(a => a.DevicePanel).WithMany(a => a.DeviceDataDefine).HasForeignKey(a => a.PanelId).WillCascadeOnDelete(false);
        }
    }
}
