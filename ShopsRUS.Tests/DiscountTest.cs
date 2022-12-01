using Microsoft.EntityFrameworkCore;
using Moq;
using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using ShopsRUS.Core.Seed;
using ShopsRUS.DataAccess.Abstract;
using ShopsRUS.DataAccess.Concrete.Ef;
using ShopsRUS.DataAccess.Concrete.Ef.Contexts;
using System.Collections.Generic;

namespace ShopsRUS.Tests
{
    public class DiscountTest
    {
        [Fact]
        public async Task GetAll()
        {
            var repository = new Mock<IDiscountRepository>();
            // arrange

            var fakeData = CreateData.CreateDiscounts();

            var response = new BaseResponse<List<Discount>>().Success(fakeData);

            repository.Setup(a => a.GetList(null)).Returns(Task.FromResult(response));

            var service = repository.Object;

            // act
            var results = await service.GetList();

            // assert
            Assert.Equal(3, results.Data.Count);

        }
        [Fact]
        public async Task Add()
        {
            var repository = new Mock<IDiscountRepository>();
            // arrange

            var fakeData = CreateData.CreateDiscounts().FirstOrDefault(s=>s.Id == 1);

            var response = new BaseResponse<Discount>().Success(fakeData);

            repository.Setup(a => a.AddAsync(fakeData)).Returns(Task.FromResult(response));

            var service = repository.Object;

            // act
            var results = await service.AddAsync(fakeData);

            // assert
            Assert.Equal(1, results.Data.Id);

        }
    }
}