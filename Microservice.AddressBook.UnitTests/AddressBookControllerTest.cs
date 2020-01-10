using Microservices.AddressBook.API.Controllers;
using Microservices.AddressBook.API.Infrastructure;
using Microservices.AddressBook.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Microservice.AddressBook.UnitTests
{
    public class AddressBookControllerTest
    {
        private readonly DbContextOptions<AddressBookContext> _dbOptions;

        public AddressBookControllerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<AddressBookContext>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using (var dbContext = new AddressBookContext(_dbOptions))
            {
                dbContext.AddRange(AddressBookContextDbSeed.GetData());
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Get_AddressBook_success()
        {
            //Arrange
       
            var catalogContext = new AddressBookContext(_dbOptions);

            //Act
            var testController = new AddressBookController(catalogContext);
            var actionResult = await testController.GetAddressBookAsync().ConfigureAwait(false);

            //Assert
            Assert.IsType<ActionResult<List<CountryAddressBook>>>(actionResult);
            var result = Assert.IsAssignableFrom<List<CountryAddressBook>>(actionResult.Value);
            Assert.Equal(3,  result.Count);
        }

    }


}
