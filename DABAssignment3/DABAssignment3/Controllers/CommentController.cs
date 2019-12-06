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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        // GET: api/Comment
        [HttpGet]
        public ActionResult<List<CommentResponse>> Get()
        {
            var comment = _commentService.GetAll();

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CommentResponse>>(comment));
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public ActionResult<CommentResponse> Get(string id)
        {
            var comment = _commentService.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommentResponse>(comment));
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody] CommentRequest request)
        {
            var comment = _mapper.Map<Comment>(request);

            var result = _commentService.Create(comment);

            return Ok(_mapper.Map<CommentResponse>(result));
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CommentRequest request)
        {
            var comment = _mapper.Map<Comment>(request);

            _commentService.Update(id, comment);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _commentService.Remove(id);

            return Ok();
        }
    }
}
