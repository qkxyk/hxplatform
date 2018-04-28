using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;


namespace HXCloud.Model.ModelMaps
{
    public class UserRoleModelMap : EntityTypeConfiguration<UserRoleModel>
    {
        public UserRoleModelMap()
        {
            ToTable("UserRole").HasKey(a => a.UserId);
            //1对1关系
            HasRequired(a => a.User).WithRequiredDependent(a => a.UserRole);//.Map(a=>a.MapKey("userId"));
            //string[] r = new string[] { "id","userid"};
            //HasOptional(a => a.User).WithOptionalPrincipal(a => a.UserRole).Map((a) => a.MapKey("userId"));
            //1对多关系
            HasRequired(a => a.Role).WithMany(a => a.UserRole).HasForeignKey(a => a.RoleId);
        }
    }
}
