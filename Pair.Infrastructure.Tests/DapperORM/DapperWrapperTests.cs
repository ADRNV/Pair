using AutoFixture;
using Pair.Infrastructure.DapperORM;
using Pair.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.Tests.DapperORM
{
    public class DapperWrapperTests
    {
        private readonly DapperWrapper _dapperWrapper;

        public DapperWrapperTests()
        {
            _dapperWrapper = new DapperWrapper(new SqlConnection(@"Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False"));
        }

        [Fact]
        public async void InserShould_ReturnsId()
        {
            var person = new Fixture()
                .Build<Persons>()
                .With(p => p.Sex, "dsdas")
                .With(p => p.Name, "dasdas")
                .With(p => p.Age, 54)
                .Create();

            var id = await _dapperWrapper.Insert<Persons>(person);

            Assert.Equal(1, id);
        }
    }
}
