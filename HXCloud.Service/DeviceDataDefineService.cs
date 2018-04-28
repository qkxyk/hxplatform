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
    public class DeviceDataDefineService
    {
        private DeviceDataDefineRepository _ddr;
        public DeviceDataDefineService()
        {
            _ddr = new DeviceDataDefineRepository();
        }

        public DeviceDataDefineViewModel DataDefineAdd(DeviceDataDefineViewModel dvm)
        {
            //验证用户是否有编辑的权限，验证该条数据是否已经被添加过，添加数据
            DeviceModel dm = new DeviceRepository().FindDeviceAndDataDefine(dvm.DeviceSn, dvm.Token);
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
                dvm.Message = "该用户无添加设备的权限";
                return dvm;
            }
            #endregion

            DeviceDataDefineModel ddm = dm.DeviceDataDefine.Where(a => a.DataKey == dvm.DataKey).FirstOrDefault();
            if (ddm != null)
            {
                dvm.Success = false;
                dvm.Message = "已存在此数据键";
                return dvm;
            }
            try
            {
                ddm = new DeviceDataDefineModel();
                ddm.DataKey = dvm.DataKey;
                ddm.DataName = dvm.DataName;
                ddm.DataType = dvm.DataType;
                ddm.DefaultValue = dvm.DefaultValue;
                ddm.Unit = dvm.Unit;
                ddm.PanelId = dvm.PanelId;
                ddm.DeviceSn = dm.DeviceSn;
                _ddr.Add(ddm);
                dvm.Id = ddm.Id;
                dvm.Success = true;
                dvm.Message = "添加数据栏位成功";
            }
            catch (Exception ex)
            {
                dvm.Success = false;
                dvm.Message = "添加数据栏位失败" + ex.Message;
            }
            return dvm;
        }

        public DeviceDataDefineListViewModel GetDataDefine(string account, string token, string deviceSn)
        {
            //获取设备数据栏信息，验证用户是否有查看设备数据栏权限，获取所有设备数据栏信息
            DeviceDataDefineListViewModel dlvm = new DeviceDataDefineListViewModel();
            DeviceModel dm = new DeviceRepository().FindDeviceAndDataDefine(deviceSn, token);// GetDeviceInfo(token, deviceSn);
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
                dlvm.Message = "该用户无查看此设备数据栏的权限";
                return dlvm;
            }
            #endregion
            foreach (var item in dm.DeviceDataDefine)
            {
                DeviceDataDefineViewModel dpvm = new DeviceDataDefineViewModel()
                {
                    Id = item.Id,
                    DataKey = item.DataKey,
                    DefaultValue = item.DefaultValue,
                    DataName = item.DataName,
                    PanelId = item.PanelId,
                    Unit = item.Unit,
                    DataType = item.DataType,
                    DeviceSn = deviceSn
                };
                dlvm.list.Add(dpvm);
            }
            dlvm.Success = true;
            dlvm.Message = "获取设备栏位数据成功";
            return dlvm;
        }

        public ResponseData UpdateDeviceDataDefine(DeviceDataDefineViewModel ddvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(ddvm.DeviceSn, ddvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, ddvm.Account, ddvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _ddr.Find(ddvm.Id);
            dv.DataKey = ddvm.DataKey;
            dv.DataName = ddvm.DataName;
            dv.DataType = ddvm.DataType;
            dv.DefaultValue = ddvm.DefaultValue;
            dv.Unit = ddvm.Unit;
            try
            {
                _ddr.Save(dv);
                rd.Success = true;
                rd.Message = "修改设备定义数据成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改设备定义数据失败";
            }
            return rd;
        }

        public ResponseData DeleteDeviceDataDefine(DeviceDataDefineViewModel ddvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(ddvm.DeviceSn, ddvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, ddvm.Account, ddvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _ddr.Find(ddvm.Id);
            try
            {
                _ddr.Remove(dv);
                rd.Success = true;
                rd.Message = "删除设备定义数据成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备定义数据失败";
            }
            return rd;
        }
    }
}
