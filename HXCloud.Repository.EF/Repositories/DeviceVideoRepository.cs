using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceVideoRepository
    {
        public void Add(DeviceVideoModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceVideo.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceVideoModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceVideoModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceVideoModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceVideoModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public DeviceVideoModel Find(int Id)
        {
            using (var db= new HXContext())
            {
                var dv = db.DeviceVideo.Where(a => a.Id == Id).FirstOrDefault();
                return dv;
            }
        }
    }
}
