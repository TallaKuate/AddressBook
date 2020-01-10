using Microservices.Address.API.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Address.API.Infrastructure
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {
        }
        public DbSet<Model.Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressEntityTypeConfiguration());
        }
    }

    public class UserContextDesignFactory : IDesignTimeDbContextFactory<AddressContext>
    {
        public AddressContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AddressContext>()
                .UseSqlServer("Server=.;Microservices.AddressDb;Integrated Security=true");
            return new AddressContext(optionsBuilder.Options);
        }
    }
}
