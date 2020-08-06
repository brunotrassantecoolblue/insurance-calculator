using Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Insurance.Tests.Domain
{
    public class ProductTypeTests
    {
        [Theory()]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeDangerous_WhenNameIsLaptops(bool isInsurable)
        {
            const bool expectedValue = true;

            var sut = new ProductType("Laptops", isInsurable);

            Assert.Equal(
                expected: expectedValue,
                actual: sut.IsDangerous
            );
        }

        [Theory()]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeDangerous_WhenNameIsSmartphones(bool isInsurable)
        {
            const bool expectedValue = true;

            var sut = new ProductType("Smartphones", isInsurable);

            Assert.Equal(
                expected: expectedValue,
                actual: sut.IsDangerous
            );
        }

        [Theory()]

        [InlineData("")]
        [InlineData("any name")]
        [InlineData("Televisions")]
        public void ShouldNotBeDangerous_WhenOtherNamesAreUsed(string name)
        {
            const bool expectedValue = false;

            var sut = new ProductType(name, false);

            Assert.Equal(
                expected: expectedValue,
                actual: sut.IsDangerous
            );
        }
    }
}
