using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Contex;
using Microsoft.EntityFrameworkCore;
using Sampekey.Model.Identity;

namespace Sampekey.Interface.Repository
{
    public class RoleRepo : IRole
    {
        private readonly SampekeyDbContex context;
        public RoleRepo(SampekeyDbContex _context)
        {
            context = _context;
        }
       public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await context.Role.ToListAsync();
        }
        public async Task<Role> FindRoleById(string value)
        {
            return await context.Role.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Role> AddRole(Role value)
        {
            await context.Role.AddAsync(value);
            context.SaveChanges();
            return value;
        }
        public async Task<Role> UpdateRole(Role value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Role.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteRole(Role value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }
    }
}