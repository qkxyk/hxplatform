using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Repository.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            repository.PersistUpdateOf(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            repository.PersistCreationOf(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            repository.PersistDeletionOf(entity);
        }
        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }
    }
}
