using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Address.API.Infrastructure.EntityConfigurations
{
    public class AddressEntityTypeConfiguration
        : IEntityTypeConfiguration<Model.Address>
    {
        int NameLenght = 100;
        int AddressLenght = 150;
        public void Configure(EntityTypeBuilder<Model.Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(ci => ci.Id);
            
            builder.Property(cb => cb.Country)
           .HasMaxLength(AddressLenght);
            builder.Property(cb => cb.City)
           .HasMaxLength(AddressLenght);
            builder.Property(cb => cb.StreetAddress)
           .HasMaxLength(AddressLenght);
        }
    }
}
