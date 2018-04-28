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
    /// 设备报警数据
    /// </summary>
    public class DeviceAlarmController : ApiController
    {
        private DeviceAlarmService _das;
        /// <summary>
        /// 设备报警
        /// </summary>
        public DeviceAlarmController()
        {
            _das = new DeviceAlarmService();
        }

        /// <summary>
        /// 设备报警数据添加
        /// </summary>
        /// <param name="davm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceAlarmViewModel DeviceAlarmAdd(DeviceAlarmViewModel davm)
        {
            return _das.DeviceAlarmAdd(davm);
        }

        /// <summary>
        /// 获取组织的报警数据
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceAlarmListViewModel GetDeviceAlarmData(string token)
        {
            return _das.GetGroupDeviceAlarm(token);
        }
    }
}
