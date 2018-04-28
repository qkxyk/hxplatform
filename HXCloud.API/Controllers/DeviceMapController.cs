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
    /// 设备地图信息
    /// </summary>
    public class DeviceMapController : ApiController
    {
        private DeviceMapService _dms;
        /// <summary>
        /// 
        /// </summary>
        public DeviceMapController()
        {
            _dms = new DeviceMapService();
        }

        /// <summary>
        /// 设备地图添加
        /// </summary>
        /// <param name="dmvm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceMapViewModel DeviceMapAdd(DeviceMapViewModel dmvm)
        {
            return _dms.MapAdd(dmvm);
        }

        /// <summary>
        /// 获取设备地图信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceMapListViewModel GetDeviceMap(string account,string token,string deviceSn)
        {
            return _dms.GetDeviceMaps(account, token, deviceSn);
        }
    }
}
