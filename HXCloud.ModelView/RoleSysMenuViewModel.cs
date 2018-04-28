using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.ModelView.BaseData;

namespace HXCloud.ModelView
{
    public class RoleSysMenuViewModel : RequestData
    {
        public int RoleId { get; set; }
        public string SysMenuId { get; set; }
    }
}
