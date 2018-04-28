using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;


namespace HXCloud.Model.ModelMaps
{
   public class RoleModelMap:EntityTypeConfiguration<RoleModel>
    {
        public RoleModelMap()
        {
            ToTable("Role").HasKey(a=>a.Id);
            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.Role).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
        }
    }
}
