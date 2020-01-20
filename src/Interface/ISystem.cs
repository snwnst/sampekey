using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Quid;

namespace Sampekey.Interface
{
    public interface ISystem
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> FindProjectById(string value);
        Task<Project> AddProject(Project value);
        Task<Project> UpdateProject(Project value);
        Task<bool> DeleteProject(Project value);
        
    }
}
