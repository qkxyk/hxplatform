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
    /// 设备栏位数据
    /// </summary>
    public class DeviceDataDefineController : ApiController
    {
        private DeviceDataDefineService _ds;
        public DeviceDataDefineController()
        {
            _ds = new DeviceDataDefineService();
        }

        /// <summary>
        /// 添加设备定义数据
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceDataDefineViewModel DeviceDataDefineAdd(DeviceDataDefineViewModel dvm)
        {
            return _ds.DataDefineAdd(dvm);
        }

        /// <summary>
        /// 获取设备定义数据
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceDataDefineListViewModel GetDeviceDataDefine(string account,string token,string deviceSn)
        {
            return _ds.GetDataDefine(account, token, deviceSn);
        }

        /// <summary>
        /// 更新设备定义数据
        /// </summary>
        /// <param name="ddvm"></param>
        /// <returns>返回更新设备定义数据是否成功</returns>
        [HttpPut]
        public ResponseData UpdateDeviceDataDefine(DeviceDataDefineViewModel ddvm)
        {
            return _ds.UpdateDeviceDataDefine(ddvm);
        }

        /// <summary>
        /// 删除设备定义数据
        /// </summary>
        /// <param name="ddvm"></param>
        /// <returns>返回删除设备定义数据是否成功</returns>
        [HttpPost]
        public ResponseData DeleteDeviceDataDefine(DeviceDataDefineViewModel ddvm)
        {
            return _ds.DeleteDeviceDataDefine(ddvm);
        }
    }
}
