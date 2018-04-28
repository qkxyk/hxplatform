using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
    public class UserModelMap : EntityTypeConfiguration<UserModel>
    {
        public UserModelMap()
        {
            ToTable("User").HasKey(a => a.Id);
            //1对1关系
           // HasOptional(u => u.UserRole).WithRequired(ux => ux.User);
            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.User).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
        }
    }
}
