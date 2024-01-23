using Application.Contracts;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostTagMapsController : Controller
    {
        private readonly IPostTagService _postTagService;

        public PostTagMapsController(IPostTagService postTagService)
        {
            _postTagService = postTagService;
        }

        [HttpGet("{postId}/Tags")]
        [ProducesResponseType(200, Type = typeof(ICollection<Tag>))]
        public async Task<IActionResult> GetTagsByPostId(Guid postId, int page = 1)
        {
            return Ok(await _postTagService.GetTagsByPostId(postId, page));
        }

        [HttpPost("/post/{id}/tags")]
        public async Task<IActionResult> LinkTagsToPost(Guid postId, [FromForm] ICollection<Guid> tagIds)
        {
            return Ok(await _postTagService.LinkTagsToPost(postId, tagIds));
        }

        [HttpDelete("{postId}/tags/{tagId}")]
        public async Task<IActionResult> UnlinkTagFromPost(Guid postId, Guid tagId)
        {
            return Ok(await _postTagService.UnlinkTagFromPost(postId, tagId));
        }

        [HttpPut("{postId}/tags")]
        public async Task<IActionResult> UpdatePostTags(Guid postId, List<Guid> tagIds)
        {
            return Ok(await _postTagService.UpdatePostTags(postId, tagIds));
        }

        [HttpDelete("{postId}/Tags")]
        public async Task<IActionResult> DeletePostTag(Guid postId)
        {
            return Ok(await _postTagService.DeletePostTag(postId));
        }
    }
}