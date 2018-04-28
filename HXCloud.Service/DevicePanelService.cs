using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.ModelView;
using HXCloud.Repository.EF.Repositories;
using HXCloud.ModelView.BaseData;

namespace HXCloud.Service
{
    public class DevicePanelService
    {
        private DevicePanelRepository _dpr;
        public DevicePanelService()
        {
            _dpr = new DevicePanelRepository();
        }

        /// <summary>
        /// 添加设备面板
        /// </summary>
        /// <param name="dpvm"></param>
        /// <returns></returns>
        public DevicePanelViewModel AddDevicePanel(DevicePanelViewModel dpvm)
        {
            //获取关联的设备，验证设备下是否存在此面板，验证用户在此项目下是否有添加删除权限
            DeviceModel dm = GetDeviceInfo(dpvm.Token, dpvm.DeviceSn);
            if (dm == null)
            {
                dpvm.Success = false;
                dpvm.Message = "不存在关联的设备";
                return dpvm;
            }
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(dpvm.Account, dpvm.Token, projectId, 2);
            if (!bRet)
            {
                dpvm.Success = false;
                dpvm.Message = "该用户无添加设备的权限";
                return dpvm;
            }
            DevicePanelModel dpm = dm.DevicePanel.Where(a => a.PanelName == dpvm.PanelName).FirstOrDefault();
            if (dpm != null)
            {
                dpvm.Success = false;
                dpvm.Message = "该设备已存在此面板，请选择其他名称";
                return dpvm;
            }
            dpm = new DevicePanelModel();
            dpm.DeviceSn = dm.DeviceSn;
            dpm.PanelName = dpvm.PanelName;
            dpm.TypeId = dpvm.TypeId;
            try
            {
                _dpr.Add(dpm);
                dpvm.Success = true;
                dpvm.Message = "添加设备面板成功";
            }
            catch (Exception ex)
            {
                dpvm.Success = false;
                dpvm.Message = "添加设备面板失败" + ex.Message;
            }

            return dpvm;
        }

        public DevicePanelListViewModel GetAllDevicePanel(string deviceSn, string account, string token)
        {
            //获取设备面板信息，验证用户是否有查看设备面板权限，获取所有设备面板
            DevicePanelListViewModel dplvm = new DevicePanelListViewModel();
            DeviceModel dm = GetDeviceInfo(token, deviceSn);
            if (dm == null)
            {
                dplvm.Success = false;
                dplvm.Message = "不存在关联的设备";
                return dplvm;
            }
            #region 验证用户权限
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                dplvm.Success = false;
                dplvm.Message = "该用户无添加设备的权限";
                return dplvm;
            }
            #endregion
            foreach (var item in dm.DevicePanel)
            {
                DevicePanelViewModel dpvm = new DevicePanelViewModel() { Id = item.Id, PanelName = item.PanelName, DeviceSn = deviceSn, TypeId = item.TypeId.Value };
                dplvm.list.Add(dpvm);
            }
            dplvm.Success = true;
            dplvm.Message = "获取设备面板成功";
            return dplvm;
        }
        public DeviceModel GetDeviceInfo(string token, string deviceSn)
        {
            DeviceRepository _dr = new DeviceRepository();
            DeviceModel dm = _dr.FindDeviceAndPanel(deviceSn, token);
            return dm;
        }

        public ResponseData UpdateDevicePanel(DevicePanelViewModel dpvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dpvm.DeviceSn, dpvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dpvm.Account, dpvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            DevicePanelModel dpm = _dpr.Find(dpvm.DeviceSn, dpvm.Id);
            if (dpm == null)
            {
                rd.Success = false;
                rd.Message = "该设备面板不存在";
                return rd;
            }
            dpm.PanelName = dpvm.PanelName;
            try
            {
                _dpr.Save(dpm);
                rd.Success = true;
                rd.Message = "修改设备面板名称成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "修改设备面板失败" + ex.Message;
            }
            return rd;
        }

        public ResponseData DeleteDevicePanel(DevicePanelViewModel dpvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dpvm.DeviceSn, dpvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dpvm.Account, dpvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备位置信息";
                return rd;
            }
            #endregion
            DevicePanelModel dpm = _dpr.Find(dpvm.DeviceSn, dpvm.Id);
            if (dpm == null)
            {
                rd.Success = false;
                rd.Message = "该设备面板不存在";
                return rd;
            }
            try
            {
                _dpr.Remove(dpm);
                rd.Success = true;
                rd.Message = "删除设备面板成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备面板失败";
            }
            return rd;
        }
    }
}
