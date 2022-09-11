using Domain.Dto;
using Domain.Interfaces.Repositories.RepoWrappers;
using Moq;
using WebApplication1.Domain.RequestModels.Query;
using WebApplication1.Infrastructure.Handlers.Query;
using Xunit;

namespace WebApplication1.UnitTest.Tests
{
    public class GetAllSalesProfitAndLossMonthlyReportHandlerTest
    {
        [Fact]
        public async Task Get_Sale_Profit_And_Loss_Report_Should_Return_True_If_Request_Is_Valid()
        {
            // Arrange

            var mockISalesQueryRepo = new Mock<ISalesQueryRepo>();
            object p = mockISalesQueryRepo.Setup(x => x.GetAllSalesForProfitAndLossReportQuery()).ReturnsAsync(new List<SalesReportDto>());
           

            var handler = new GetAllSalesProfitAndLossMonthlyReportHandler(
                        mockISalesQueryRepo.Object);

            // Act
            var result = await handler.Handle(new GetAllSalesProfitAndLossReportQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }


        [Fact]
        public async Task Get_Sale_Profit_And_Loss_Report_Should_Return_false_If_Request_Is_Valid()
        {
            // Arrange

            var mockISalesQueryRepo = new Mock<ISalesQueryRepo>();

            object p = mockISalesQueryRepo.Setup(x => x.GetAllSalesForProfitAndLossReportQuery()).ReturnsAsync(new List<SalesReportDto>());


            var handler = new GetAllSalesProfitAndLossMonthlyReportHandler(
                        mockISalesQueryRepo.Object);

            // Act
            var result = await handler.Handle(new GetAllSalesProfitAndLossReportQuery(), CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Get_Sale_Profit_And_Loss_Report_Should_Return_Exception()
        {
            // Arrange

            var mockISalesQueryRepo = new Mock<ISalesQueryRepo>();

            object p = mockISalesQueryRepo.Setup(x => x.GetAllSalesForProfitAndLossReportQuery()).ThrowsAsync( new Exception());


            var handler = new GetAllSalesProfitAndLossMonthlyReportHandler(
                        mockISalesQueryRepo.Object);

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetAllSalesProfitAndLossReportQuery(), CancellationToken.None));

            // Assert
            Assert.Equal("Error occured on GetAllSalesProfitAndLossReport");
        }
    }
}
