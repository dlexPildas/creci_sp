using CreciSP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreciSP.Repository.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Cpf)
                   .HasMaxLength(11)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.HasMany(x => x.Bookings)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
