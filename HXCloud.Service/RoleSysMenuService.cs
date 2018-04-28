using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.ModelView;
using HXCloud.Model;
using HXCloud.Repository.EF.Repositories;

namespace HXCloud.Service
{
    public class RoleSysMenuService
    {
        private RoleProjectRepository _rp;
        public RoleSysMenuService()
        {
            _rp = new RoleProjectRepository();
        }
    }
}
