using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Micoservices.User.FunctionalTests
{
    public class UserScenarios
       : UserScenariosBase
    {      
        [Fact]
        public async Task Get_User_by_id_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.UserById(1));

                response.EnsureSuccessStatusCode();
            }
        }

        [Fact]
        public async Task Get_User_by_id_and_response_bad_request_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.UserById(int.MinValue));

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_User_by_id_and_response_not_found_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.UserById(int.MaxValue));

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}
