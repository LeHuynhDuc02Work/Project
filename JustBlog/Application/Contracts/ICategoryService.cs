using Application.Dtos;

namespace Application.Contracts
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryViewDto>> GetAll(string keyWord ,int page);

        Task<CategoryViewDto> GetCategoryById(Guid categoryId);

        Task<CategoryViewDto> CreateCategory(CategoryDto categoryCreate);

        Task<CategoryViewDto> UpdateCategory(Guid categoryId, CategoryDto categoryUpdate);

        Task<bool> DeletePostsByCategoryId(Guid categoryId);

    }
}