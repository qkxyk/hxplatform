using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.UnitOfWork.Infrastructure.Query
{
    //用来组合查询条件(Criterion)、查询条件连字符(QueryOperator)，排序(OrderByClause)
    public class Query
    {
        private QueryName _name;
        private IList<Criterion> _criteria;//查询条件

        public Query() : this(QueryName.Dynamic, new List<Criterion>())
        {
        }
        public Query(QueryName name, IList<Criterion> criteria)
        {
            _name = name;
            _criteria = criteria;
        }
        public QueryName Name
        {
            get { return _name; }
        }

        /// <summary>
        /// 判断是存储过程还是动态sql
        /// </summary>
        /// <returns></returns>
        public bool IsNamedQuery()
        {
            return Name != QueryName.Dynamic;
        }

        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }

        public void Add(Criterion criterion)
        {
            if (!IsNamedQuery())
            {
                _criteria.Add(criterion);
            }
            else
            {
                throw new ApplicationException("You cannot add additional criteria to named queries");
            }
        }
        //查询条件连字符
        public QueryOperator QueryOperator
        {
            get;
            set;
        }
        //排序列
        public OrderByClause OrderByProperty
        {
            get;
            set;
        }
    }
}
