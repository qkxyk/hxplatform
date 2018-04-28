using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class OperateRepository : IOperate
    {
        public void Add(OperateModel entity)
        {
            using (var db=new HXContext())
            {
                db.Operate.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<OperateModel> FindBy()
        {
            using (var db = new HXContext())
            {
                var operate = db.Operate;
                return operate;
            }
        }

        public void Remove(OperateModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<OperateModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(OperateModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
