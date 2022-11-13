namespace Pair.Infrastructure.Tests.DapperORM
{
    public class PersonsRepositoryTests
    {
        private readonly IConfiguration _configuration;

        private readonly StandartFixture _standartFixture = new StandartFixture();

        private readonly DapperRepositoryBase<Person> _personsRepository;

        private readonly Mock<DapperRepositoryBase<Person>> _personsRepositoryMock;

        public PersonsRepositoryTests()
        {
            _configuration = _standartFixture.Configuration;

            _personsRepository = new PersonsRepository(_configuration);

            _personsRepositoryMock = new Mock<DapperRepositoryBase<Person>>();
        }

        [Fact]
        public async void InsertPersonShould_ReturnsId()
        {
           
        }

        [Fact]
        public async void GetPersonShould_ReturnsPerson()
        {
            _personsRepositoryMock.Setup(r => r.Get(It.IsAny<int>()))
                .ReturnsAsync(It.IsAny<Person>());

            var person = await _personsRepository.Get(1);

            Assert.NotNull(person);
        }

        [Fact]
        public async void GetPersonShould_ReturnsPersons()
        {
           
        }
    }
}
