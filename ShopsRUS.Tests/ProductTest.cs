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
    public class ProductTest
    {

        [Fact]
        public async Task GetAll()
        {
            var repository = new Mock<IProductRepository>();
            // arrange

            var fakeData = CreateData.CreateProducts();

            var response = new BaseResponse<List<Product>>().Success(fakeData);

            repository.Setup(a => a.GetList(null)).Returns(Task.FromResult(response));

            var service = repository.Object;

            // act
            var results = await service.GetList();

            // assert
            Assert.True(results.Data.Count > 0);

        }
        [Fact]
        public async Task Add()
        {
            var repository = new Mock<IProductRepository>();
            // arrange

            var fakeData = CreateData.CreateProducts().FirstOrDefault(s => s.Id == 1);

            var response = new BaseResponse<Product>().Success(fakeData);

            repository.Setup(a => a.AddAsync(fakeData)).Returns(Task.FromResult(response));

            var service = repository.Object;

            // act
            var results = await service.AddAsync(fakeData);

            // assert
            Assert.Equal(1, results.Data.Id);

        }
    }
}
