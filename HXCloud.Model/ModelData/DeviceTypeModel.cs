using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    //设备类型（可分多层级）
    public class DeviceTypeModel : IAggregateRoot
    {
        public int Id { get; set; }//设备类型标识
        public string DeviceTypeName { get; set; }//设备类型名称
        public Nullable<int> ParentId { get; set; } = 0;//设备所属的父类型标识
        public string Description { get; set; }//设备类型描述

        public virtual DeviceTypeModel Parent { get; set; }//设备类型关联的父设备类型
        public virtual ICollection<DeviceTypeModel> Child { get; set; }//设备类型关联的子设备类型

        public virtual ICollection<DeviceModel> Device { get; set; }
        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }
    }
}
