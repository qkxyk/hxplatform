using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class ProjectAddViewModel : ResponseBase
    {
        public string Token { get; set; }
        public string ProjectName { get; set; }
        public int ParentId { get; set; }
        public int ProjectType { get; set; }
    }
}
