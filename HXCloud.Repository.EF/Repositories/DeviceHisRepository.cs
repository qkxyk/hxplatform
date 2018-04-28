using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceHisRepository
    {
        public void Add(DeviceHisDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceHisData.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceHisDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceHisDataModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceHisDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceHisDataModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<DeviceHisDataModel> FindAllDeviceHis(string token)
        {
            using (var db = new HXContext())
            {
                var list = db.DeviceHisData.Include("Device").Include("Device.DeviceType").Where(a => a.Token == token).ToList();
                return list;
            }
        }

        public List<DeviceHisDataModel> FindDeviceHis(string token, string deviceSn)
        {
            using (var db = new HXContext())
            {
                var list = db.DeviceHisData.Include("Device").Include("Device.DeviceType").Where(a => a.Token == token && a.DeviceSn == deviceSn).ToList();
                return list;
            }
        }
    }
}
