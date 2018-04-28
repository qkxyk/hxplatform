using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.ModelView.BaseData;

namespace HXCloud.ModelView
{
    public class SysMenuListViewModel : ResponseData
    {
        public SysMenuListViewModel()
        {
            list = new List<SysMenuViewModel>();
        }
        public List<SysMenuViewModel> list { get; set; }
    }
}
