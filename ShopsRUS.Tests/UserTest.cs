using Moq;
using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using ShopsRUS.Core.Seed;
using ShopsRUS.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Tests
{
    public class UserTest
    {
        [Fact]
        public async Task GetById()
        {
            int id = 1;

            var repository = new Mock<IUserRepository>();
            // arrange

            var fakeData = CreateData.CreateUsers().FirstOrDefault(s => s.Id == id);

            var response = new BaseResponse<User>().Success(fakeData);

            repository.Setup(a => a.Get(s => s.Id == id)).Returns(Task.FromResult(response));

            var service = repository.Object;

            // act
            var results = await service.Get(s => s.Id == id);

            // assert
            Assert.Equal(id, results.Data.Id);

        }
        [Fact]
        public async Task Add()
        {
            var repository = new Mock<IUserRepository>();
            // arrange

            var fakeData = CreateData.CreateUsers().FirstOrDefault(s => s.Id == 1);

            var response = new BaseResponse<User>().Success(fakeData);

            repository.Setup(a => a.AddAsync(fakeData)).Returns(Task.FromResult(response));

            var service = repository.Object;

            // act
            var results = await service.AddAsync(fakeData);

            // assert
            Assert.Equal(1, results.Data.Id);

        }
    }
}
