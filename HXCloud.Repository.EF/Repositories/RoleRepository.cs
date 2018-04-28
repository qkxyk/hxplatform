using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class RoleRepository : IRole
    {
        public RoleModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var role = db.Role.Where(a => a.Id == id).Single();
                return role;
            }
        }

        public IEnumerable<RoleModel> FindBy(string query)
        {
            using (var db = new HXContext())
            {
                var roles = db.Role.Where(a => a.Token == query).ToList();
                return roles;
            }
        }

        public IEnumerable<RoleModel> FindBy(string query, int pageSize, int pageCount)
        {
            using (var db = new HXContext())
            {
                var roles = db.Role.Where(a => a.Token == query).Skip((pageCount - 1) * pageCount).Take(pageCount).ToList();
                return roles;
            }
        }
        #region 增删改
        public void Add(RoleModel entity)
        {
            using (var db = new HXContext())
            {
                db.Role.Add(entity);
                db.SaveChanges();
            }
        }



        public void Remove(RoleModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<RoleModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(RoleModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<RoleModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion

        public RoleModel FindUserRole(string account, string token)
        {
            using (var db = new HXContext())
            {
                var user = db.User.FirstOrDefault(a => a.Account == account && a.Token == token);
                var roleId = db.UserRole.FirstOrDefault(a => a.UserId == user.Id);
                var r = db.Role.Where(a => a.Id == roleId.RoleId).FirstOrDefault();
                return r;
            }
        }
    }
}
