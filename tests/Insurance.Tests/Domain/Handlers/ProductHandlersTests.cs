using AutoFixture;
using Insurance.Domain.Commands;
using Insurance.Domain.Entities;
using Insurance.Domain.Handlers;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.Tests.Domain
{
    public class ProductHandlersTests
    {

        private Mock<IProductRepository> productRepository;
        private Fixture fixture;

        public ProductHandlersTests()
        {
            productRepository = new Mock<IProductRepository>();
            fixture = new Fixture();
        }

        [Fact]
        public async Task ShouldReturnSuccessWithNoData_WhenCannotFindProduct()
        {
            productRepository.Setup(p => p.GetProduct(It.IsAny<int>()))
                .Returns(Task.FromResult<ProductModel>(null));

            var sut = new ProductHandler(productRepository.Object);

            var result = await sut.Handle(fixture.Create<CalculateInsurance>());

            Assert.True(result.Success);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task ShouldReturnSuccessWithNoData_WhenCannotFindProductType()
        {
            productRepository.Setup(p => p.GetProductType(It.IsAny<int>()))
                .Returns(Task.FromResult<ProductTypeModel>(null));

            var sut = new ProductHandler(productRepository.Object);

            var result = await sut.Handle(fixture.Create<CalculateInsurance>());

            Assert.True(result.Success);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task ShouldReturnSuccessWithData_WhenProductAndProductTypeCouldBeFound()
        {
            productRepository.Setup(p => p.GetProduct(It.IsAny<int>()))
               .Returns(Task.FromResult<ProductModel>(fixture.Create<ProductModel>()));

            productRepository.Setup(p => p.GetProductType(It.IsAny<int>()))
                .Returns(Task.FromResult<ProductTypeModel>(fixture.Create<ProductTypeModel>()));

            var sut = new ProductHandler(productRepository.Object);

            var result = await sut.Handle(fixture.Create<CalculateInsurance>());

            Assert.True(result.Success);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task ShouldReturnFailureWithData_WhenExceptionHappenInsideHandler()
        {
            productRepository.Setup(p => p.GetProduct(It.IsAny<int>()))
               .Throws(fixture.Create<Exception>());

            var sut = new ProductHandler(productRepository.Object);

            var result = await sut.Handle(fixture.Create<CalculateInsurance>());

            Assert.False(result.Success);
            Assert.NotNull(result.Data);
        }
    }
}
