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
    /// 
    /// </summary>
    public class DeviceControlDataController : ApiController
    {
        private DeviceControlDataService _dcds;
        /// <summary>
        /// 
        /// </summary>
        public DeviceControlDataController()
        {
            _dcds = new DeviceControlDataService();
        }

        /// <summary>
        /// 添加设备控制数据
        /// </summary>
        /// <param name="dcdvm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceControlDataViewModel DeviceControlDataAdd(DeviceControlDataViewModel dcdvm)
        {
            return _dcds.ControlDataAdd(dcdvm);
        }

        /// <summary>
        /// 获取设备控制数据
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceControlDataListViewModel GetDeviceControlData(string account,string token,string deviceSn)
        {
            return _dcds.FindControlData(account, token, deviceSn);
        }

        /// <summary>
        /// 删除设备控制数据
        /// </summary>
        /// <param name="dcdvm"></param>
        /// <returns>返回删除设备控制数据是否成功</returns>
        [HttpPost]
        public ResponseData DeleteDeviceControlData(DeviceControlDataViewModel dcdvm)
        {
            return _dcds.DeleteDeviceControlData(dcdvm);
        }

        /// <summary>
        /// 更新设备控制数据
        /// </summary>
        /// <param name="dcdvm"></param>
        /// <returns>返回更新设备控制数据是否成功</returns>
        [HttpPut]
        public ResponseData UpdateDeviceControlData(DeviceControlDataViewModel dcdvm)
        {
            return _dcds.UpdateDeviceControlData(dcdvm);
        }
    }
}
