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
    /// 设备视频数据
    /// </summary>
    public class DeviceVideoController : ApiController
    {
        private DeviceVideoService _dvs;
        /// <summary>
        /// 设备视频数据
        /// </summary>
        public DeviceVideoController()
        {
            _dvs = new DeviceVideoService();
        }

        /// <summary>
        /// 添加设备视频数据
        /// </summary>
        /// <param name="dvvm"></param>
        /// <returns></returns>
        [HttpPost]
        public DeviceVideoViewModel DeviceVideoAdd(DeviceVideoViewModel dvvm)
        {
            return _dvs.VideoAdd(dvvm);
        }

        /// <summary>
        /// 查询设备视频数据
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="deviceSn"></param>
        /// <returns></returns>
        [HttpGet]
        public DeviceVideoListViewModel GetDeviceVideo(string account, string token, string deviceSn)
        {
            return _dvs.GetDeviceVideoes(account, token, deviceSn);
        }

        /// <summary>
        /// 更新设备视频信息
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns>返回更新设备视频信息是否成功</returns>
        [HttpPut]
        public ResponseData UpdateDeviceVideo(DeviceVideoViewModel dvm)
        {
            return _dvs.UpdateDeviceVideo(dvm);
        }

        /// <summary>
        /// 删除设备视频信息
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns>返回删除视频设备是否成功</returns>
        [HttpPost]
        public ResponseData DeleteDeviceVideo(DeviceVideoViewModel dvm)
        {
            return _dvs.DeleteDeviceVideo(dvm);
        }
    }
}
