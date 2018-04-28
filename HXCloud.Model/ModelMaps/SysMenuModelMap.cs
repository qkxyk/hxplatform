using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class SysMenuModelMap : EntityTypeConfiguration<SysMenuModel>
    {
        public SysMenuModelMap()
        {
            ToTable("SysMenu").HasKey(a => new { a.Id});
            //1对多自反关系
            HasOptional(a => a.Parent).WithMany(a => a.Child).HasForeignKey(a => a.ParentId);

            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.SysMenu).HasForeignKey(a => a.Token);
        }
    }
}
