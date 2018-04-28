using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.ModelView;
using HXCloud.Repository.EF.Repositories;

namespace HXCloud.Service
{
   public class UserRoleService
    {
        UserRoleRepository _urr;
        public UserRoleService()
        {
            _urr = new UserRoleRepository();
        }
        public void AddUserRole(UserRoleViewModel urvm)
        {
            //检测用户角色是否存在，如果存在就返回，不存在就添加

            UserRoleModel urm = new UserRoleModel() { RoleId = urvm.RoleId, UserId = urvm.UserId };
            _urr.Add(urm);
        }
    }
}
