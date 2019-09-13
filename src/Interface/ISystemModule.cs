using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface
{
    public interface ISystemModule
    {
        Task<IEnumerable<CastleLand>> GetAllCastleLands();
        Task<CastleLand> FindCastleLandById(string value);
        Task<CastleLand> AddCastleLand(CastleLand value);
        Task<CastleLand> UpdateCastleLand(CastleLand value);
        Task<bool> DeleteCastleLand(CastleLand value);
        
    }
}
