using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microservices.User.API.Infrastructure;
using Microservices.User.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Microservices.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainUserController : ControllerBase
    {
        private readonly UserContext _context;

        public DomainUserController(UserContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DomainUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DomainUser>> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var users = await _context.Users.SingleOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (users is null)
            {
                return NotFound();
            }

            return users;
        }
    }
}
