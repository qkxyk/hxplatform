using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.ModelView;
using HXCloud.Service;
using HXCloud.ModelView.BaseData;

namespace HXCloud.API.Controllers
{
    /// <summary>
    /// 项目的附属信息
    /// </summary>
    public class ProjectAffiliateController : ApiController
    {
        ProjectAffiliateService _mas;
        /// <summary>
        /// 
        /// </summary>
        public ProjectAffiliateController()
        {
            _mas = new ProjectAffiliateService();
        }

        /// <summary>
        /// 添加项目附属属性
        /// </summary>
        /// <param name="mavm"></param>
        /// <returns></returns>
        [HttpPost]
        public ProjectAffiliateViewModel ProjectAffilateAdd(ProjectAffiliateViewModel mavm)
        {
            return _mas.ProjectAffilateAdd(mavm);
        }

        /// <summary>
        /// 获取项目的附属属性
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        public ProjectAffiliateListViewModel GetProjectAffilate(string account, string token, int projectId)
        {
            return _mas.GetProjectAffilate(account, token, projectId);
        }

        /// <summary>
        /// 更新项目附属属性
        /// </summary>
        /// <param name="pavm"></param>
        /// <returns>返回项目附属属性更改是否成功</returns>
        [HttpPut]
        public ResponseData ProjectAffiliateEdit(ProjectAffiliateViewModel pavm)
        {
            return _mas.ProjectAffiliateEdit(pavm);
        }

        /// <summary>
        /// 删除项目附属属性
        /// </summary>
        /// <param name="pavm"></param>
        /// <returns>返回删除项目附属属性是否成功</returns>
        [HttpPost]
        public ResponseData ProjectAffiliateRemove(ProjectAffiliateViewModel pavm)
        {
            return _mas.ProjectAffiliateRemove(pavm);
        }
    }
}
