using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Quid;

namespace Sampekey.Interface
{
    public interface IModule
    {
        Task<IEnumerable<Module>> GetAllModules();
        Task<Module> FindModuleById(string value);
        Task<Module> AddModule(Module value);
        Task<Module> UpdateModule(Module value);
        Task<bool> DeleteModule(Module value);

    }
}
