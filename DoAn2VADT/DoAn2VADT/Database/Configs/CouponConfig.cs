using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DoAn2VADT.Database.Entities;

namespace DoAn2VADT.Database.Entities
{
    public class CouponConfig : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(c => c.Code)
                   .HasMaxLength(50)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(c => c.Discount)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(c => c.ExpiryDate)
                   .HasColumnType("date"); // Kiểu dữ liệu ngày tháng
        }
    }
}
