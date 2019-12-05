using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DABAssignment3.Controllers.Request;
using DABAssignment3.Controllers.Response;
using DABAssignment3.Models;
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
        private readonly IMapper _mapper;

        public CircleController(CircleService circleService, IMapper mapper)
        {
            _CircleService = circleService;
            _mapper = mapper;
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
        public IActionResult Post([FromBody] CircleRequest name)
        {
            var circle = _mapper.Map<Circle>(name);
            var result = _CircleService.Create(circle);
            return Ok(_mapper.Map<CircleResponse>(result));
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
