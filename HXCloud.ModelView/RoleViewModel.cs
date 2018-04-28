using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class RoleViewModel:ResponseBase
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int IsAdmin { get; set; } = 0;//是否是管理员

        public string Token { get; set; }//标示该角色属于那个团队
    }
}
