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
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Tag>))]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _tagService.GetAll(page));
        }

        [HttpGet("{tagId}")]
        [ProducesResponseType(200, Type = typeof(Tag))]
        public async Task<IActionResult> GetTagById(Guid tagId)
        {
            return Ok(await _tagService.GetTagById(tagId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromForm] TagDto tagCreate)
        {
            return Ok(await _tagService.CreateTag(tagCreate));
        }

        [HttpPut("{tagId}")]
        public async Task<IActionResult> UpdateTag(Guid tagId, [FromForm] TagDto tagUpdate)
        {
            return Ok(await _tagService.UpdateTag(tagId, tagUpdate));
        }

        [HttpDelete("{tagId}")]
        public async Task<IActionResult> DeleteTag(Guid tagId)
        {
            return Ok(await _tagService.DeleteTag(tagId));
        }
    }
}