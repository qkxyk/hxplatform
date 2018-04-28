using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.UnitOfWork.Infrastructure.Query;
using System.Data.Entity.Core.Objects;
namespace HXCloud.Repository.EF.QueryTranslators
{
    public class GroupTranslator : QueryTranslator
    {
        public ObjectQuery<GroupModel> Translate(Query query)
        {
            ObjectQuery<GroupModel> groupQuery= null;
            if (query.IsNamedQuery())
            {
                groupQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);
               // groupQuery = DataContextFactory.GetDataContext().Group;
                   // .Where(a=>a.Id=="").OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
            }
            return groupQuery;
        }

        private ObjectQuery<GroupModel> FindEFQueryFor(Query query)
        {
            throw new NotImplementedException();
        }
    }
}
