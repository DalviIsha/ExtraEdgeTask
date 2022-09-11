using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration
{
    public class RefSalesEntityTypeConfiguration : IEntityTypeConfiguration<RefSales>
    {
        public void Configure(EntityTypeBuilder<RefSales> builder)
        {
            builder.ToTable("ref_product").HasKey(e => e.SalesId);
            builder.Property(e => e.SalesPrice).HasColumnName("sale_price");
            builder.Property(e => e.TotalAmount).HasColumnName("total_amount");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.ProfitAmount).HasColumnName("profit_amount");
            builder.Property(e => e.DateOfSales).HasColumnName("date_of_sales");
            builder.Property(e => e.ModifiedTS).HasColumnName("modified_ts");
            builder.Property(e => e.CreatedTS).HasColumnName("created_ts");
        }
    }
}