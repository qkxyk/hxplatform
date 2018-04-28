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
    /// 设备历史数据
    /// </summary>
    public class DeviceHisController : ApiController
    {
        private DeviceHisService _dhs;
        /// <summary>
        /// 
        /// </summary>
        public DeviceHisController()
        {
            _dhs = new DeviceHisService();
        }

        /// <summary>
        /// 设备历史数据添加
        /// </summary>
        /// <param name="dhvm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceHisViewModel DeviceHisAdd(DeviceHisViewModel dhvm)
        {
            return _dhs.DeviceHisAdd(dhvm);
        }

        /// <summary>
        /// 获取组织的历史数据
        /// </summary>
        /// <param name="token"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceHisListViewModel GetGroupDeviceHis(string token,string account)
        {
            return _dhs.GetGroupHisData(token,account);
        }

        /// <summary>
        /// 获取设备的历史数据
        /// </summary>
        /// <param name="token"></param>
        /// <param name="account"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceHisListViewModel GetDeviceHis(string token,string account,string deviceSn)
        {
            return _dhs.GetDeviceHisData(token, deviceSn,account );
        }
    }
}
