using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Controllers.Request;
using DABAssignment3.Controllers.Response;
using DABAssignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DABAssignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly ICircleService _CircleService;

        public CircleController(CircleService circleService)
        {
            _CircleService = circleService;
        }
        // GET: api/Circle
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Circle/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Circle
        [HttpPost]
        public IActionResult<CircleResponse> Post([FromBody] CircleRequest name)
        {
            _CircleService.Create(name);
        }

        // PUT: api/Circle/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
