using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceDataDefineRepository
    {
        public void Add(DeviceDataDefineModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceDataDefine.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(DeviceDataDefineModel entity)
        {
            using (var db = new HXContext())
            {
                var d = db.DeviceControlData.Where(a => a.DataDefineId == entity.Id).ToList();
                db.DeviceControlData.RemoveRange(d);
                db.Entry<DeviceDataDefineModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Save(DeviceDataDefineModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceDataDefineModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public DeviceDataDefineModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var dd = db.DeviceDataDefine.Where(a => a.Id == id).FirstOrDefault();
                return dd;
            }
        }
    }
}
