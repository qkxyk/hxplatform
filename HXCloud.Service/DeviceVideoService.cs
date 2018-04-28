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
    public class DeviceVideoService
    {
        private DeviceVideoRepository _dvr;
        public DeviceVideoService()
        {
            _dvr = new DeviceVideoRepository();
        }

        //添加视频设备
        public DeviceVideoViewModel VideoAdd(DeviceVideoViewModel dvvm)
        {
            //获取设备信息
            DeviceModel dm = new DeviceRepository().FindDeviceAndVideo(dvvm.DeviceSn, dvvm.Token);
            if (dm == null)
            {
                dvvm.Success = false;
                dvvm.Message = "不存在关联的设备";
                return dvvm;
            }
            #region 检测用户是否有权限进行操作
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(dvvm.Account, dvvm.Token, projectId, 1);
            if (!bRet)
            {
                dvvm.Success = false;
                dvvm.Message = "该用户无添加视频的权限";
                return dvvm;
            }
            #endregion

            #region 检测视频设备是否重名
            DeviceVideoModel dvm = dm.DeviceVideo.Where(a => a.VideoName == dvvm.VideoName).FirstOrDefault();
            if (dvm != null)
            {
                dvvm.Success = false;
                dvvm.Message = "已存在此视频设备";
                return dvvm;
            }
            #endregion
            #region 添加视频设备
            dvm = new DeviceVideoModel()
            {
                VideoName = dvvm.VideoName,
                PanelId = dvvm.PanelId,
                Url = dvvm.Url,
                DeviceSn = dm.DeviceSn,
                Channel = dvvm.Channel,
                SecurityCode = dvvm.SecurityCode,
                VideoSn = dvvm.VideoSn
            };
            try
            {
                _dvr.Add(dvm);
                dvvm.Success = true;
                dvvm.Message = "添加视频设备成功";
            }
            catch (Exception ex)
            {
                dvvm.Success = false;
                dvvm.Message = "已存在此视频设备" + ex.Message;
                return dvvm;
            }
            #endregion
            return dvvm;
        }
        //查找设备所有的视频设备
        public DeviceVideoListViewModel GetDeviceVideoes(string account, string token, string deviceSn)
        {
            DeviceVideoListViewModel dvlvm = new DeviceVideoListViewModel();
            //获取设备信息
            DeviceModel dm = new DeviceRepository().FindDeviceAndVideo(deviceSn, token);
            if (dm == null)
            {
                dvlvm.Success = false;
                dvlvm.Message = "不存在关联的设备";
                return dvlvm;
            }
            #region 检测用户是否有权限进行操作
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                dvlvm.Success = false;
                dvlvm.Message = "该用户无添加视频的权限";
                return dvlvm;
            }
            #endregion

            #region 视频设备信息
            foreach (var item in dm.DeviceVideo)
            {
                DeviceVideoViewModel dvvm = new DeviceVideoViewModel()
                {
                    Id = item.Id,
                    PanelId = item.PanelId,
                    Url = item.Url,
                    VideoName = item.VideoName,
                    DeviceSn = item.DeviceSn,
                    VideoSn = item.VideoSn,
                    Channel = item.Channel,
                    SecurityCode = item.SecurityCode
                };
                dvlvm.list.Add(dvvm);
            }
            #endregion
            dvlvm.Success = true;
            dvlvm.Message = "获取视频设备成功";
            return dvlvm;
        }

        public ResponseData UpdateDeviceVideo(DeviceVideoViewModel dvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dvm.DeviceSn, dvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dvm.Account, dvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _dvr.Find(dvm.Id);
            dv.VideoName = dvm.VideoName;
            dv.Url = dvm.Url;
            dv.VideoSn = dvm.VideoSn;
            dv.Channel = dvm.Channel;
            dv.SecurityCode = dvm.SecurityCode;
            try
            {
                _dvr.Save(dv);
                rd.Success = true;
                rd.Message = "修改设备视频信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改设备视频信息失败";
            }
            return rd;
        }

        public ResponseData DeleteDeviceVideo(DeviceVideoViewModel dvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dvm.DeviceSn, dvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dvm.Account, dvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _dvr.Find(dvm.Id);
            try
            {
                _dvr.Remove(dv);
                rd.Success = true;
                rd.Message = "删除设备视频信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备视频信息失败";
            }
            return rd;
        }
    }
}
