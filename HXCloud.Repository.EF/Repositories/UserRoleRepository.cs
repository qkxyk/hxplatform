using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class UserRoleRepository : IUserRole
    {

        public void Add(UserRoleModel entity)
        {
            using (var db = new HXContext())
            {
                db.UserRole.Add(entity);
                db.SaveChanges();
            }
        }

        public void Remove(UserRoleModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<UserRoleModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(UserRoleModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<UserRoleModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public UserRoleModel FindUserRole(UserRoleModel entity)
        {
            using (var db = new HXContext())
            {

                var userRole = db.UserRole.Where(a => a.UserId == entity.UserId && a.RoleId == entity.RoleId).FirstOrDefault();
                return userRole;
            }
        }

    }
}
