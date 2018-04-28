using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.UnitOfWork.Infrastructure.Query;
using System.Data.Entity.Core.Objects;
using HXCloud.UnitOfWork.Infrastructure;

namespace HXCloud.Repository.EF.Repositories
{
    public class GroupRepositorybak : IUnitOfWorkRepository, IRepositoryBak<GroupModel>
    {
        private IUnitOfWork _uow;
        public GroupRepositorybak(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(GroupModel entity)
        {
            _uow.RegisterNew(entity,this);
        }

        public GroupModel Find(Query query)
        {
            throw new NotImplementedException();
        }

        public GroupModel Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupModel> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupModel> FindBy(Query query, int pageSize, int pageCount)
        {
            throw new NotImplementedException();
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            //DataContextFactory.GetDataContext().Group.Add(entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            //DataContextFactory.GetDataContext().Group.Remove(entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            //DataContextFactory.GetDataContext().Group.sta
            //this._db.Entry(item).State = EntityState.Modified;
            //DataContextFactory.GetDataContext().Entry<GroupModel>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Remove(GroupModel entity)
        {
            _uow.RegisterRemoved(entity, this);
        }

        public void Save(GroupModel entity)
        {
            _uow.RegisterAmended(entity, this);
        }
    }
}
