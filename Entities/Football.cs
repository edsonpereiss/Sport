using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sport.Entities
{
    public class Football
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}

        [BsonElement("Name")]
        public string Name {get; set;}
        public string jsonFile {get; set;}
        public DateTime LastUpdate {get; set;}

    }
}