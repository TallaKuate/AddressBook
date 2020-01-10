
using Microservices.Address.API.Controllers;
using Microservices.Address.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Microservices.Address.UnitTests
{
    public class AddressControllerTest
    {
        private readonly DbContextOptions<AddressContext> _dbOptions;

        public AddressControllerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<AddressContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using (var dbContext = new AddressContext(_dbOptions))
            {
                dbContext.AddRange(AddressContextDbSeed.GetData());
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Get_Address_success()
        {
            //Arrange
            var addressId = 5;  
            var city = "London";  
            var catalogContext = new AddressContext(_dbOptions);

            //Act
            var testController = new AddressController(catalogContext);
            var actionResult = await testController.GetAddressByIdAsync(addressId).ConfigureAwait(false);

            //Assert
            Assert.IsType<ActionResult< Microservices.Address.API.Model.Address >>(actionResult);
            var result = Assert.IsAssignableFrom< Microservices.Address.API.Model.Address> (actionResult.Value);
            Assert.Equal(addressId, result.Id);
            Assert.Equal(city.ToUpper(), result.City.ToUpper());
        }

    }

    
}
