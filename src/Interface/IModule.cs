using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface
{
    public interface IModule
    {
        Task<IEnumerable<Land>> GetAllLands();
        Task<Land> FindLandById(string value);
        Task<Land> AddLand(Land value);
        Task<Land> UpdateLand(Land value);
        Task<bool> DeleteLand(Land value);

    }
}
