using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class RegisterUserViewModel:ResponseBase
    {       
        public string RealName { get; set; }      
        public string Password { get; set; }        
        public string PasswordAgain { get; set; }
        public string Salt { get; set; }
        [Required]
        public string Code { get; set; }//验证码

        public string Title { get; set; }
        public string Logo { get; set; }
    }
}
