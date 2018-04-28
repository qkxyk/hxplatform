using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class ClientRepository : IClient
    {
        public void Add(ClientModel entity)
        {
            using (var db = new HXContext())
            {
                db.Client.Add(entity);
                db.SaveChanges();
            }
        }

        public void Remove(ClientModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<ClientModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                //需要设置客户管理的项目信息为Null
                var c = db.Project.Where(a => a.ClientId == entity.Id);
                foreach (var item in c)
                {
                    item.ClientId = null;
                }
                db.SaveChanges();
            }
        }

        public void Save(ClientModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<ClientModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<ClientModel> FindAll(string token)
        {
            using (var db = new HXContext())
            {
                var dtm = db.Client.Where(a => a.Token == token).ToList();
                return dtm;
            }
        }

        public ClientModel Find(int Id)
        {
            using (var db = new HXContext())
            {
                var client = db.Client.Find(Id);
                return client;
            }
        }
    }
}
