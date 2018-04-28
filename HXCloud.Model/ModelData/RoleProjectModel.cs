using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //角色权限(给子项目添加权限时默认为上级项目添加查看权限)
    public class RoleProjectModel : IAggregateRoot
    {
        // public int Id { get; set; }
        public int RoleId { get; set; }
        public int ProjectId { get; set; }
        public RoleProject TypeId { get; set; }//0为查看，1为编辑，2为删除

        public virtual RoleModel Role { get; set; }//角色
        public virtual ProjectModel Project { get; set; }//项目
    }

    public enum RoleProject
    {
        查看,
        控制,
        编辑,
        删除
    }
}
