using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class RoleModel : IAggregateRoot
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int IsAdmin { get; set; } = 0;//是否是管理员

        public string Token { get; set; }//标示该角色属于那个团队
        public virtual GroupModel Group { get; set; }

        public virtual ICollection<UserRoleModel> UserRole { get; set; }
        public virtual ICollection<RoleProjectModel> RoleProject { get; set; }
        public virtual ICollection<RoleSysMenuModel> RoleSysMenu { get; set; }
    }
}
