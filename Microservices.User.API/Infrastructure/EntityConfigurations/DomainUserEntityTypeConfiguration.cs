using Microservices.User.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.User.API.Infrastructure.EntityConfigurations
{
    public class DomainUserEntityTypeConfiguration
        : IEntityTypeConfiguration<DomainUser>
    {
        int NameLenght = 100;
        public void Configure(EntityTypeBuilder<DomainUser> builder)
        {
            builder.ToTable("DomainUser");
            builder.HasKey(ci => ci.Id);
            builder.Property(cb => cb.Firstname)
                .IsRequired()
                .HasMaxLength(NameLenght);
            builder.Property(cb => cb.Lastname)
               .IsRequired()
               .HasMaxLength(NameLenght);
        }
    }
}
