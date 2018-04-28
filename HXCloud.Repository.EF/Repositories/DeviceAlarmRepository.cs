using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceAlarmRepository
    {
        public void Add(DeviceAlarmModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceAlarm.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceAlarmModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceAlarmModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceAlarmModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceAlarmModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<DeviceAlarmModel> FindAllDeviceAlarm(string token)
        {
            using (var db = new HXContext())
            {
                var list = db.DeviceAlarm.Include("Device").Include("Device.DeviceType").Where(a => a.Token == token).ToList();
                return list;
            }
        }
        public List<DeviceAlarmModel> FindDeviceAlarm(string token, string deviceSn)
        {
            using (var db = new HXContext())
            {
                var list = db.DeviceAlarm.Include("Device").Include("Device.DeviceType").Where(a => a.Token == token && a.DeviceSn == deviceSn).ToList();
                return list;
            }
        }
    }
}
