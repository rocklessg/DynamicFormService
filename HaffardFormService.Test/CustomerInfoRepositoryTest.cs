using HaffardFormService.Api.Data;

namespace HaffardFormService.Test
{
    public class CustomerInfoRepositoryTest
    {
        private readonly CustomerInfoRepository _customerInfoRepository;
        public CustomerInfoRepositoryTest()
        {
            _customerInfoRepository = new CustomerInfoRepository();
        }
        [Fact]
        public async Task GetCustomerInfoByIndustryAsync_ValidIndustry_ReturnsCorrectResponse()
        {
            // Arrange
            var industryType = "Manufacturing";

            var expectedResult = new CustomerInfoResponse
            {
                Industry = industryType,
                DynamicFields = ["Invoice Number", "Quantity", "Delivery Address"]
            };


            // Act
            var actualResult = await _customerInfoRepository.GetCustomerInfoByIndustryAsync(industryType);

            // Assert
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult.Industry, actualResult.Industry);
            Assert.Equal(expectedResult.DynamicFields, actualResult.DynamicFields);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetCustomerInfoByIndustryAsync_NullOrEmptyIndustry_ThrowsArgumentNullException(string industryType)
        {
            // Arrange
            var service = _customerInfoRepository;
            industryType = string.Empty;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.GetCustomerInfoByIndustryAsync(industryType));
        }

        [Fact]
        public async Task GetCustomerInfoByIndustryAsync_InvalidIndustry_ThrowsException()
        {
            // Arrange
            var industryType = "UnknownIndustry";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _customerInfoRepository.GetCustomerInfoByIndustryAsync(industryType));
            Assert.Equal("Industry record not found", exception.Message);
        }
    }
}