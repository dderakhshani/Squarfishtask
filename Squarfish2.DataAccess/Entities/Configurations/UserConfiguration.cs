using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squarfish2.DataAccess.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(e => e.Password).IsRequired();

            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Person)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Persons");
        }
    }
}
