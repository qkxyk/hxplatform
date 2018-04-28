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
    public class DeviceAlarmService
    {
        private DeviceAlarmRepository _dar;
        public DeviceAlarmService()
        {
            _dar = new DeviceAlarmRepository();
        }

        //处理设备报警数据上传信息
        public DeviceAlarmViewModel DeviceAlarmAdd(DeviceAlarmViewModel dovm)
        {
            //检测设备和组织是否存在，如果不存在则对数据不做处理
            DeviceModel dm = new DeviceRepository().FindDeviceAndDeviceAlarm(dovm.DeviceSn, dovm.Token);
            if (dm == null)
            {
                dovm.Success = false;
                dovm.Message = "不存在此设备或者组织";
                return dovm;
            }
            try
            {                
                DeviceAlarmModel dom = new DeviceAlarmModel()
                {  AlarmDesc= dovm.AlarmDesc, AlarmTitle = dovm.AlarmTitle, DeviceSn= dm.DeviceSn, Token = dovm.Token, Dt= DateTime.Now };
                _dar.Add(dom);
                dovm.Success = true;
                dovm.Message = "添加报警数据成功";
            }
            catch (Exception ex)
            {
                dovm.Success = false;
                dovm.Message = "添加设备报警数据失败" + ex.Message;
                return dovm;
            }
            return dovm;
        }

        //统计组织内的所有在线数据
        public DeviceAlarmListViewModel GetGroupDeviceAlarm(string token)
        {
            DeviceAlarmListViewModel dolvm = new DeviceAlarmListViewModel();
            List<DeviceAlarmModel> dom = new DeviceAlarmRepository().FindAllDeviceAlarm(token);
            foreach (var item in dom)
            {
                DeviceAlarmViewModel dovm = new DeviceAlarmViewModel() { DeviceSn = item.Device.DeviceSn, Dt =item.Dt, TypeId = item.Device.TypeId, Comment= item.Comment,
                 AlarmTitle = item.AlarmTitle, AlarmDesc= item.AlarmDesc, HandleDt= item.HandleDt, Handler = item.Handler};
                dolvm.list.Add(dovm);
            }
            dolvm.Success = true;
            dolvm.Message = "获取在线设备成功";
            return dolvm;
        }
    }
}
