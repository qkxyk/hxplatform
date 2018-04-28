using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceOnlineRepository
    {
        
        public void Add(DeviceOnlineModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceOnline.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceOnlineModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceOnlineModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceOnlineModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceOnlineModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<DeviceOnlineModel> FindAllDeviceOnline(string token)
        {
            using (var db = new HXContext())
            {
                var list = db.DeviceOnline.Include("Device").Include("Device.DeviceType").Where(a => a.Token == token).ToList();
                return list;
            }
        }
        
    }
}
