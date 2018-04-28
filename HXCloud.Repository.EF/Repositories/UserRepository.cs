using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class UserRepository : IUser
    {
        public UserModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var user = db.User.Where(a => a.Id == id).Single();
                return user;
            }
        }

        public UserModel Find(string user, string password)
        {
            using (var db = new HXContext())
            {
                var entity = db.User.Where(a => a.Account == user && a.Password == password).Single();
                //var e = from it in db.User where it.UserName == user && it.Password == password select it;
                return entity;
            }
        }
        public UserModel Find(string user)
        {
            using (var db = new HXContext())
            {
                var entity = db.User.Include("userrole").Include("userrole.role").Include("userrole.role.roleproject").Where(a => a.Account == user).SingleOrDefault();
                return entity;
            }
        }

        public UserModel FindByUserAndToken(string account,string token)
        {
            using (var db = new HXContext())
            {
                var entity = db.User.Include("userrole").Include("userrole.role").Include("userrole.role.roleproject").Where(a => a.Account == account&&a.Token==token).Single();
                return entity;
            }
        }
        //public UserModel Find(string user,string token)
        //{
        //    using (var db= new HXContext())
        //    {
        //        var entity = db.User.Include("userrole")
        //    }
        //}
        public IEnumerable<UserModel> FindBy(string query)
        {
            using (var db= new HXContext())
            {
                IEnumerable<UserModel> users = db.User.Where(a => a.Account == query).ToList();
                return users;
            }
        }

        public IEnumerable<UserModel> FindBy(string query, int pageSize, int pageCount)
        {
            using (var db = new HXContext())
            {
                IEnumerable<UserModel> users = db.User.Where(a => a.Token == query).Skip((pageCount-1)*pageSize).Take(pageSize).ToList();
                return users;
            }
        }
        #region 增删改
        public void Add(UserModel entity)
        {
            using (var db = new HXContext())
            {
                db.User.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(UserModel entity)
        {
            using (var db = new HXContext())
            {
                //方法1
                db.Entry<UserModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                //方法2
                //db.User.Attach(entity);
                //db.User.Remove(entity);
                //方法3 先查询再删除
                //var user = db.User.Where(a => a.Id == entity.Id).Single();
                //db.User.Remove(user);
                db.SaveChanges();
            }
        }

        public void Save(UserModel entity)
        {
            using (var db = new HXContext())
            {
                //方法1
                db.Entry<UserModel>(entity).State = System.Data.Entity.EntityState.Modified;
                //方法2，通过查询再修改
                //var user = db.User.Where(a => a.Id == entity.Id).Single();
                //uer.Name = entity.Name;
                db.SaveChanges();
            }
        }

        #endregion
    }
}
