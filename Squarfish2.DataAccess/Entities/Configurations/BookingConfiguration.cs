
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squarfish2.DataAccess.Entities
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> modelBuilder)
        {
            modelBuilder.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            modelBuilder.HasOne(d => d.BookerUser)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Users");

            modelBuilder.HasOne(d => d.Tour)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Tours");
        }
    }
}