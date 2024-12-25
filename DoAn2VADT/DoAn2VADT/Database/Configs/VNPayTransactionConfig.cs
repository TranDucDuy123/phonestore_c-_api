using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DoAn2VADT.Database.Entities;

namespace DoAn2VADT.Database.Entities
{
    public class VNPayTransactionConfig : IEntityTypeConfiguration<VNPayTransaction>
    {
        public void Configure(EntityTypeBuilder<VNPayTransaction> builder)
        {
            builder.Property(vt => vt.TransactionId)
                   .HasMaxLength(50)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(vt => vt.OrderId)
                   .HasMaxLength(450)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(vt => vt.PaymentStatus)
                   .HasMaxLength(20)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(vt => vt.PaymentMethod)
                   .HasMaxLength(50)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(vt => vt.BankCode)
                   .HasMaxLength(10); // Không bắt buộc nhập
        }
    }
}
