using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DoAn2VADT.Database.Entities;

namespace DoAn2VADT.Database.Entities
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(100)
                   .IsRequired(); // Bắt buộc nhập

            builder.Property(c => c.HexCode)
                   .HasMaxLength(10); // Không bắt buộc nhập
        }
    }
}
