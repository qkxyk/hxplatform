using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.ModelView;
using HXCloud.Service;

namespace HXCloud.API.Controllers
{
    /// <summary>
    /// 用户组织功能
    /// </summary>
    public class GroupController : ApiController
    {
        GroupService gs = new GroupService();


        /// <summary>
        /// 添加组织
        /// </summary>
        /// <param name="gvm">组织信息</param>
        /// <returns>返回添加组织后的信息</returns>
        [HttpPost]
        public GroupViewModel Add(GroupViewModel gvm)
        {            
            gvm = gs.CreateGroup(gvm);

            return gvm;
        }

        /// <summary>
        /// 根据组织名称查找组织
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public GroupListViewModel FindByName(string name)
        {
            GroupListViewModel glvm = new GroupListViewModel();
            glvm = gs.GetGroupList(name);
            return glvm;
        }

        /// <summary>
        /// 根据组织标示查找组织
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public GroupViewModel FindByToken(string token)
        {
            GroupViewModel gvm = new GroupViewModel();
            gvm = gs.GetGroupByToken(token);
            return gvm;
        }

        /// <summary>
        /// 编辑组织
        /// </summary>
        /// <param name="gvm"></param>
        /// <returns></returns>
        [HttpPost]
        public GroupViewModel GroupUpdate(GroupViewModel gvm)
        {
            return gvm;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="gvm"></param>
        /// <returns></returns>
        [HttpPost]
        public GroupViewModel GroupDelete(GroupViewModel gvm)
        {
            return gvm;
        }
    }
}
