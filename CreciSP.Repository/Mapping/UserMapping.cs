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
                   .IsRequired();

            builder.Property(x => x.Cpf)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .IsRequired();

            builder.Property(x => x.Password)
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
