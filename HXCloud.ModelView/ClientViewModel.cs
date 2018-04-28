using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class ClientViewModel : ResponseBase
    {
       // public ClientBaseViewModel cbvm { get; set; }
        
        public int Id { get; set; }
        public string ClientSn { get; set; }//客户编号，编号可以用来对接其他系统
        public string ClientName { get; set; }//客户名称
        public string Linkman { get; set; }//联系人
        public string Telephone { get; set; }//联系电话
        public string Mobile { get; set; }//移动电话
        public string Address { get; set; }//客户地址
        public string Description { get; set; }//客户描述
        public string Token { get; set; }
        
    }
}
