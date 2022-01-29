using Api_Customer_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Customer_Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(2);
            builder.Property(a => a.ZipCode)
                .IsRequired();
        }
    }
}
