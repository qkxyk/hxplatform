using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class LoginViewModel:ResponseBase
    {       
        public string Password { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }//用户登录后返回用户token
    }
}
