using HXCloud.ModelView;
using HXCloud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HXCloud.API.Controllers
{
    public class DevicePanelTypeController : ApiController
    {
        private DevicePanelTypeService _dpts;
        public DevicePanelTypeController()
        {
            _dpts = new DevicePanelTypeService();
        }

        /// <summary>
        /// 获取全部设备面板类型
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="token">用户组织</param>
        /// <returns>返回全部设备面板类型</returns>
        [HttpGet]
        public DevicePanelTypeListViewModel Get(string account, string token)
        {
            return _dpts.Get(account, token);
        }
    }
}
