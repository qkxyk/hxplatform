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
    /// 设备类型
    /// </summary>
    public class DeviceTypeController : ApiController
    {
        DeviceTypeService _dts;//= new DeviceTypeService();
        public DeviceTypeController()
        {
            _dts = new DeviceTypeService();
        }
        /// <summary>
        /// 添加设备类型
        /// </summary>
        /// <param name="dtvm">同一个组织下的设备类型名称不能重复</param>
        /// <returns>返回添加的设备类型id和是否添加成功信息</returns>
        [HttpPost]
        public DeviceTypeViewModel AddDeviceType(DeviceTypeViewModel dtvm)
        {
            dtvm = _dts.DeviceTypeAdd(dtvm);
            return dtvm;
        }

        /// <summary>
        /// 获取组织下设备类型列表
        /// </summary>
        /// <param name="token">组织</param>
        /// <returns>返回设备类型列表信息</returns>
        [HttpGet]
        public DeviceTypeListReponseViewModel GetDeviceType(string token)
        {
            return _dts.GetDeviceTypeList(token);
        }

        /// <summary>
        /// 统计组织内按设备类型的设备分布情况
        /// </summary>
        ///<param name="account"></param>
        ///<param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData GetDeviceGroupData(string account, string token)
        {
          
            RequestData rd = new RequestData() { Account = account, Token = token };
            return _dts.GetDeviceGroupData(rd);
        }

        /// <summary>
        /// 更新设备类型信息
        /// </summary>
        /// <param name="dtvm"></param>
        /// <returns>返回更新设备类型信息是否成功</returns>
        [HttpPut]
        public ResponseData UpdateDeviceType(DeviceTypeViewModel dtvm)
        {
            return _dts.UpdateDeviceType(dtvm);
        }
    }
}
