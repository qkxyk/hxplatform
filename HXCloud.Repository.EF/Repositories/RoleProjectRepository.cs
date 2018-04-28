using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class RoleProjectRepository : IRoleProject
    {
        public void Add(RoleProjectModel entity)
        {
            using (var db = new HXContext())
            {
                db.RoleProject.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<RoleProjectModel> FindBy(int roleId)
        {
            using (var db = new HXContext())
            {
                var roleMenus = db.RoleProject.Where(a => a.RoleId == roleId).ToList();
                return roleMenus;
            }
        }

        public void Add(RoleModel roleModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(RoleProjectModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<RoleProjectModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(RoleProjectModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<RoleProjectModel>(entity).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
