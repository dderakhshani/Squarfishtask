using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squarfish2.DataAccess.Entities.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
