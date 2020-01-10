using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microservices.AddressBook.API.Infrastructure;
using Microservices.AddressBook.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Microservices.AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly AddressBookContext _context;

        public AddressBookController(AddressBookContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<CountryAddressBook>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CountryAddressBook>>> GetAddressBookAsync()
        {
            var result = new List<CountryAddressBook>();

            var userAddresses = await _context.UserAddresses.ToListAsync().ConfigureAwait(false);

            var ContryUserAddresses = userAddresses.GroupBy(x => x.City.ToUpper());

            foreach (var country in ContryUserAddresses.ToList())
            {
                result.Add(new CountryAddressBook
                {
                    City = country.Key,
                    userAddresses = country.ToList()
                });
            }

            return result;
        }
    }
}
