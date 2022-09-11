using Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo
{
    public interface IProductCustomRepo
    {
        Task<bool> UpdateSaleAsync(RefSales sales);
        Task<bool> UpdateProductAsync(RefProduct product);
        Task<bool> CommitTransactionAsync();
        Task<bool> CreateProductAsync(RefProduct product);
        Task<bool> CreateSalesAsync(RefSales sales);
        Task<RefProduct> GetProduct(Guid productId);
        Task<RefSales> GetSales(Guid salesId);

    }
}