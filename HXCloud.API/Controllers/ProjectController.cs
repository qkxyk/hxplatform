using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.ModelView;
using HXCloud.ModelView.BaseData;
using HXCloud.Service;

namespace HXCloud.API.Controllers
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public class ProjectController : ApiController
    {
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="mavm">项目的基本信息，token为项目所有组织，parentid为项目的父项目id，typeid为0时表示是主项目，1表示可以循环添加的项目，2表示可以添加设备的项目</param>
        /// <returns>返回添加项目的信息</returns>
        [HttpPost]
        public ProjectAddViewModel ProjectAdd(ProjectAddViewModel mavm)
        {
            ProjectService ms = new ProjectService();
            return ms.AddProject(mavm);
        }


        /// <summary>
        /// 获取项目下的所有子项目(包含场站)
        /// </summary>
        /// <param name="rd">用户名和组织标示</param>
        /// <param name="projectId">项目标示</param>
        /// <returns></returns>
        [HttpGet]
        public ProjectListViewModel FindUserSubProject([FromUri]RequestData rd, int projectId)
        {
            ProjectService ms = new ProjectService();
            return ms.FindUserSubProject(rd.Account, rd.Token, projectId);
        }

        /// <summary>
        /// 获取用户所能查看的所有一级项目
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        [HttpGet]
        public ProjectListViewModel FindUserProject([FromUri]RequestData rd/*string account, string token*/)
        {
            ProjectService ms = new ProjectService();
            return ms.FindUserProject(rd.Account, rd.Token);
        }

        //项目删除

        //项目编辑


    }
}
