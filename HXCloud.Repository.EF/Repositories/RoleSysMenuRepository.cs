using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class RoleSysMenuRepository
    {
        #region 增删改
        public void Add(RoleSysMenuModel entity)
        {
            using (var db = new HXContext())
            {
                db.RoleSysMenu.Add(entity);
                db.SaveChanges();
            }
        }

        public void Remove(RoleSysMenuModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<RoleSysMenuModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(RoleSysMenuModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion


    }
}
