using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;

namespace Sampekey.Interface
{
    public interface ISystemModule
    {
        Task<IEnumerable<ProjectModule>> GetAllProjectModules();
        Task<ProjectModule> FindProjectModuleById(string value);
        Task<ProjectModule> AddProjectModule(ProjectModule value);
        Task<ProjectModule> UpdateProjectModule(ProjectModule value);
        Task<bool> DeleteProjectModule(ProjectModule value);
        
    }
}
