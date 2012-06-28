using System.Collections.Generic;
using System.Linq;
using Client;
using DCouple.Mongo;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ApplicationServiceTests
    {
        [Test]
        public void GetPeopleOver21YearsOld()
        {
            var peopleOver21YearsOld = new List<Person>
            {
                new Person {Id = "1", Age = 25, Name = "Walter"},
                new Person {Id = "2", Age = 36, Name = "Euan"}
            };

            var expectedQuery = Query.GT("Age", 21);
            var databaseMock = new Mock<IMongoDatabase>();
            var peopleCollectionMock = new Mock<IMongoCollection<Person>>();
            var cursorMock = new Mock<IMongoCursor<Person>>();

            cursorMock.Setup(m => m.GetEnumerator()).Returns(peopleOver21YearsOld.GetEnumerator());

            databaseMock.Setup(m => m.GetCollection<Person>(CollectionNames.People))
                .Returns(peopleCollectionMock.Object);

            peopleCollectionMock.Setup(
                m => m.FindAs<Person>(It.Is<IMongoQuery>(query => query.ToString().Equals(expectedQuery.ToString()))))
                .Returns(cursorMock.Object);

            var applcationService = new ApplicationService(databaseMock.Object);

            Assert.AreEqual(2, applcationService.GetPeopleOver(21).Count());

            databaseMock.VerifyAll();
            peopleCollectionMock.VerifyAll();
            cursorMock.VerifyAll();
        }
    }
}
    