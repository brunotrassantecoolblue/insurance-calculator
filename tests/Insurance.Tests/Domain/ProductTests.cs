using Insurance.Domain.Entities;
using Xunit;

namespace Insurance.Tests.Domain
{
    public class ProductTests
    {
        readonly ProductType normalProductTypeInsurable = new ProductType("Mouses", true);
        readonly ProductType dangerousProductTypeInsurable = new ProductType("Laptops", true);
        readonly ProductType dangerousProductTypeNonInsurable = new ProductType("Smartphones", false);

        [Theory()]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(499)]
        public void ShouldHave0EurosInsurance_WhenSalesPriceIsLowerThen500AndIsNormalType(int salesPrice)
        {
            const float expectedInsuranceValue = 0;

            var sut = new Product(normalProductTypeInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }

        [Theory()]
        [InlineData(500)]
        [InlineData(700)]
        [InlineData(1999)]
        public void ShouldHave1000EurosInsurance_WhenSalesPriceIsFrom500To1999EurosAndIsNormalType(int salesPrice)
        {
            const float expectedInsuranceValue = 1000;

            var sut = new Product(normalProductTypeInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }

        [Theory()]
        [InlineData(2000)]
        [InlineData(7000)]
        [InlineData(100000)]
        public void ShouldHave2000EurosInsurance_WhenSalesPriceIsBiggerOrEqualTo2000EurosAndIsNormalType(int salesPrice)
        {
            const float expectedInsuranceValue = 2000;

            var sut = new Product(normalProductTypeInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }

        [Theory()]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(499)]
        public void ShouldHave500EurosInsurance_WhenSalesPriceIsLowerThen500AndIsDangerousType(int salesPrice)
        {
            const float expectedInsuranceValue = 500;

            var sut = new Product(dangerousProductTypeInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }

        [Theory()]
        [InlineData(500)]
        [InlineData(700)]
        [InlineData(1999)]
        public void ShouldHave1500EurosInsurance_WhenSalesPriceIsFrom500To1999EurosAndIsDangerousType(int salesPrice)
        {
            const float expectedInsuranceValue = 1500;

            var sut = new Product(dangerousProductTypeInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }

        [Theory()]
        [InlineData(2000)]
        [InlineData(7000)]
        [InlineData(100000)]
        public void ShouldHave2500EurosInsurance_WhenSalesPriceIsBiggerOrEqualTo2000EurosAndIsDangerousType(int salesPrice)
        {
            const float expectedInsuranceValue = 2500;

            var sut = new Product(dangerousProductTypeInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }


        [Theory()]
        [InlineData(10)]
        [InlineData(600)]
        [InlineData(9000)]
        public void ShouldHave0EurosInsurance_WhenProductTypeIsNotInsurable(int salesPrice)
        {
            const float expectedInsuranceValue = 0;

            var sut = new Product(dangerousProductTypeNonInsurable, salesPrice);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: sut.InsuranceValue
            );
        }
    }
}
