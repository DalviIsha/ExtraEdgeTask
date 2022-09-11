
namespace Domain.Dto
{
    public class SalesReportDto
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateOfSales { get; set; }
        public string ProductName { get; set; }
        public string BatchNumber { get; set; }
        public string Brand { get; set; }
        public DateTime MangDate { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal Discount { get; set; }
        public DateTime? ModifiedTS { get; set; }
    }
}