using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Identity;

namespace Sampekey.Interface.Repository
{
    public class UserRoleRepo : IUserRole
    {

        private readonly SampekeyDbContex context;

        public UserRoleRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            return await context.UserRole.Include(x=>x.Role).ToListAsync();
        }
        public async Task<IEnumerable<UserRole>> FindUserRolesByUserId(string value)
        {
            return await context.UserRole
            .Include(x=>x.Role)
            .Where(i => i.UserId == value)
            .ToListAsync();
        }
        public async Task<IEnumerable<UserRole>> FindUserRolesByRoleId(string value)
        {
            return await context.UserRole
            .Include(x=>x.Role)
            .Where(i => i.RoleId == value)
            .ToListAsync();
        }
        public async Task<UserRole> AddUserRole(UserRole value)
        {
            await context.UserRole.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<bool> DeleteUserRole(UserRole value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
