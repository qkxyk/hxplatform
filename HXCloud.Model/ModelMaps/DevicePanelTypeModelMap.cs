using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class DevicePanelTypeModelMap:EntityTypeConfiguration<DevicePanelTypeModel>
    {
        public DevicePanelTypeModelMap()
        {
            this.ToTable("DevicePanelType").HasKey(a => a.Id);

            HasRequired(a => a.Group).WithMany(a => a.DevicePanelType).HasForeignKey(a => a.Token);
        }
    }
}
