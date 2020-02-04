using Sampekey.Model.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> FindUserById(string value);
        Task<User> FindUserByUsername(string value);
        Task<User> AddUser(User value);
        Task<User> UpdateUser(User value);
        Task<bool> DeleteUser(User value);

    }
}

