using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.UnitOfWork.Infrastructure.Query
{
    //用于表示排序属性的类OrderByClause
    public class OrderByClause
    {
        public string PropertyName { get; set; }//属性名对应数据库表的列名
        public bool Desc { get; set; }//desc or asc
    }
}
