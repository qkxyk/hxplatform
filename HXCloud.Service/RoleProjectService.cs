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
    public class RoleProjectService
    {
        private RoleProjectRepository _rmr;
        public RoleProjectService()
        {
            _rmr = new RoleProjectRepository();
        }
    }
}
