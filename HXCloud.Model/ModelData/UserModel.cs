using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public class UserModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string Account { get; set; }//手机号或者邮箱
        public string UserName { get; set; }//用户名称
        public string Password { get; set; }
        public string Picture { get; set; }
        public DateTime? LastLogin { get; set; } = DateTime.Now;
        public int Valide { get; set; } = 0;//0为注册时默认的状态未激活状态，1为有效的用户，2为无效用户(因某种原因用户失效)
        public bool bSex { get; set; } = true;
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        //public string Email { get; set; }
        // public string Mobile { get; set; }
        public string Salt { get; set; }//用户加密的密钥
        public string remark { get; set; }
       
        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }

        public virtual UserRoleModel UserRole { get; set; }//系统规定一个用户只能属于一个角色
    }
}
