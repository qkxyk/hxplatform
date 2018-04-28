using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace HXCloud.Model
{
    public class UserRoleModel:IAggregateRoot
    {    
        [Key]    
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual UserModel User { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}
