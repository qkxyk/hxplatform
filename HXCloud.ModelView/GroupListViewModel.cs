using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class GroupListViewModel : ResponseBase
    {
        public List<GroupViewModel> listGroup;
        public GroupListViewModel()
        {
            listGroup = new List<GroupViewModel>();
        }
    }
}
