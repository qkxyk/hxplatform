using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class ProjectAffiliateListViewModel:ResponseBase
    {
        public ProjectAffiliateListViewModel()
        {
            list = new List<ProjectAffiliateViewModel>();
        }
        public List<ProjectAffiliateViewModel> list { get; set; }
    }
}
