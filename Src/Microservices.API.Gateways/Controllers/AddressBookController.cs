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
    public class AddressBookController : ControllerBase
    {

        private readonly IAddressBookService _addressBookService; 

        public AddressBookController(IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService; 
        }

       
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<CountryAddressBook>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CountryAddressBook>>> GetAddressBook()
        {
            var result  = await _addressBookService.GetAddressBookAsync().ConfigureAwait(false);

            if (result == null)
            {
                return BadRequest($"No user address found.");
            }
            return result;
        }



    }
}
