using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class RoleSysMenuModelMap : EntityTypeConfiguration<RoleSysMenuModel>
    {
        public RoleSysMenuModelMap()
        {
            ToTable("RoleSysMenu").HasKey(a => new { a.RoleId, a.SysMenuId });

            //1对多关系
            HasRequired(a => a.Role).WithMany(a => a.RoleSysMenu).HasForeignKey(a => a.RoleId);
            HasRequired(a => a.SysMenu).WithMany(a => a.RoleSysMenu).HasForeignKey(a => a.SysMenuId);
        }
    }
}
