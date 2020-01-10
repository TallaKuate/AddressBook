using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microservices.Address.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Microservices.Address.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressContext _context;

        public AddressController(AddressContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Model.Address), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Model.Address>> GetAddressByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var users = await _context.Addresses.SingleOrDefaultAsync(c => c.Id == id);

            if (users is null)
            {
                return NotFound();
            }

            return users;
        }
    }
}
