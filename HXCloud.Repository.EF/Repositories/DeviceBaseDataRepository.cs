using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceBaseDataRepository
    {
        public void Add(DeviceBaseDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceBaseData.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceBaseDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceBaseDataModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceBaseDataModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceBaseDataModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public DeviceBaseDataModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var d = db.DeviceBaseData.Where(a => a.Id == id).FirstOrDefault();
                return d;
            }
        }
    }
}
