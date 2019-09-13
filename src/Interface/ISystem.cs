using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface
{
    public interface ISystem
    {
        Task<IEnumerable<Castle>> GetAllCastles();
        Task<Castle> FindCastleById(string value);
        Task<Castle> AddCastle(Castle value);
        Task<Castle> UpdateCastle(Castle value);
        Task<bool> DeleteCastle(Castle value);
        
    }
}
