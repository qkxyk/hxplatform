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
    /// 设备面板功能
    /// </summary>
    public class DevicePanelController : ApiController
    {
        /// <summary>
        /// 添加设备面板
        /// </summary>
        /// <param name="dpvm">传入设备序列号，设备面板名称和组织标示</param>
        /// <returns>返回添加设备面板信息</returns>
        [HttpPost]
        public DevicePanelViewModel AddPanel(DevicePanelViewModel dpvm)
        {
            DevicePanelService dps = new DevicePanelService();
            return dps.AddDevicePanel(dpvm);
        }

        /// <summary>
        /// 获取设备的所有面板
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="token">组织标示</param>
        /// <param name="deviceSn">设备序列号</param>
        /// <returns></returns>
        [HttpGet]
        public DevicePanelListViewModel GetDevicePanels(string account, string token, string deviceSn)
        {
            DevicePanelService dps = new DevicePanelService();
            return dps.GetAllDevicePanel(deviceSn, account, token);
        }

        /// <summary>
        /// 更新设备面板名称
        /// </summary>
        /// <param name="dpvm"></param>
        /// <returns>返回是否更新成功信息</returns>
        [HttpPut]
        public ResponseData UpdateDevicePanel(DevicePanelViewModel dpvm)
        {
            DevicePanelService dps = new DevicePanelService();
            return dps.UpdateDevicePanel(dpvm);
        }

        /// <summary>
        /// 删除设备面板
        /// </summary>
        /// <param name="dpvm"></param>
        /// <returns>返回删除设备面板的信息</returns>
        [HttpPost]
        public ResponseData DeleteDevicePanel(DevicePanelViewModel dpvm)
        {
            DevicePanelService dps = new DevicePanelService();
            return dps.DeleteDevicePanel(dpvm);
        }
    }
}
