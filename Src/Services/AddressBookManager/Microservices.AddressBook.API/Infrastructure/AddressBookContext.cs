using Microservices.AddressBook.API.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.AddressBook.API.Infrastructure
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {
        }
        public DbSet<Model.AddressBook> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressBookEntityTypeConfiguration());
        }
    }

    public class UserContextDesignFactory : IDesignTimeDbContextFactory<AddressBookContext>
    {
        public AddressBookContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AddressBookContext>()
                .UseSqlServer("Server=.;Microservices.AddressBookDb;Integrated Security=true");
            return new AddressBookContext(optionsBuilder.Options);
        }
    }

}
