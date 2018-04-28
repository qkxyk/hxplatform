using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class ProjectViewModel:ResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int level { get; set; } = 0;//项目等级，等于0时可以不允许挂载其他信息，等1时可以挂载客户信息，其他等级不可以挂载客户信息
        public int Type { get; set; } = 0;//保留选项，后期约束项目行为
        public int Cate { get; set; } = 0;//保留选项
        public int ProjectType { get; set; } = 0;//项目级别,0表示主项目(推荐使用一级项目和二级项目)，1表示项目列表(可以无线嵌套，不推荐在此处挂载设备)，2表示没有子节点的项目(挂载设备节点)

        public Nullable<int> ParentId { get; set; } //父项目标识

        public string Token { get; set; }
        public Nullable<int> ClientId { get; set; }
    }
}
