using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class ProjectRepository : IProject
    {
        public void Add(ProjectModel entity)
        {
            using (var db = new HXContext())
            {
                db.Project.Add(entity);
                db.SaveChanges();
            }
        }

        public ProjectModel Find(int id)
        {
            using (var db = new HXContext())
            {
                //查询项目的相关信息
                var menu = db.Project.Where(a => a.Id == id).SingleOrDefault();
                return menu;
            }
        }
        public ProjectModel Find(int id, string token)
        {
            using (var db = new HXContext())
            {
                //查询项目的相关信息
                var menu = db.Project.Where(a => a.Id == id && a.Token == token).SingleOrDefault();
                return menu;
            }
        }
        public List<ProjectModel> FindByParentId(int id, string token)
        {
            using (var db = new HXContext())
            {
                //查询项目的相关信息
                //左连接查询数据(客户信息有可能不存在)
                //from u in Users
                //join s in Salaries on u.Id equals s.UserId into NewSalaries
                //from n in NewSalaries.DefaultIfEmpty()
                //select new
                //{
                //    u.Id,
                //    u.Name,
                //    Content = n == null ? 0 : n.Content
                //}
                //var mm = db.Project.Join(db.Client, a => a.ClientId, g => g.Id, (a, g) => a).Where(a => a.ParentId == id && a.Token == token);
                //var mm = from m in db.Menu join c in db.Client on m.ClientId equals c.Id into newMenu from mc in newMenu.DefaultIfEmpty() select mc;
                //var menu = db.Menu.Include("a=>Client").Where(a => a.ParentId == id && a.Token == token).ToList();
                var mm = db.Project.Where(a => a.ParentId == id && a.Token == token);
                return mm.ToList();
            }
        }
        public List<ProjectModel> FindMainMenu(string token)
        {
            using (var db = new HXContext())
            {
                var menu = db.Project.Where(a => a.Token == token && a.ParentId == null).ToList();
                return menu;
            }
        }
        public List<ProjectModel> FindUserMenu(string token)
        {
            using (var db = new HXContext())
            {
                var menu = db.Project.Where(a => a.Token == token && a.ProjectType == ProjectType.项目).ToList();
                return menu;
            }
        }
        public ProjectModel FindMenuAndChild(int id, string token)
        {
            using (var db = new HXContext())
            {
                //查询项目的相关信息
                var menu = db.Project.Include("Child").Where(a => a.Id == id && a.Token == token).Single();
                return menu;
            }
        }

        //获取所有一级项目列表
        public List<ProjectModel> FindMenuByType(string token, int typeId = 1)
        {
            using (var db = new HXContext())
            {
                var menu = db.Project.Where(a => a.Token == token && a.ProjectType == (ProjectType)typeId && a.Parent.Type == 0).ToList();
                return menu;
            }
        }
        /// <summary>
        /// 非终端项目不能重名
        /// </summary>
        /// <param name="name">项目名称</param>
        /// <param name="token">组织标示</param>
        /// <returns>返回重复的项目</returns>
        public ProjectModel FindByName(ProjectModel m)
        {
            ProjectModel mm = null;
            using (var db = new HXContext())
            {
                //终端节点（同于一个非终端下的终端节点不能重名，不同非终端节点下面的终端节点可以重名）
                if (m.ProjectType == (ProjectType)2)
                {
                    mm = db.Project.Where(a => a.ProjectName == m.ProjectName && a.Token == m.Token && a.ProjectType == (ProjectType)2 && a.ParentId == m.ParentId).FirstOrDefault();
                }
                else//非终端节点不能重名
                {
                    mm = db.Project.Where(a => a.ProjectName == m.ProjectName && a.Token == m.Token && a.ProjectType != (ProjectType)2).FirstOrDefault();
                }
                return mm;
            }
        }

        public void Remove(ProjectModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<ProjectModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(ProjectModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<ProjectModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }


    }
}
