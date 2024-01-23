using Application.Contracts;
using Application.Dtos;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[Authorize(Roles = AppRole.Customer)]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = AppRole.Customer)]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        public async Task<IActionResult> GetAll(string? keyWord, int page = 1)
        {
            return Ok(await _categoryService.GetAll(keyWord, page));
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public async Task<IActionResult> GetCategoryById(Guid categoryId)
        {
            return Ok(await _categoryService.GetCategoryById(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryDto categoryCreate)
        {
            return Ok(await _categoryService.CreateCategory(categoryCreate));
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromForm] CategoryDto categoryUpdate)
        {
            return Ok(await _categoryService.UpdateCategory(categoryId, categoryUpdate));
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeletePostsByCategoryId(Guid categoryId)
        {
            return Ok(await _categoryService.DeletePostsByCategoryId(categoryId));
        }
    }
}