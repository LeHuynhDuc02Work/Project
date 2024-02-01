using Application.Contracts;
using Application.Dtos;
using Core;
using Core.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer", Roles = AppRole.Customer)]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        public async Task<IActionResult> GetAll([FromQuery]InputSearchDto input)
        {
            return Ok(await _categoryService.GetAll(input));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryDto categoryCreate)
        {
            return Ok(await _categoryService.CreateCategory(categoryCreate));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromForm] CategoryDto categoryUpdate)
        {
            return Ok(await _categoryService.UpdateCategory(id, categoryUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostsByCategoryId(Guid id)
        {
            return Ok(await _categoryService.DeletePostsByCategoryId(id));
        }
    }
}