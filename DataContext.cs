using Domain.Entities;
using Infrastructure.Context.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<WriteWebApplication1MSContext> options)
        : base(options)
        {
        }

        public DbSet<RefProduct> RefProduct { get; set; }
        public DbSet<RefSales> RefSales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RefProductEntityTypeConfiguration).Assembly);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}