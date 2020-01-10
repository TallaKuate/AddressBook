using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Micoservices.AddressBook.FunctionalTests
{
    public class AddressBookScenarios
       : AddressBookScenariosBase
    {
      
        [Fact]
        public async Task Get_AddressBook_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.AddressBook());

                response.EnsureSuccessStatusCode();
            }
        }

      
    }
}
