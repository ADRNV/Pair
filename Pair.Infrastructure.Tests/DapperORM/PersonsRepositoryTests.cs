using Pair.Core.ORM;
using ServiceStack.OrmLite.Dapper;

namespace Pair.Infrastructure.Tests.DapperORM
{
    //TODO: Add Moq
    public class PersonsRepositoryTests : IDisposable
    {
        private readonly IConfiguration _configuration;

        private readonly StandartFixture _standartFixture = new StandartFixture();

        private readonly DapperRepositoryBase<Person> _personsRepository;

        private readonly Mock<IOrmWrapper<Person>> _personsRepositoryMock;
        
        public PersonsRepositoryTests()
        {
            _configuration = _standartFixture.Configuration;

            _personsRepository = new PersonsRepository(_standartFixture.DbConnectionFactory);

            _personsRepositoryMock = new Mock<IOrmWrapper<Person>>();

            _standartFixture.DbConnection
                .Execute(@"CREATE TABLE IF NOT EXISTS Persons (
                        Id   INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Age  INTEGER,
                        Bio  TEXT,
                        Sex  TEXT,
                        Photo BLOB
                );");
        }

        [Fact]
        public async void Insert_PersonShould_Returns_Id()
        {
            var person = new Fixture()
                .Build<Person>()
                .Without(p => p.SocialLinks)
                .Create();

            var actualId = await _personsRepository.Insert(person);

            Assert.Equal(1, actualId);
        }

        [Fact]
        public async void GetPerson_Should_Returns_Person()
        {
            var person = new Fixture()
               .Build<Person>()
               .Without(p => p.SocialLinks)
               .Create();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void GetPerson_Should_Returns_null(int id)
        {
            var actual = await _personsRepository.Get(id);

            Assert.Null(actual);
        }

        public void Dispose()
        {
            _standartFixture.DbConnection.Execute("DROP TABLE IF EXISTS Persons;");
        }
    }
}
