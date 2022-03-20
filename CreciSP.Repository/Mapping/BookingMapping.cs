using CreciSP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreciSP.Repository.Mapping
{
    public class BookingMapping : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                   .IsRequired();

            builder.Property(x => x.StartTime)
                   .IsRequired();
            
            builder.Property(x => x.EndTime)
                   .IsRequired();

            builder.HasOne(x => x.Room)
                   .WithMany(x => x.Bookings)
                   .HasForeignKey(x => x.RoomId)
                   .HasConstraintName("FK_Room_Booking");

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Bookings)
                   .HasForeignKey(x => x.UserId)
                   .HasConstraintName("FK_User_Booking");
        }
    }
}
