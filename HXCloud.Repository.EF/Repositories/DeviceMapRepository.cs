using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceMapRepository
    {
        public void Add(DeviceMapModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceMap.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceMapModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceMapModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceMapModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceMapModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
