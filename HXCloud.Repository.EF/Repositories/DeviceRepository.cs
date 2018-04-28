using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Common;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceRepository
    {
        public void Add(DeviceModel entity)
        {
            using (var db = new HXContext())
            {
                db.Device.Add(entity);
                //添加设备数据面板
                //DevicePanelModel dpm = new DevicePanelModel();
                //dpm.Device = entity;
                //dpm.PanelName = "数据定义";
                //db.DevicePanel.Add(dpm);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Remove(string sn)
        {
            using (var db = new HXContext())
            {
                //先删除关联的设备信息
                var dbd = db.DeviceBaseData.Where(a => a.DeviceSn == sn).ToList();
                foreach (var item in dbd)
                {
                    db.DeviceBaseData.Remove(item);
                }
                var ddp = db.DevicePanel.Where(a => a.DeviceSn == sn).ToList();
                db.DevicePanel.RemoveRange(ddp);
                var ddd = db.DeviceDataDefine.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceDataDefine.RemoveRange(ddd);
                var dcd = db.DeviceControlData.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceControlData.RemoveRange(dcd);
                var dv = db.DeviceVideo.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceVideo.RemoveRange(dv);
                var di = db.DeviceImage.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceImage.RemoveRange(di);
                var dm = db.DeviceMap.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceMap.RemoveRange(dm);
                var dh = db.DeviceHisData.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceHisData.RemoveRange(dh);
                var da = db.DeviceAlarm.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceAlarm.RemoveRange(da);
                var don = db.DeviceOnline.Where(a => a.DeviceSn == sn).ToList();
                db.DeviceOnline.RemoveRange(don);

                var d = db.Device.Where(a => a.DeviceSn == sn).ToList();
                db.Device.RemoveRange(d);
                db.SaveChanges();
            }
        }
        public void Save(DeviceModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 查找同一个项目下的设备
        /// </summary>
        /// <param name="token">组织名称</param>
        /// <param name="name">设备名称</param>
        /// <param name="projectId">设备所属的项目</param>
        /// <returns>返回第一个设备</returns>
        public DeviceModel Find(string token, string name, int projectId)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Where(a => a.Token == token && a.ProjectId == projectId && a.DeviceName == name).FirstOrDefault();
                return dev;
            }
        }

        /// <summary>
        /// 获取组织下设备的
        /// </summary>
        /// <param name="Id">设备编号</param>
        /// <param name="token">组织编号</param>
        /// <param name="projectId">叶子项目</param>
        /// <returns></returns>
        public DeviceModel FindByDeviceSn(string deviceSn, string token, int projectId)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Where(a => a.Token == token && a.DeviceSn == deviceSn && a.ProjectId == projectId).FirstOrDefault();
                return dev;
            }
        }

        /// <summary>
        /// 根据设备的序列号查找设备
        /// </summary>
        /// <param name="sn">设备序列号</param>
        /// <param name="token">组织编号</param>
        /// <returns>返回查找的设备信息</returns>
        public DeviceModel Find(string sn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Where(a => a.Token == token && a.DeviceSn == sn).FirstOrDefault();
                return dev;
            }
        }

        public int FindByDeviceNo(string deviceNo, string token)
        {
            using (var db = new HXContext())
            {
                var d = db.Device.Where(a => a.Token == token && a.DeviceNo == deviceNo).Count();
                return d;
            }
        }

        public DeviceModel FindDeviceAndPanel(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndDataDefine(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Include("DeviceDataDefine").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndBaseData(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Include("DeviceBaseData").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndImage(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Include("DeviceImage").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndVideo(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Include("DeviceVideo").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndControlData(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Include("DeviceControlData").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndDeviceMap(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DevicePanel").Include("DeviceMap").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndDeviceOnline(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DeviceOnline").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }


        public DeviceModel FindDeviceAndDeviceAlarm(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DeviceAlarm").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        public DeviceModel FindDeviceAndDeviceHis(string deviceSn, string token)
        {
            using (var db = new HXContext())
            {
                var dev = db.Device.Include("DeviceHis").Where(a => a.Token == token && a.DeviceSn == deviceSn).FirstOrDefault();
                return dev;
            }
        }

        /// <summary>
        /// 获取叶子项目下的所有设备
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<DeviceModel> Find(int projectId, string token)
        {
            using (var db = new HXContext())
            {
                var devs = db.Device.Where(a => a.Token == token && a.ProjectId == projectId).ToList();
                return devs;
            }
        }

        /// <summary>
        /// 把设备按类型进行归类
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Dictionary<int, int> DeviceGroupType(string token)
        {
            using (var db = new HXContext())
            {
                var l = db.Device.GroupBy(a => a.TypeId).ToDictionary(a => a.Key, a => a.Count());
                return l;
            }
        }
    }
}
