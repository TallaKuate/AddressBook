using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.User.API.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Design;

namespace Microservices.User.API.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<Model.DomainUser> Users { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DomainUserEntityTypeConfiguration()); 
        }
    }

    public class UserContextDesignFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>()
                .UseSqlServer("Server=.;Microservices.UserDb;Integrated Security=true");
            return new UserContext(optionsBuilder.Options);
        }
    }


    
}
