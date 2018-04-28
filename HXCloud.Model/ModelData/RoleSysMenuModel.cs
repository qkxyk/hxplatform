using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public class RoleSysMenuModel
    {
        public int RoleId { get; set; }
        public string SysMenuId { get; set; }

        public virtual RoleModel Role { get; set; }
        public virtual SysMenuModel SysMenu { get; set; }
    }
}
