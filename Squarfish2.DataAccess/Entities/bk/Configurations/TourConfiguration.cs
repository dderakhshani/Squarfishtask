
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squarfish2.DataAccess.Entities
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            builder.Property(e => e.StartTime).HasColumnType("datetime");

            builder.Property(e => e.TourTitle)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}