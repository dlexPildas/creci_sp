using CreciSP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreciSP.Repository.Mapping
{
    public class LogNotifyMapping : IEntityTypeConfiguration<LogNotify>
    {
        public void Configure(EntityTypeBuilder<LogNotify> builder)
        {
            builder.ToTable("LogNotify");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.Property(x => x.ActionDate)
                   .IsRequired();

            builder.Property(x => x.IsViewed)
                   .IsRequired();

            builder.Property(x => x.Message)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.HasOne(x => x.ToUser)
                   .WithMany(x => x.LogNotifies)
                   .HasForeignKey(x => x.ToUserId)
                   .HasConstraintName("FK_ToUser_LogNotify");

            
        }
    }
}
