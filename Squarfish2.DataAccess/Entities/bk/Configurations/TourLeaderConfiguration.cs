using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squarfish2.DataAccess.Entities.Configurations
{
    public class TourLeaderConfiguration : IEntityTypeConfiguration<TourLeader>
    {
        public void Configure(EntityTypeBuilder<TourLeader> builder)
        {
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Person)
                .WithMany(p => p.TourLeaders)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourLeaders_Persons");

            builder.HasOne(d => d.Tour)
                .WithMany(p => p.TourLeaders)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourLeaders_Tours");
        }
    }
}
