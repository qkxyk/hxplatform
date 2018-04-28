using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class ProjectListViewModel : ResponseBase
    {
        public ProjectListViewModel()
        {
            list = new List<ProjectViewModel>();
        }
        public List<ProjectViewModel> list { get; set; }
    }
}
