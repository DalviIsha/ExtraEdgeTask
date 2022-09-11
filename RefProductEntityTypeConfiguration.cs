

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration
{
    public class RefProductEntityTypeConfiguration : IEntityTypeConfiguration<RefProduct>
    {
        public void Configure(EntityTypeBuilder<RefProduct> builder)
        {
            builder.ToTable("ref_product").HasKey(e => e.ProductId);
            builder.Property(e => e.ProductName).HasColumnName("product_id");
            builder.Property(e => e.CostPrice).HasColumnName("cost_price");
            builder.Property(e => e.Brand).HasColumnName("brand");
            builder.Property(e => e.MangDate).HasColumnName("mag_date");
            builder.Property(e => e.Discount).HasColumnName("discount");
            builder.Property(e => e.ModifiedTS).HasColumnName("modified_ts");
            builder.Property(e => e.CreatedTS).HasColumnName("created_ts");
        }
    }
}