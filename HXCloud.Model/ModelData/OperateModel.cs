using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //系统操作(所有项目操作相同)，此表内容固定，其他表和此表关联设为默认(即0为查看，1为编辑，2为删除)，如后续权限验证更改，只需在此基础上进行更改
  public  class OperateModel:IAggregateRoot
    {
        public int Id { get; set; }
        public string OperateName { get; set; }
        public int TypeId { get; set; }//0为查看，1为控制，2为编辑，3为删除、添加
    }
}
