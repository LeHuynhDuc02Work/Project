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

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Tag))]
        public async Task<IActionResult> GetTagById(Guid id)
        {
            return Ok(await _tagService.GetTagById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromForm] TagDto tagCreate)
        {
            return Ok(await _tagService.CreateTag(tagCreate));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(Guid id, [FromForm] TagDto tagUpdate)
        {
            return Ok(await _tagService.UpdateTag(id, tagUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            return Ok(await _tagService.DeleteTag(id));
        }
    }
}