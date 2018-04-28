using HXCloud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public interface IGroup
    {
        void Save(GroupModel entity);
        void Add(GroupModel entity, string account);
        void Remove(GroupModel entity);

        GroupModel Find(string id);
        IEnumerable<GroupModel> FindBy(string query);
        IEnumerable<GroupModel> FindBy(string query, int pageSize, int pageCount);
    }
}
