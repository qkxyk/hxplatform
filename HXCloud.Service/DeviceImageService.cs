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
    public class DeviceImageService
    {
        private DeviceImageRepository _dir;
        public DeviceImageService()
        {
            _dir = new DeviceImageRepository();
        }

        public DeviceImageViewModel DeviceImageAdd(DeviceImageViewModel dvm)
        {
            //验证用户是否有编辑的权限，验证该条数据是否已经被添加过，添加数据
            DeviceModel dm = new DeviceRepository().FindDeviceAndImage(dvm.DeviceSn, dvm.Token);
            if (dm == null)
            {
                dvm.Success = false;
                dvm.Message = "不存在关联的设备";
                return dvm;
            }
            #region 验证用户权限
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(dvm.Account, dvm.Token, projectId, 1);
            if (!bRet)
            {
                dvm.Success = false;
                dvm.Message = "该用户无添加图片的权限";
                return dvm;
            }
            #endregion

            DeviceImageModel ddm = dm.DeviceImage.Where(a => a.ImageName == dvm.ImageName).FirstOrDefault();
            if (ddm != null)
            {
                dvm.Success = false;
                dvm.Message = "已存在此数据键";
                return dvm;
            }
            try
            {
                ddm = new DeviceImageModel();
                ddm.PanelId = dvm.PanelId;
                ddm.DeviceSn = dm.DeviceSn;
                ddm.ImageName = dvm.ImageName;
                ddm.url = dvm.url;
                _dir.Add(ddm);
                dvm.Id = ddm.Id;
                dvm.Success = true;
                dvm.Message = "添加图片成功";
            }
            catch (Exception ex)
            {
                dvm.Success = false;
                dvm.Message = "添加图片失败" + ex.Message;
            }
            return dvm;
        }

        public DeviceImageListViewModel GetDeviceImages(string account, string token, string deviceSn)
        {
            //获取设备数据栏信息，验证用户是否有查看设备数据栏权限，获取所有设备数据栏信息
            DeviceImageListViewModel dlvm = new DeviceImageListViewModel();
            DeviceModel dm = new DeviceRepository().FindDeviceAndImage(deviceSn, token);// GetDeviceInfo(token, deviceSn);
            if (dm == null)
            {
                dlvm.Success = false;
                dlvm.Message = "不存在关联的设备";
                return dlvm;
            }
            #region 验证用户权限
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                dlvm.Success = false;
                dlvm.Message = "该用户无查看此设备图片的权限";
                return dlvm;
            }
            #endregion
            foreach (var item in dm.DeviceImage)
            {
                DeviceImageViewModel dpvm = new DeviceImageViewModel()
                {
                    Id = item.Id,
                    ImageName = item.ImageName,
                    url = item.url,
                    PanelId = item.PanelId,
                    DeviceSn = deviceSn
                };
                dlvm.list.Add(dpvm);
            }
            dlvm.Success = true;
            dlvm.Message = "获取设备图片数据成功";
            return dlvm;
        }

        public DeviceImageViewModel AddDeviceImage(string deviceSn, int panelId, string imageName, string url)
        {
            DeviceImageViewModel divm = new DeviceImageViewModel();
            try
            {
                DeviceImageModel dim = new DeviceImageModel();
                dim.DeviceSn = deviceSn;
                dim.PanelId = panelId;
                dim.ImageName = imageName;
                dim.url = url;
                _dir.Add(dim);
                divm.Success = true;
                divm.Message = "添加设备图片成功";
            }
            catch (Exception ex)
            {
                divm.Success = false;
                divm.Message = "添加设备图片失败" + ex.Message;
            }
            return divm;
        }

        //只支持修改图片的名称，如果要更换图片，先删除图片再上传
        public ResponseData UpdateDeviceImage(DeviceImageViewModel divm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(divm.DeviceSn, divm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, divm.Account, divm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _dir.Find(divm.Id);
            dv.ImageName = divm.ImageName;
            try
            {
                _dir.Save(dv);
                rd.Success = true;
                rd.Message = "修改图片名称成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改图片名称失败";
            }
            return rd;
        }

        public ResponseData DeleteDeviceImage(DeviceImageViewModel divm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(divm.DeviceSn, divm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, divm.Account, divm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _dir.Find(divm.Id);
            try
            {
                //需要先删除图片
                
                _dir.Remove(dv);
                rd.Success = true;
                rd.Message = "删除图片成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除图片失败";
            }
            return rd;
        }
    }
}
