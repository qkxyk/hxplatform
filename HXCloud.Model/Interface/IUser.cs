using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public interface IUser
    {
        void Save(UserModel entity);
        void Add(UserModel entity);
        void Remove(UserModel entity);

        UserModel Find(int id);
        UserModel Find(string user,string password);
        IEnumerable<UserModel> FindBy(string query);
        IEnumerable<UserModel> FindBy(string query, int pageSize, int pageCount);
    }
}
