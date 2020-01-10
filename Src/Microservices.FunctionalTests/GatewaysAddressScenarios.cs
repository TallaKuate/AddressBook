using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Micoservices.Address.FunctionalTests
{
    public class GatewaysScenarios
       : GatewaysScenariosBase
    {
      
        [Fact]
        public async Task Get_Address_by_id_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.AddressById(1));

                response.EnsureSuccessStatusCode();
            }
        }

        [Fact]
        public async Task Get_Address_by_id_and_response_bad_request_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.AddressById(int.MinValue));

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_Address_by_id_and_response_not_found_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.AddressById(int.MaxValue));

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}
