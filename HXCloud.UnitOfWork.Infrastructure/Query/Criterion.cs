using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.UnitOfWork.Infrastructure.Query
{
    //查询过滤器(指定一个实体属性，进行比较的值及比较方式)
    public class Criterion
    {
        private string _propertyName;//实体属性
        private object _value;//进行比较的值
        private CriteriaOperator _criteriaOperator;//比较操作符 

        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }
        public object Value
        {
            get { return _value; }
        }
        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
        }
    }
}
