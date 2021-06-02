using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Sport.Entities;

namespace Sport.Data
{

    public class SportContext : ISportContext
    {
        public SportContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Footballs = database.GetCollection<Football>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            SportContextSeed.SeedData(Footballs);
        }
        public IMongoCollection<Football> Footballs {get;}

    }
}