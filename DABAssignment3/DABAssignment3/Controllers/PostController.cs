using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DABAssignment3.Models;
using DABAssignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DABAssignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postservice;
        private readonly IMapper _mapper;

        public PostController(PostService postService, IMapper mapper)
        {
            _postservice = postService;
            _mapper = mapper;
        }
        // GET: api/Post
        [HttpGet]
        public ActionResult<List<PostResponse>> Get()
        {
            var post = _postservice.GetAll();

            if (post == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<PostResponse>>(post));
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public ActionResult<PostResponse> Get(ObjectId id)
        {
            var post = _postservice.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PostResponse>(post));
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromBody] PostRequest request)
        {
            var post = _mapper.Map<Post>(request);

            var result = _postservice.Create(post);
            
            return Ok(_mapper.Map<PostResponse>(result));
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(ObjectId id, [FromBody] PostRequest request)
        {
            var post = _mapper.Map<Post>(request);

            _postservice.Update(id, post);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(ObjectId id)
        {
            _postservice.Remove(id);

            return Ok();
        }
    }
}
