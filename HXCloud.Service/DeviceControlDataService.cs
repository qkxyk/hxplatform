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
    public class DeviceControlDataService
    {
        private DeviceControlDataRepository _dcdr;
        public DeviceControlDataService()
        {
            _dcdr = new DeviceControlDataRepository();
        }

        //添加设备控制数据
        public DeviceControlDataViewModel ControlDataAdd(DeviceControlDataViewModel dcvm)
        {
            //获取相关的设备信息
            DeviceModel dm = new DeviceRepository().FindDeviceAndControlData(dcvm.DeviceSn, dcvm.Token);
            if (dm == null)
            {
                dcvm.Success = false;
                dcvm.Message = "没有相关的设备信息";
                return dcvm;
            }
            #region 验证用户是否有权限进行相关的操作
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(dcvm.Account, dcvm.Token, projectId, 1);
            if (!bRet)
            {
                dcvm.Success = false;
                dcvm.Message = "该用户没有相关的权限操作";
                return dcvm;
            }
            #endregion

            #region 验证是否重名
            DeviceControlDataModel dc = dm.DeviceControlData.Where(a => a.ControlName == dcvm.ControlName).FirstOrDefault();
            if (dc != null)
            {
                dcvm.Success = false;
                dcvm.Message = "已添加过此数据控制名称";
                return dcvm;
            }
            #endregion

            try
            {
                dc = new DeviceControlDataModel()
                {
                    ControlName = dcvm.ControlName,
                    DataDefineId = dcvm.DataDefineId,
                    DataValue = dcvm.DataValue,
                    DeviceSn = dm.DeviceSn,
                    PanelId = dcvm.PanelId
                };
                _dcdr.Add(dc);
                dcvm.Id = dc.Id;
                dcvm.Success = true;
                dcvm.Message = "添加设备数据成";
            }
            catch (Exception ex)
            {
                dcvm.Success = false;
                dcvm.Message = "添加设备控制数据失败" + ex.Message;
                return dcvm;
            }
            return dcvm;
        }

        //查看所有设备控制数据
        public DeviceControlDataListViewModel FindControlData(string account, string token, string DeviceSn)
        {
            DeviceControlDataListViewModel dclvm = new DeviceControlDataListViewModel();
            //获取相关的设备数据
            DeviceModel dm = new DeviceRepository().FindDeviceAndControlData(DeviceSn, token);
            if (dm == null)
            {
                dclvm.Success = false;
                dclvm.Message = "不存在相关的设备数据";
                return dclvm;
            }

            //验证用户是否有权限查看
            int projectId = dm.ProjectId.Value;
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                dclvm.Success = false;
                dclvm.Message = "用户无权限查看设备数据";
                return dclvm;
            }
            //获取数据
            foreach (var item in dm.DeviceControlData)
            {
                DeviceControlDataViewModel dcdm = new DeviceControlDataViewModel();
                dcdm.ControlName = item.ControlName;
                dcdm.DataDefineId = item.DataDefineId;
                dcdm.DataValue = item.DataValue;
                dcdm.PanelId = item.PanelId;
                dcdm.DeviceSn = DeviceSn;
                dclvm.list.Add(dcdm);
            }
            dclvm.Success = true;
            dclvm.Message = "获取设备控制数据成功";
            return dclvm;
        }

        public ResponseData UpdateDeviceControlData(DeviceControlDataViewModel dcdvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dcdvm.DeviceSn, dcdvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dcdvm.Account, dcdvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _dcdr.Find(dcdvm.Id);
            dv.ControlName = dcdvm.ControlName;
            dv.DataValue = dcdvm.DataValue;
            dv.DataDefineId = dcdvm.DataDefineId;
            try
            {
                _dcdr.Save(dv);
                rd.Success = true;
                rd.Message = "更新设备控制数据成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "更新设备控制数据失败";
            }
            return rd;
        }

        public ResponseData DeleteDeviceControlData(DeviceControlDataViewModel dcdvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = new DeviceService().FindDevice(dcdvm.DeviceSn, dcdvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "设备不存在";
                return rd;
            }
            #region 验证用户权限
            bool bRet = new DeviceService().CheckDeviceAuth(dm, dcdvm.Account, dcdvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion
            var dv = _dcdr.Find(dcdvm.Id);
            try
            {
                _dcdr.Remove(dv);
                rd.Success = true;
                rd.Message = "删除设备控制数据成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备控制数据失败";
            }
            return rd;
        }
    }
}
