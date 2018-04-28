using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceControlDataRepository
    {
        public void Add(DeviceControlDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceControlData.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceControlDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceControlDataModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceControlDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceControlDataModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public DeviceControlDataModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var dc = db.DeviceControlData.Where(a => a.Id == id).FirstOrDefault();
                return dc;
            }
        }
    }
}
