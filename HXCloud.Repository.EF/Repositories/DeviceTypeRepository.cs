using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class DeviceTypeRepository
    {
        public void Add(DeviceTypeModel entity)
        {
            using (var db = new HXContext())
            {
                db.DeviceType.Add(entity);
                db.SaveChanges();
            }
        }

        public void Save(DeviceTypeModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceTypeModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Remove(DeviceTypeModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DeviceTypeModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public DeviceTypeModel Find(string name, string token)
        {
            using (var db = new HXContext())
            {
                var dtm = db.DeviceType.Where(a => a.Token == token && a.DeviceTypeName == name).FirstOrDefault();
                return dtm;
            }
        }
        public DeviceTypeModel Find(int Id)
        {
            using (var db = new HXContext())
            {
                var dtm = db.DeviceType.Find(Id);
                return dtm;
            }
        }
        public List<DeviceTypeModel> FindAll(string token)
        {
            using (var db = new HXContext())
            {
                var dtm = db.DeviceType.Where(a => a.Token == token).ToList();
                return dtm;
            }
        }

        /// <summary>
        /// 获取第二级设备类型
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<DeviceTypeModel> GetFirstLevelType(string token)
        {
            using (var db = new HXContext())
            {
                var types = db.DeviceType.Where(a => a.Parent.ParentId == null).ToList();
                return types;
            }
        }

        //循环递归查找类别下的子类别
        public IEnumerable<DeviceTypeModel> GetSonID(int p_id, string token)
        {
            using (var db = new HXContext())
            {
                var query = from c in db.DeviceType
                            where c.ParentId == p_id && c.Token == token
                            select c;
                return query.ToList().Concat(query.ToList().SelectMany(t => GetSonID(t.Id, token)));
            }
        }
    }
}
