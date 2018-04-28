using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HXCloud.UnitOfWork.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;
        public UnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!changedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, repository);
            }
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, repository);
            }
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity, repository);
            }
        }
        public void Commit()
        {
            using (var scope = new TransactionScope())
            {
                foreach (IAggregateRoot item in addedEntities.Keys)
                {
                    addedEntities[item].PersistCreationOf(item);
                }
                foreach (var item in changedEntities.Keys)
                {
                    changedEntities[item].PersistUpdateOf(item);
                }
                foreach (var item in deletedEntities.Keys)
                {
                    deletedEntities[item].PersistDeletionOf(item);
                }
                scope.Complete();
            }
        }
    }
}
