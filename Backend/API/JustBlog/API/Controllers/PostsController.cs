using Application.Contracts;
using Application.Dtos;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        public async Task<IActionResult> GetAll([FromQuery] InputSearchDto input)
        {
            return Ok(await _postService.GetAll(input));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            return Ok(await _postService.GetPostById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] PostDto postCreate)
        {
            return Ok(await _postService.CreatePost(postCreate));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromForm] PostDto postUpdate)
        {
            return Ok(await _postService.UpdatePost(id, postUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            return Ok(await _postService.DeletePost(id));
        }
    }
}