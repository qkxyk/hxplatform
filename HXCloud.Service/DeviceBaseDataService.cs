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
    public class DeviceBaseDataService
    {
        private DeviceBaseDataRepository _dbdr;
        public DeviceBaseDataService()
        {
            _dbdr = new DeviceBaseDataRepository();
        }

        public DeviceBaseDataViewModel DeviceBaseDataAdd(DeviceBaseDataViewModel dvm)
        {
            //验证用户是否有编辑的权限，验证该条数据是否已经被添加过，添加数据
            DeviceModel dm = new DeviceRepository().FindDeviceAndBaseData(dvm.DeviceSn, dvm.Token);
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

            DeviceBaseDataModel ddm = dm.DeviceBaseData.Where(a => a.DataName == dvm.DataName).FirstOrDefault();
            if (ddm != null)
            {
                dvm.Success = false;
                dvm.Message = "已存在此数据";
                return dvm;
            }
            try
            {
                ddm = new DeviceBaseDataModel();
                ddm.DataName = dvm.DataName;
                ddm.DataType = dvm.DataType;
                ddm.DataValue = dvm.DataValue;
                ddm.PanelId = dvm.PanelId;
                ddm.DeviceSn = dm.DeviceSn;
                _dbdr.Add(ddm);
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

        public DeviceBaseDataListViewModel GetDeviceBaseData(string account, string token, string deviceSn)
        {
            //获取设备数据栏信息，验证用户是否有查看设备数据栏权限，获取所有设备数据栏信息
            DeviceBaseDataListViewModel dlvm = new DeviceBaseDataListViewModel();
            DeviceModel dm = new DeviceRepository().FindDeviceAndBaseData(deviceSn, token);// GetDeviceInfo(token, deviceSn);
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
            foreach (var item in dm.DeviceBaseData)
            {
                DeviceBaseDataViewModel dpvm = new DeviceBaseDataViewModel()
                {
                    Id = item.Id,
                    DataName = item.DataName,
                    PanelId = item.PanelId,
                    DataType = item.DataType,
                    DeviceSn = deviceSn,
                    DataValue = item.DataValue
                };
                dlvm.list.Add(dpvm);
            }
            dlvm.Success = true;
            dlvm.Message = "获取设备栏位数据成功";
            return dlvm;
        }

        public ResponseData UpdateDeviceBaseData(DeviceBaseDataViewModel dbdvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dbdvm.DeviceSn, dbdvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dbdvm.Account, dbdvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion

            DeviceBaseDataModel dbdm = _dbdr.Find(dbdvm.Id);
            if (dbdm == null)
            {
                rd.Success = false;
                rd.Message = "该信息不存在";
                return rd;
            }
            dbdm.DataName = dbdvm.DataName;
            dbdm.DataType = dbdvm.DataType;
            dbdm.DataValue = dbdvm.DataValue;
            try
            {
                _dbdr.Save(dbdm);
                rd.Success = true;
                rd.Message = "修改设备信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改设备信息失败";
            }

            return rd;
        }

        public ResponseData DeleteDeviceBaseData(DeviceBaseDataViewModel dbdvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dbdvm.DeviceSn, dbdvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dbdvm.Account, dbdvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限删除设备信息";
                return rd;
            }
            #endregion
            DeviceBaseDataModel dbdm = _dbdr.Find(dbdvm.Id);
            try
            {
                _dbdr.Remove(dbdm);
                rd.Message = "删除设备信息成功";
                rd.Success = true;
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备信息失败";
            }
            return rd;
        }
    }
}
