using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Contex;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Sampekey.Model.Identity;

namespace Sampekey.Interface.Repository
{
    public class UserRepo : IUser
    {
        private readonly SampekeyDbContex context;

        public UserRepo( SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await context.User.ToListAsync();
        }
        public async Task<User> FindUserById(string value)
        {
            return await context.User.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<User> AddUser(User value)
        {
            await context.User.AddAsync(value);
            context.SaveChanges();
            return value;
        }
        public async Task<User> UpdateUser(User value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.User.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteUser(User value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}