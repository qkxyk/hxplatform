using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceImageRepository
    {
        public void Add(DeviceImageModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceImage.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceImageModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceImageModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceImageModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceImageModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public DeviceImageModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var image = db.DeviceImage.Where(a => a.Id == id).FirstOrDefault();
                return image;
            }
        }
    }
}
