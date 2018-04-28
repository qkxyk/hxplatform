using HXCloud.UnitOfWork.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Model
{
    public interface IRepositoryBak<T> where T: IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);

        T Find(object id);
        T Find(Query query);
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int pageSize, int pageCount);
    }
}
