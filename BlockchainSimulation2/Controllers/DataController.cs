using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainSimulation2.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainSimulation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DataController(DatabaseContext context)
        {
            _context = context;
        }

        // POST: api/Data
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
