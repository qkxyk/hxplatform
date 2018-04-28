using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.Service;
using HXCloud.ModelView;
using HXCloud.ModelView.BaseData;

namespace HXCloud.API.Controllers
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class RoleController : ApiController
    {
        private RoleService _rs;
        public RoleController()
        {
            _rs = new RoleService();
        }
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="rvm">角色信息</param>
        /// <returns>返回角色创建的是否成功</returns>
        [HttpPost]
        public ResponseData CreateRole(RoleViewModel rvm)
        {
            return _rs.CreateRole(rvm);
        }

        /// <summary>
        /// 获取组织的角色信息
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="token">角色标示</param>
        /// <returns>返回组织的角色信息</returns>
        [HttpGet]
        public RoleListViewModel GetRoles(string account, string token)
        {
            return _rs.GetRoles(account, token);
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="rvm">角色信息</param>
        /// <returns>返回修改角色信息是否成功</returns>
        [HttpPut]
        public ResponseData UpdateRole(RoleViewModel rvm)
        {
            return _rs.UpdateRole(rvm);
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="rvm">角色信息</param>
        /// <returns>返回删除角色信息是否成功</returns>
        [HttpPost]
        public ResponseData DeleteRole(RoleViewModel rvm)
        {
            return _rs.DeleteRole(rvm);
        }
    }
}
