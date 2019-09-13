using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Administration;

namespace Sampekey.Interface.Repository
{
    public class PermissionRepo : IPermission
    {

        private readonly SampekeyDbContex context;

        public PermissionRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return await context.Permission.ToListAsync();
        }
        public async Task<Permission> FindPermissionById(string value)
        {
            return await context.Permission.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Permission> AddPermission(Permission value)
        {
            await context.Permission.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Permission> UpdatePermission(Permission value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Permission.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeletePermission(Permission value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
