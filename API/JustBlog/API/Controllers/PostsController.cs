using Application.Contracts;
using Application.Dtos;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Post>))]
        public async Task<IActionResult> GetAll(string? keyWord, int page = 1)
        {
            return Ok(await _postService.GetAll(keyWord, page));
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            return Ok(await _postService.GetPostById(postId));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] PostDto postCreate)
        {
            return Ok(await _postService.CreatePost(postCreate));
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(Guid postId, [FromForm] PostDto postUpdate)
        {
            return Ok(await _postService.UpdatePost(postId, postUpdate));
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            return Ok(await _postService.DeletePost(postId));
        }
    }
}