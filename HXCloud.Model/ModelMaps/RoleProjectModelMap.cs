using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class RoleProjectModelMap : EntityTypeConfiguration<RoleProjectModel>
    {
        public RoleProjectModelMap()
        {
            ToTable("RoleProject").HasKey(a => new { a.ProjectId, a.RoleId });

            //1对多关系
            HasRequired(a => a.Role).WithMany(a => a.RoleProject).HasForeignKey(a => a.RoleId);
            HasRequired(a => a.Project).WithMany(a => a.RoleProject).HasForeignKey(a => a.ProjectId);
        }
    }
}
