using Api_Customer_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Customer_Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.FisrtName)
                    .IsRequired()
                    .HasMaxLength(50);
                name.Property(n => n.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
            builder.OwnsOne(c => c.Document, document =>
            {
                document.Property(d => d.Number)
                    .IsRequired()
                    .HasMaxLength(11);
                document.Property(d => d.Type)
                    .IsRequired();
            });
        }
    }
}
