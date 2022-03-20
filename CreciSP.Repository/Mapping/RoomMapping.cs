using CreciSP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreciSP.Repository.Mapping
{
    public class RoomMapping : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                   .IsRequired();

            builder.Property(x => x.Floor)
                   .IsRequired();
            
            builder.Property(x => x.Capacity)
                   .IsRequired();

            builder.Property(x => x.Type)
                   .IsRequired();


            builder.HasMany(x => x.Bookings)
                   .WithOne(x => x.Room)
                   .HasForeignKey(x => x.RoomId);
        }
    }
}
