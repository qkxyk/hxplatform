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
    public class DeviceOnlineService
    {
        private DeviceOnlineRepository _dor;
        public DeviceOnlineService()
        {
            _dor = new DeviceOnlineRepository();
        }
        
        //处理设备在线数据上传信息
        public DeviceOnlineViewModel DeviceOnlineAdd(DeviceOnlineViewModel dovm)
        {
            //检测设备和组织是否存在，如果不存在则对数据不做处理
            DeviceModel dm = new DeviceRepository().FindDeviceAndDeviceOnline(dovm.DeviceSn, dovm.Token);
            if (dm == null)
            {
                dovm.Success = false;
                dovm.Message = "不存在此设备或者组织";
                return dovm;
            }
            try
            {
                //如果不存在此设备的数据，则添加设备数据，不存在则修改数据
                DeviceOnlineModel dom = new DeviceOnlineModel() { DataContent = dovm.DataContent, DataTitle = dovm.DataContent, dt = DateTime.Now, DeviceSn = dm.DeviceSn, Token = dovm.Token };
                if (dm.DeviceOnline == null)
                {
                    _dor.Add(dom);
                }
                else
                {
                    _dor.Save(dom);
                }
            }
            catch (Exception ex)
            {
                dovm.Success = false;
                dovm.Message = "添加设备在线数据失败" + ex.Message;
                return dovm;
            }
            dovm.Success = true;
            dovm.Message = "添加设备在线数据成功";
            return dovm;
        }

        //统计组织内的所有在线数据
        public DeviceOnlineListViewModel GetGroupOnlineDevice(string token)
        {
            DeviceOnlineListViewModel dolvm = new DeviceOnlineListViewModel();
            List<DeviceOnlineModel> dom = new DeviceOnlineRepository().FindAllDeviceOnline(token);
            foreach (var item in dom)
            {
                DeviceOnlineViewModel dovm = new DeviceOnlineViewModel() { DeviceSn = item.Device.DeviceSn, dt = item.dt,TypeId= item.Device.TypeId };
                dolvm.list.Add(dovm);
            }
            dolvm.Success = true;
            dolvm.Message = "获取在线设备成功";
            return dolvm;
        }
        
    }
}
