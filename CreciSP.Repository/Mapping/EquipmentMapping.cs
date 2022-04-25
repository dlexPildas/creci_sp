using CreciSP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreciSP.Repository.Mapping
{
    public class EquipmentMapping : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)                 
                   .IsRequired();

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(255)
                   .IsRequired();
            
            builder.HasOne(x => x.Room)
                   .WithMany(x => x.Equipments)
                   .HasForeignKey(x => x.RoomId)
                   .HasConstraintName("FK_Room_Equipment");
        }
    }
}
