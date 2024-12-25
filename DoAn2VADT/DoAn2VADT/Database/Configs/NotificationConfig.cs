using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DoAn2VADT.Database.Entities;

namespace DoAn2VADT.Database.Entities
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(n => n.UserId)
                   .HasMaxLength(450)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(n => n.OrderId)
                   .HasMaxLength(450)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(n => n.Type)
                   .HasMaxLength(50); // Không bắt buộc nhập

            builder.Property(n => n.Status)
                   .HasMaxLength(50); // Không bắt buộc nhập
        }
    }
}
