using Domain.Dto;
using Domain.Interfaces.Repositories.RepoWrappers;
using Moq;
using WebApplication1.Domain.Common;
using WebApplication1.Domain.RequestModels.Query;
using WebApplication1.Infrastructure.Handlers.Query;
using Xunit;

namespace WebApplication1.UnitTest.Tests
{
    public class GetAllSalesMonthlyReportHandlerTest
    {
        [Fact]
        public async Task Get_Sale_Report_Should_Return_True_If_Request_Is_Valid()
        {
            // Arrange

            var mockISalesQueryRepo = new Mock<ISalesQueryRepo>();


           
            var salesReportDto = new SalesSearchFilterForReport()
            {
                Brand = "Oppo",
            };
            object p = mockISalesQueryRepo.Setup(x => x.GetAllSalesReportQuery(salesReportDto)).ReturnsAsync(new List<SalesReportDto>());
           

            var handler = new GetAllSalesMonthlyReportHandler(
                        mockISalesQueryRepo.Object);

            // Act
            var result = await handler.Handle(new GetAllSalesReportQuery(It.IsAny<SalesSearchFilterForReport>()), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }


        [Fact]
        public async Task Get_Sale_Report_Should_Return_False_If_Request_InValid()
        {
            // Arrange

            var mockISalesQueryRepo = new Mock<ISalesQueryRepo>();

            
            object p = mockISalesQueryRepo.Setup(x => x.GetAllSalesReportQuery(It.IsAny<SalesSearchFilterForReport>())).ReturnsAsync(new List<SalesReportDto>());


            var handler = new GetAllSalesMonthlyReportHandler(
                        mockISalesQueryRepo.Object);

            // Act
            var result = await handler.Handle(new GetAllSalesReportQuery(It.IsAny<SalesSearchFilterForReport>()), CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Get_Sale_Report_Should_Return_Exceptio()
        {
            // Arrange

            var mockISalesQueryRepo = new Mock<ISalesQueryRepo>();


            object p = mockISalesQueryRepo.Setup(x => x.GetAllSalesReportQuery(It.IsAny<SalesSearchFilterForReport>())).ThrowsAsync(new Exception());


            var handler = new GetAllSalesMonthlyReportHandler(
                        mockISalesQueryRepo.Object);

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetAllSalesReportQuery(It.IsAny<SalesSearchFilterForReport>()), CancellationToken.None));

            // Assert
            Assert.Equal("Error occured on GetAllSalesReport");
        }

    }
}
