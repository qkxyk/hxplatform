using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HXCloud.ModelView
{
    public class RoleListViewModel : ResponseBase
    {
        public RoleListViewModel()
        {
            list = new List<RoleViewModel>();
        }
        public List<RoleViewModel> list { get; set; }
    }
}
