using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface
{
    public interface IEnviroment
    {
        Task<IEnumerable<Kingdom>> GetAllKingdoms();
        Task<Kingdom> FindKingdomById(string value);
        Task<Kingdom> AddKingdom(Kingdom value);
        Task<Kingdom> UpdateKingdom(Kingdom value);
        Task<bool> DeleteKingdom(Kingdom value);

    }
}
