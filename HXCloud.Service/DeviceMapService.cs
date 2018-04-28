using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.ModelView;
using HXCloud.Repository.EF.Repositories;

namespace HXCloud.Service
{
    public class DeviceMapService
    {
        private DeviceMapRepository _dmr;
        public DeviceMapService()
        {
            _dmr = new DeviceMapRepository();
        }


        //添加设备地图
        public DeviceMapViewModel MapAdd(DeviceMapViewModel dmvm)
        {
            //获取设备信息
            DeviceModel dm = new DeviceRepository().FindDeviceAndDeviceMap(dmvm.DeviceSn, dmvm.Token);
            if (dm == null)
            {
                dmvm.Success = false;
                dmvm.Message = "不存在关联的设备";
                return dmvm;
            }
            #region 检测用户是否有权限进行操作
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(dmvm.Account, dmvm.Token, projectId, 1);
            if (!bRet)
            {
                dmvm.Success = false;
                dmvm.Message = "该用户无添加设备地图的权限";
                return dmvm;
            }
            #endregion
            DeviceMapModel dmm = new DeviceMapModel()
            {
                PanelId = dmvm.PanelId,
                Position = dmvm.Position,
                DeviceSn = dm.DeviceSn
            };
            try
            {
                _dmr.Add(dmm);
                dmvm.Success = true;
                dmvm.Message = "添加设备地图成功";
            }
            catch (Exception ex)
            {
                dmvm.Success = false;
                dmvm.Message = "添加设备地图失败" + ex.Message;
                return dmvm;
            }

            return dmvm;
        }
        //查找设备所有的地图
        public DeviceMapListViewModel GetDeviceMaps(string account, string token, string deviceSn)
        {
            DeviceMapListViewModel dmlvm = new DeviceMapListViewModel();
            //获取设备信息
            DeviceModel dm = new DeviceRepository().FindDeviceAndDeviceMap(deviceSn, token);
            if (dm == null)
            {
                dmlvm.Success = false;
                dmlvm.Message = "不存在关联的设备";
                return dmlvm;
            }
            #region 检测用户是否有权限进行操作
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                dmlvm.Success = false;
                dmlvm.Message = "该用户无查看地图的权限";
                return dmlvm;
            }
            #endregion
            foreach (var item in dm.DeviceMap)
            {
                DeviceMapViewModel dmvm = new DeviceMapViewModel()
                {
                    Id = item.Id,
                    PanelId = item.PanelId,
                    Position = item.Position,
                    DeviceSn = deviceSn,
                    Token = token
                };
                dmlvm.list.Add(dmvm);
            }
            dmlvm.Success = true;
            dmlvm.Message = "获取设备地图信息成功";
            return dmlvm;
        }
    }
}
