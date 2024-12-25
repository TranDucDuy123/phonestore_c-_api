using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DoAn2VADT.Database.Entities;

namespace DoAn2VADT.Database.Entities
{
    public class ProductColorConfig : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.Property(pc => pc.ProductId)
                   .HasMaxLength(450)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(pc => pc.ColorId)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(pc => pc.Quantity)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(pc => pc.IsDefault)
                   .IsRequired(); // Bắt buộc nhập
        }
    }
}
