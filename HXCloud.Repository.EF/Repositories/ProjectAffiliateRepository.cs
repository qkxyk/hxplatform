using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class ProjectAffiliateRepository
    {
        public void Add(ProjectAffiliateModel entity)
        {
            using (var db = new HXContext())
            {
                db.ProjectAffiliate.Add(entity);
                db.SaveChanges();
            }
        }

        public ProjectAffiliateModel Find(int id)
        {
            using (var db = new HXContext())
            {
                var affiliate = db.ProjectAffiliate.Where(a => a.Id == id).Single();
                return affiliate;
            }
        }

        public List<ProjectAffiliateModel> FindBy(int projectId)
        {
            using (var db = new HXContext())
            {
                var affiliates = db.ProjectAffiliate.Where(a => a.ProjectId == projectId).ToList();
                return affiliates;
            }
        }
        public ProjectAffiliateModel FindBy(int projectId, string name)
        {
            using (var db = new HXContext())
            {
                var affiliates = db.ProjectAffiliate.Where(a => a.ProjectId == projectId && a.AffiliateName == name).FirstOrDefault();
                return affiliates;
            }
        }

        public void Remove(ProjectAffiliateModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<ProjectAffiliateModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Save(ProjectAffiliateModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
