using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microservices.API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservices.API.Gateways.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressBookService)
        {
            _addressService = addressBookService;
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Model.Address), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Model.Address>> GetAddressByIdAsync(int id)
        {
            var result = await _addressService.GetAddressByIdAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                return BadRequest($"No user address found for id");
            }
            return result;
        }
    }
}
