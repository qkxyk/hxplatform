using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class ProjectAffiliateViewModel : ResponseBase
    {
        public int Id { get; set; }
        public string AffiliateName { get; set; }
        public string AffiliateValue { get; set; }
        //public string 
        public int ProjectId { get; set; }
        public string Token { get; set; }
    }
}
