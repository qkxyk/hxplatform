using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
   public class DeviceTypeViewModel:ResponseBase
    {
        public int Id { get; set; }//设备类型标识
        public string DeviceTypeName { get; set; }//设备类型名称
        public int? ParentId { get; set; } = 0;//设备所属的父类型标识
        public string Description { get; set; }//设备类型描述
     
        public string Token { get; set; }
    }
}
