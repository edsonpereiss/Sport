using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Sport.Data;
using Sport.Entities;

namespace Sport.Repositories
{

    public class FootballRepository: IFootballRepository
    {
        private readonly ISportContext _context;
        public FootballRepository(ISportContext context)
        {
            _context = context;
        }

        public async Task CreateFootball(Football football)
        {
            await _context.Footballs.InsertOneAsync(football);
        }

        public async Task<bool> DeleteFootball(string id)
        {
            FilterDefinition<Football> filter = Builders<Football>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Footballs.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;            
        }

        public async Task<Football> GetFootball(string id)
        {
            return await _context.Footballs.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Football>> GetFootballsByName(string name)
        {
            FilterDefinition<Football> filter = Builders<Football>.Filter.Eq(p => p.Name, name);
            return await _context.Footballs.Find(filter).ToListAsync();
        }

        public async Task<Football> GetFootballByName(string name)
        {
            FilterDefinition<Football> filter = Builders<Football>.Filter.Eq(p => p.Name, name);
            return await _context.Footballs.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Football>> GetFootballs()
        {
            return await _context.Footballs.Find(p=> true).ToListAsync();
        }

        public async Task<bool> UpadateFootball(Football football)
        {
            var updateResult = await _context.Footballs.ReplaceOneAsync(
                filter: g => g.Id == football.Id, replacement: football);

            return updateResult.IsAcknowledged 
                && updateResult.ModifiedCount > 0;            
        }

    }
}