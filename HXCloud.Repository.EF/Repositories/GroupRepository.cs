using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.Common;

namespace HXCloud.Repository.EF.Repositories
{
    public class GroupRepository : IGroup
    {
        //添加组织
        public void Add(GroupModel entity, string account)
        {
            //DataContextFactory.GetDataContext().Group.Add(entity);
            using (var db = new HXContext())
            {
                //1、生成组织，2、创建该组织的管理员角色，3、修改用户的组织,4、添加该用户为该组织的管理员角色               
                //生成id
                entity.Id = EncryptData.CreateUUID();
                db.Group.Add(entity);
                RoleModel rm = new RoleModel() { IsAdmin = 1, RoleName = "admin", Token = entity.Id };
                db.Role.Add(rm);
                UserModel um = new UserRepository().Find(account);//.GetUserInfo(gvm.UserName);
                um.Token = entity.Id;
                db.Entry<UserModel>(um).State = System.Data.Entity.EntityState.Modified;
                UserRoleModel urm = new UserRoleModel();
                urm.Role = rm;
                //urm.User = um;
                urm.UserId = um.Id;
                db.UserRole.Add(urm);
                db.SaveChanges();
            }
        }
        //查找组织
        public GroupModel Find(string id)
        {
            using (var db = new HXContext())
            {
                var group = db.Group.Find(id);
                return group;
            }
        }
        //查找组织
        public IEnumerable<GroupModel> FindBy(string query)
        {
            using (var db = new HXContext())
            {
                var group = db.Group.Where(a => a.GroupName.Contains(query)).ToList();
                return group;
            }
        }

        public GroupModel FindByName(string name)
        {
            using (var db = new HXContext())
            {
                var group = db.Group.Where(a => a.GroupName == name).FirstOrDefault();
                return group;
            }
        }

        public IEnumerable<GroupModel> FindBy(string query, int pageSize, int pageCount)
        {
            throw new NotImplementedException();
        }
        //删除组织
        public void Remove(GroupModel entity)
        {
            throw new NotImplementedException();
        }
        //修改组织
        public void Save(GroupModel entity)
        {
            using (var db = new HXContext())
            {
                //方法1
                db.Entry<GroupModel>(entity).State = System.Data.Entity.EntityState.Modified;
                //方法2，通过查询再修改
                //var group = db.Group.Where(a => a.Id == entity.Id).Single();
                //group.GroupName = entity.GroupName;
                db.SaveChanges();
            }
        }
    }
}
