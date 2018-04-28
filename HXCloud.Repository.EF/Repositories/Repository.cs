﻿using HXCloud.UnitOfWork.Infrastructure;
using HXCloud.UnitOfWork.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Repository.EF.Repositories
{
    public abstract class Repository<T, EntityKey> : IUnitOfWorkRepository where T : IAggregateRoot
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {
            _uow.RegisterNew(entity, this);
        }

        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, this);
        }

        public void Save(T entity)
        {
            // Do nothing as EF tracks changes
        }

        public abstract IQueryable<T> GetObjectSet();

        public abstract string GetEntitySetName();

        public abstract T FindBy(EntityKey Id);

        public abstract ObjectQuery<T> TranslateIntoObjectQueryFrom(Query query);

        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ObjectQuery<T> efQuery = TranslateIntoObjectQueryFrom(query);

            return efQuery.ToList<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ObjectQuery<T> efQuery = TranslateIntoObjectQueryFrom(query);

            return efQuery.Skip(index).Take(count).ToList<T>();
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            //DataContextFactory.GetDataContext()..Set(GetType(GetEntitySetName())).Add(entity);
           // DataContextFactory.GetDataContext().AddObject(GetEntitySetName(), entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            // Do nothing as EF tracks changes
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
          //  DataContextFactory.GetDataContext().DeleteObject(entity);
        }
    }
}