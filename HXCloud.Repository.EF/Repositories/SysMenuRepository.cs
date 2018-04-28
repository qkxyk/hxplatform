using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class SysMenuRepository
    {
        public void Add(SysMenuModel entity)
        {
            using (var db = new HXContext())
            {
                db.SysMenu.Add(entity);
                db.SaveChanges();
            }
        }

        public void Remove(SysMenuModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<SysMenuModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(SysMenuModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<SysMenuModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public SysMenuModel FindByName(string name, string token)
        {
            using (var db = new HXContext())
            {
                var m = db.SysMenu.FirstOrDefault(a => a.Name == name && a.Token == token);
                return m;
            }
        }

        public List<SysMenuModel> FindMenu(string token)
        {
            using (var db = new HXContext())
            {
                var m = db.SysMenu.Where(a => a.Token == token).ToList();
                return m;
            }
        }
        
      
    }
}
