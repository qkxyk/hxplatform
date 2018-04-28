using HXCloud.UnitOfWork.Infrastructure.Query;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace HXCloud.Repository.EF.QueryTranslators
{
    public class QueryTranslator
    {
        public void CreateQueryAndObjectParameters(Query query,StringBuilder queryBuilder,IList<ObjectParameter>paraColl)
        {
            foreach (var item in query.Criteria)
            {
                switch (item.CriteriaOperator)
                {
                    case CriteriaOperator.Equal:
                        queryBuilder.Append(String.Format("it.{0}=@{0}", item.PropertyName));
                        break;
                    case CriteriaOperator.LessThanOrEqual:
                        queryBuilder.Append(String.Format("it.{0}<=@{0}", item.PropertyName));
                        break;
                    //case CriteriaOperator.NotApplicable:
                    //    break;
                    case CriteriaOperator.LessThan:
                        queryBuilder.Append(String.Format("it.{0}<@{0}", item.PropertyName));
                        break;
                    case CriteriaOperator.GreaterThan:
                        queryBuilder.Append(String.Format("it.{0}>@{0}", item.PropertyName));
                        break;
                    case CriteriaOperator.GreaterThanOrEqual:
                        queryBuilder.Append(String.Format("it.{0}>=@{0}", item.PropertyName));
                        break;
                    case CriteriaOperator.Like:
                        queryBuilder.Append(String.Format("it.{0} like @{0}", item.PropertyName));
                        break;
                    default:
                        throw new ApplicationException("not operator defined");
                }
                paraColl.Add(new ObjectParameter(item.PropertyName, item.Value));
            }
        }
    }
}
