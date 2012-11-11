using System.Collections.Generic;
using DCouple.Mongo;
using MongoDB.Driver.Builders;

namespace Client
{
    public class ApplicationService
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ApplicationService(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public IEnumerable<Person> GetPeopleOver(int years)
        {
            var collection = _mongoDatabase.GetCollection<Person>(CollectionNames.People);

            var result = collection.FindAs<Person>(Query.GT("Age", years));

            return result;
        }
    }
}
