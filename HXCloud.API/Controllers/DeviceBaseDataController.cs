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
    /// 设备基本数据
    /// </summary>
    public class DeviceBaseDataController : ApiController
    {
        private DeviceBaseDataService _ds;
        /// <summary>
        /// 
        /// </summary>
        public DeviceBaseDataController()
        {
            _ds = new DeviceBaseDataService();
        }

        /// <summary>
        /// 添加设备基本数据
        /// </summary>
        /// <param name="dbd"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceBaseDataViewModel DeviceBaseDataAdd(DeviceBaseDataViewModel dbd)
        {
            return _ds.DeviceBaseDataAdd(dbd);
        }

        /// <summary>
        /// 获取设备基本数据
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceBaseDataListViewModel GetDeviceBaseData(string account,string token,string deviceSn)
        {
            return _ds.GetDeviceBaseData(account, token, deviceSn);
        }

        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="dbdvm"></param>
        /// <returns>返回修改设备信息是否成功</returns>
        [HttpPut]
        public ResponseData UpdateDeviceBaseData(DeviceBaseDataViewModel dbdvm)
        {
            return _ds.UpdateDeviceBaseData(dbdvm);
        }

        /// <summary>
        /// 删除设备基本信息
        /// </summary>
        /// <param name="dbdvm"></param>
        /// <returns>返回删除设备信息是否成功</returns>
        [HttpPost]
        public ResponseData DeleteDeviceBaseData(DeviceBaseDataViewModel dbdvm)
        {
            return _ds.DeleteDeviceBaseData(dbdvm);
        }
    }
}
