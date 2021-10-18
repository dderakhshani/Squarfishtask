using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squarfish2.DataAccess.Entities.Configurations
{
    public class TourLeaderConfiguration : IEntityTypeConfiguration<TourLeader>
    {
        public void Configure(EntityTypeBuilder<TourLeader> builder)
        {
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Leader)
                .WithMany(p => p.TourLeaders)
                .HasForeignKey(d => d.LeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourLeaders_Leaders");

            builder.HasOne(d => d.Tour)
                .WithMany(p => p.TourLeaders)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourLeaders_Tours1");
        }
    }
}
