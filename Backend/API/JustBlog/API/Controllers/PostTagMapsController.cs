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

        [HttpGet("{id}/tags")]
        [ProducesResponseType(200, Type = typeof(ICollection<Tag>))]
        public async Task<IActionResult> GetTagsByPostId(Guid id, int page = 1)
        {
            return Ok(await _postTagService.GetTagsByPostId(id, page));
        }

        [HttpPost("/post/{id}/tags")]
        public async Task<IActionResult> LinkTagsToPost(Guid id, [FromForm] ICollection<Guid> tagIds)
        {
            return Ok(await _postTagService.LinkTagsToPost(id, tagIds));
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

        [HttpDelete("{postId}/tags")]
        public async Task<IActionResult> DeletePostTag(Guid postId)
        {
            return Ok(await _postTagService.DeletePostTag(postId));
        }
    }
}