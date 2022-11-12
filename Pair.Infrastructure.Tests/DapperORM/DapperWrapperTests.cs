using AutoFixture;
using Moq;
using Pair.Core.Models;
using Pair.Core.ORM;
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
        private readonly IOrmWrapper<Persons> _dapper;

        public DapperWrapperTests()
        {
            _dapper = new DapperWrapper<Persons>(new SqlConnection(@"Server=localhost;Database=PairTest;Integrated Security=true;"));
        }

        [Fact]
        public async void InsertShould_ReturnsId()
        {
            var person = new Fixture()
                .Build<Persons>()
                .With(p => p.Name, "Name")
                .With(p => p.Age, new Random().Next(0, 100))
                .With(p => p.Sex, "Helicopter")
                .Create();

            var ormMock = new Mock<IOrmWrapper<Persons>>();

            ormMock.Setup(p => p.Insert(person)).ReturnsAsync(1);

            var id = await ormMock.Object.Insert(person);

            var actualId = await _dapper.Insert(person);

            Assert.True(id == actualId);
        }

        [Fact]
        public async void GetShould_ReturnsEntity()
        {
            
        }
    }
}
