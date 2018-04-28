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
    /// 设备功能
    /// </summary>
    public class DeviceController : ApiController
    {

        /// <summary>
        /// 设备添加
        /// </summary>
        /// <param name="dvm">设备参数</param>
        /// <returns>返回设备添加是否成功</returns>
        [HttpPost]
        public DeviceViewModel DeviceAdd(DeviceViewModel dvm)
        {
            DeviceService ds = new DeviceService();
            dvm = ds.DeviceAdd(dvm);
            return dvm;
        }

        /// <summary>
        /// 获取项目下的所有设备
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="token">用户所属组织</param>
        /// <param name="projectId">项目标示</param>
        /// <returns>返回项目下所有的设备</returns>
        [HttpGet]
        public DeviceListViewModel GetAllDevice(string account, string token, int projectId)
        {
            DeviceService ds = new DeviceService();
            DeviceListViewModel dlvm = ds.FindMenuDevices(token, projectId, account);
            return dlvm;
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="token">组织名称</param>
        /// <param name="deviceSn">设备序列号</param>
        /// <returns>返回设备信息</returns>
        [HttpGet]
        public DeviceViewModel GetDevice(string account, string token, string deviceSn)
        {
            return new DeviceService().FindDevice(account, token, deviceSn);
        }

        /// <summary>
        /// 更新设备的名称、设备编号、设备类型、设备所属场站
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns>返回是否更新成功</returns>
        [HttpPut]
        public ResponseData UpdateDevcie(DeviceViewModel dvm)
        {
            return new DeviceService().UpdateDevice(dvm);
        }

        /// <summary>
        /// 更新设备的位置信息
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns>返回是否更新成功</returns>
        [HttpPut]
        public ResponseData UpdateDevicePosition(DeviceViewModel dvm)
        {
            return new DeviceService().UpdateDevicePosition(dvm);
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns>返回删除设备是否成功</returns>
        [HttpPost]
        public ResponseData DeleteDevice(DeviceViewModel dvm)
        {
            return new DeviceService().DeleteDevice(dvm);
        }
    }
}
