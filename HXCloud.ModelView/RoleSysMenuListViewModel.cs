using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.ModelView.BaseData;

namespace HXCloud.ModelView
{
    public class RoleSysMenuListViewModel : ResponseData
    {
        public RoleSysMenuListViewModel()
        {
            list = new List<RoleSysMenuViewModel>();
        }
        public List<RoleSysMenuViewModel> list { get; set; }
    }
}
