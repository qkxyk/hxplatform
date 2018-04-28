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
    public class DeviceHisService
    {
        private DeviceHisRepository _dhr;
        public DeviceHisService()
        {
            _dhr = new DeviceHisRepository();
        }


        //处理设备在线数据上传信息
        public DeviceHisViewModel DeviceHisAdd(DeviceHisViewModel dovm)
        {
            //检测设备和组织是否存在，如果不存在则对数据不做处理
            DeviceModel dm = new DeviceRepository().Find(dovm.DeviceSn, dovm.Token);
            if (dm == null)
            {
                dovm.Success = false;
                dovm.Message = "不存在此设备或者组织";
                return dovm;
            }
            try
            {
                DeviceHisDataModel dom = new DeviceHisDataModel()
                { DataContent = dovm.DataContent, DataTitle = dovm.DataTitle, DeviceSn = dm.DeviceSn, Token = dovm.Token, Dt = DateTime.Now };
                _dhr.Add(dom);
                dovm.Id = dom.Id;
                dovm.Success = true;
                dovm.Message = "添加历史数据成功";
            }
            catch (Exception ex)
            {
                dovm.Success = false;
                dovm.Message = "添加设备历史数据失败" + ex.Message;
                return dovm;
            }
            return dovm;
        }

        //统计组织内的所有在线数据
        public DeviceHisListViewModel GetGroupHisData(string token, string account)
        {
            DeviceHisListViewModel dolvm = new DeviceHisListViewModel();
            List<DeviceHisDataModel> dom = new DeviceHisRepository().FindAllDeviceHis(token);
            foreach (var item in dom)
            {
                DeviceHisViewModel dovm = new DeviceHisViewModel()
                {
                    DeviceSn = item.Device.DeviceSn,
                    Dt = item.Dt,
                    DataContent = item.DataContent,
                    DataTitle = item.DataTitle,
                    Token = item.Token,
                    Id = item.Id
                };
                dolvm.list.Add(dovm);
            }
            dolvm.Success = true;
            dolvm.Message = "获取设备历史数据成功";
            return dolvm;
        }

        public DeviceHisListViewModel GetDeviceHisData(string token, string deviceSn, string account)
        {
            DeviceHisListViewModel dolvm = new DeviceHisListViewModel();
            List<DeviceHisDataModel> dom = new DeviceHisRepository().FindDeviceHis(token, deviceSn);//.FindAllDeviceHis(token);
            foreach (var item in dom)
            {
                DeviceHisViewModel dovm = new DeviceHisViewModel()
                {
                    DeviceSn = item.Device.DeviceSn,
                    Dt = item.Dt,
                    DataContent = item.DataContent,
                    DataTitle = item.DataTitle,
                    Token = item.Token,
                    Id = item.Id
                };
                dolvm.list.Add(dovm);
            }
            dolvm.Success = true;
            dolvm.Message = "获取设备历史数据成功";
            return dolvm;
        }
    }
}
