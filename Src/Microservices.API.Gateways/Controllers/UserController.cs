using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microservices.API.Gateways.Model;
using Microservices.API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservices.API.Gateways.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userSrevice;

        public UserController(IUserService userSrevice)
        {
            _userSrevice = userSrevice;
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DomainUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DomainUser>> GetUserByIdAsync(int id)
        {
            var result = await _userSrevice.GetUserByIdAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                return BadRequest($"No user found for id");
            }
            return result;
        }



    }
}
