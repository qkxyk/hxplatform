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
    /// 设备在线数据
    /// </summary>
    public class DeviceOnlineController : ApiController
    {
        private DeviceOnlineService _dos;
        /// <summary>
        /// 
        /// </summary>
        public DeviceOnlineController()
        {
            _dos = new DeviceOnlineService();
        }
        
        /// <summary>
        /// 添加设备在线数据
        /// </summary>
        /// <param name="dovm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceOnlineViewModel DeviceOnlineAdd(DeviceOnlineViewModel dovm)
        {
            //DeviceOnlineService dos = new DeviceOnlineService();
            return _dos.DeviceOnlineAdd(dovm);
        }

        /// <summary>
        /// 获取所有在线数据
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceOnlineListViewModel GetDeviceOnlineData(string token)
        {
            return _dos.GetGroupOnlineDevice(token);
        }
        
    }
}
