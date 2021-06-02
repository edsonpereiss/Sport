using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sport.Entities;

namespace Sport.Repositories
{

    public interface IFootballRepository
    {
        Task<IEnumerable<Football>> GetFootballs();
        Task<Football> GetFootball(string id);
        Task<IEnumerable<Football>> GetFootballsByName( string name);
        Task<Football> GetFootballByName( string name);
        Task CreateFootball(Football football);
        Task<bool> UpadateFootball(Football football);
        Task<bool> DeleteFootball(string id);        
    }
}