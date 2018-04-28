using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
   public class ProjectAffiliateModelMap:EntityTypeConfiguration<ProjectAffiliateModel>
    {
        public ProjectAffiliateModelMap()
        {
            ToTable("ProjectAffiliate").HasKey(a => a.Id);
            //1对多关系
            HasRequired(a => a.Project).WithMany(a => a.ProjectAffiliate).HasForeignKey(a => a.ProjectId);
        }
    }
}
