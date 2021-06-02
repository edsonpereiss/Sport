using MongoDB.Driver;
using Sport.Entities;

namespace Sport.Data
{

    public interface ISportContext
    {
        IMongoCollection<Football> Footballs {get;}
    }
}