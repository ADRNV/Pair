using Pair.Core.ORM;

namespace Pair.Infrastructure.Tests.DapperORM
{
    public class PersonsRepositoryTests
    {
        private readonly IConfiguration _configuration;

        private readonly StandartFixture _standartFixture = new StandartFixture();

        private readonly DapperRepositoryBase<Person> _personsRepository;

        private readonly Mock<IOrmWrapper<Person>> _personsRepositoryMock;

        public PersonsRepositoryTests()
        {
            _configuration = _standartFixture.Configuration;

            _personsRepository = new PersonsRepository(_configuration);

            _personsRepositoryMock = new Mock<IOrmWrapper<Person>>();
        }

        [Fact]
        public async void InsertPersonShould_ReturnsId()
        {

        }

        [Fact]
        public async void GetPersonShould_ReturnsPerson()
        {

        }

        [Fact]
        public async void GetPersonShould_ReturnsPersons()
        {

        }
    }
}
