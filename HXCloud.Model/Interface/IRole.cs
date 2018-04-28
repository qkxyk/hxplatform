using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public interface IRole
    {
        void Add(RoleModel entity);
        void Save(RoleModel entity);
        void Remove(RoleModel entity);

        RoleModel Find(int id);
        IEnumerable<RoleModel> FindBy(string query);
        IEnumerable<RoleModel> FindBy(string query, int pageSize, int pageCount);
    }
}
