using Microservices.User.API.Controllers;
using Microservices.User.API.Infrastructure;
using Microservices.User.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.User.UnitTests
{
    public class UserControllerTest
    {
        private readonly DbContextOptions<UserContext> _dbOptions;

        public UserControllerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using (var dbContext = new UserContext(_dbOptions))
            {
                dbContext.AddRange(UserContextDbSeed.GetData());
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Get_user_success()
        {
            //Arrange
            var userId = 5;
            var firstname = "Any";
            var lastname = "Body";
            var catalogContext = new UserContext(_dbOptions);

            //Act
            var testController = new DomainUserController(catalogContext);
            var actionResult = await testController.GetUserByIdAsync(userId).ConfigureAwait(false);

            //Assert
            Assert.IsType< ActionResult<DomainUser>>(actionResult);
            var result = Assert.IsAssignableFrom<DomainUser>(actionResult.Value);
            Assert.Equal(userId, result.Id);
            Assert.Equal(firstname.ToUpper(), result.Firstname.ToUpper());
            Assert.Equal(lastname.ToUpper(), result.Lastname.ToUpper());
        }

    }

}
