using System;
using MongoDB.Driver;
using System.Collections.Generic;
using Sport.Entities;

namespace Sport.Data
{

    public class SportContextSeed {
        public static void SeedData(IMongoCollection<Football> footballCollection)
        {
            if (footballCollection is null)
            {
                throw new ArgumentNullException(nameof(footballCollection));
            }

            bool existFootball = footballCollection.Find(p => true).Any();
            if (!existFootball)
            {
                footballCollection.InsertManyAsync(getMyFootballs());
            }
        }

        private static IEnumerable<Football> getMyFootballs()
        {  
            return new List<Football>()
            {
                new Football()
                {
                    Id = "312840823048048f1",
                    Name = "stands",
                    jsonFile = "[]",
                    LastUpdate = DateTime.Now
                },
                new Football()
                {
                    Id = "312840823048048f2",
                    Name = "Matches",
                    jsonFile = "[]",
                    LastUpdate = DateTime.Now
                }
            };
        }
    }
}