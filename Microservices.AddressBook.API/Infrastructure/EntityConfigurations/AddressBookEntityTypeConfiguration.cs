
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.AddressBook.API.Infrastructure.EntityConfigurations
{
    public class AddressBookEntityTypeConfiguration
         : IEntityTypeConfiguration<Model.AddressBook>
    {
        int NameLenght = 100;
        int AddressLenght = 150;
        public void Configure(EntityTypeBuilder<Model.AddressBook> builder)
        {
            builder.ToTable("AddressBook");
            builder.HasKey(ci => ci.Id);
            builder.Property(cb => cb.Firstname)
                .IsRequired()
                .HasMaxLength(NameLenght);
            builder.Property(cb => cb.Lastname)
               .IsRequired()
               .HasMaxLength(NameLenght);
            builder.Property(cb => cb.Country)
           .HasMaxLength(AddressLenght);
            builder.Property(cb => cb.City)
           .HasMaxLength(AddressLenght);
            builder.Property(cb => cb.StreetAddress)
           .HasMaxLength(AddressLenght);
        }
    }
}
