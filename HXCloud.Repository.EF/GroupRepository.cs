using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.UnitOfWork.Infrastructure;
using HXCloud.UnitOfWork.Infrastructure.Query;

namespace HXCloud.Repository.EF
{
    public class GroupRepository : IRepositoryBak<GroupModel>, IUnitOfWorkRepository
    {
        private IUnitOfWork _unitOfWork;
        public GroupRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region 持久化
        public void PersistCreationOf(IAggregateRoot entity)
        {
           
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            
        }
        #endregion
        public void Add(GroupModel entity)
        {
            _unitOfWork.RegisterNew(entity, this);
        }
        public void Remove(GroupModel entity)
        {
            _unitOfWork.RegisterRemoved(entity, this);
        }

        public void Save(GroupModel entity)
        {
            _unitOfWork.RegisterAmended(entity, this);
        }

        public GroupModel Find(object id)
        {
            throw new NotImplementedException();
        }

        public GroupModel Find(Query query)
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
    }
}
