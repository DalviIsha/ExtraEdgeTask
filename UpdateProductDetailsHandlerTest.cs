using Domain.Dto;
using Domain.Entities;
using Moq;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Domain.RequestModels.CommandRequestModels.Product;
using WebApplication1.Infrastructure.Handlers.Command;
using Xunit;

namespace WebApplication1.UnitTest.Tests.VendorCommands
{
    public class UpdateProductDetailsHandlerTest
    {
        [Fact]
        public async Task Update_Product_Should_Return_True_If_Request_Is_Valid()
        {
            // Arrange

            var mockIProductCustomRepo = new Mock<IProductCustomRepo>();


            var productDto = new ProductDto();
            {
                new ProductDto()
                {
                    ProductId = Guid.Parse("017f4e54-5a7c-4779-a9d6-b881b046868f"),
                    ProductName = "Mobile1",
                    Brand = "Oppo",
                };
            }
            var salesDto = new SalesDto();
            {
                new SalesDto()
                {
                    ProductId = Guid.Parse("017f4e54-5a7c-4779-a9d6-b881b046868f"),
                    Quantity = 10,
                    TotalAmount = 1230M,
                };
            }
            var saveProductDetailsDto = new ProductDetailsDto()
            {
                product = productDto,
                sales = salesDto

            };
            mockIProductCustomRepo.Setup(x => x.UpdateProductAsync(It.IsAny<RefProduct>())).ReturnsAsync(true);
            mockIProductCustomRepo.Setup(x => x.UpdateSaleAsync(It.IsAny<RefSales>())).ReturnsAsync(true);
            mockIProductCustomRepo.Setup(x => x.CommitTransactionAsync()).ReturnsAsync(true);

            var handler = new UpdateProductDetailsHandler(
                        mockIProductCustomRepo.Object);

            // Act
            var result = await handler.Handle(new UpdateProductCommand(It.IsAny<Guid>(),saveProductDetailsDto), CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Update_Product_Should_Return_True_If_Request_InValid()
        {
            // Arrange

            var mockIProductCustomRepo = new Mock<IProductCustomRepo>();


            var productDto = new ProductDto();
            {
                new ProductDto()
                {
                    ProductId = Guid.Parse("017f4e54-5a7c-4779-a9d6-b881b046868f"),
                    ProductName = "Mobile1",
                    Brand = "Oppo",
                };
            }
            var salesDto = new SalesDto();
            {
                new SalesDto()
                {
                    ProductId = Guid.Parse("017f4e54-5a7c-4779-a9d6-b881b046868f"),
                    Quantity = 10,
                    TotalAmount = 1230M,
                };
            }
            var saveProductDetailsDto = new ProductDetailsDto()
            {
                product = productDto,
                sales = salesDto

            };
            mockIProductCustomRepo.Setup(x => x.UpdateProductAsync(It.IsAny<RefProduct>())).ReturnsAsync(false);
            mockIProductCustomRepo.Setup(x => x.UpdateSaleAsync(It.IsAny<RefSales>())).ReturnsAsync(true);
            mockIProductCustomRepo.Setup(x => x.CommitTransactionAsync()).ReturnsAsync(true);

            var handler = new UpdateProductDetailsHandler(
                        mockIProductCustomRepo.Object);

            // Act
            var result = await handler.Handle(new UpdateProductCommand(It.IsAny<Guid>(), saveProductDetailsDto), CancellationToken.None);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public async Task Update_Product_Should_Return_True_If_Request_Exception()
        {
            // Arrange

            var mockIProductCustomRepo = new Mock<IProductCustomRepo>();


            var productDto = new ProductDto();
            {
                new ProductDto()
                {
                    ProductId = Guid.Parse("017f4e54-5a7c-4779-a9d6-b881b046868f"),
                    ProductName = "Mobile1",
                    Brand = "Oppo",
                };
            }
            var salesDto = new SalesDto();
            {
                new SalesDto()
                {
                    ProductId = Guid.Parse("017f4e54-5a7c-4779-a9d6-b881b046868f"),
                    Quantity = 10,
                    TotalAmount = 1230M,
                };
            }
            var saveProductDetailsDto = new ProductDetailsDto()
            {
                product = productDto,
                sales = salesDto

            };
            mockIProductCustomRepo.Setup(x => x.UpdateProductAsync(It.IsAny<RefProduct>())).ThrowsAsync(new Exception());
            mockIProductCustomRepo.Setup(x => x.UpdateSaleAsync(It.IsAny<RefSales>())).ReturnsAsync(true);
            mockIProductCustomRepo.Setup(x => x.CommitTransactionAsync()).ReturnsAsync(true);

            var handler = new UpdateProductDetailsHandler(
                        mockIProductCustomRepo.Object);

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(new UpdateProductCommand(It.IsAny<Guid>(), saveProductDetailsDto), CancellationToken.None));

            // Assert
            Assert.Equal("Error In Update Product details");
        }


    }
}
