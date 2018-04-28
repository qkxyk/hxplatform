using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class GroupViewModel:ResponseBase
    {
        public string Token { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }
}
