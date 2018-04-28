using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //项目或者场站添加附属属性
    public class ProjectAffiliateModel : IAggregateRoot
    {
        public int Id { get; set; }
        public string AffiliateName { get; set; }
        public string AffiliateValue { get; set; }

        public int ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }
        
    }
}
