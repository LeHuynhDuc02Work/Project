using Application.Contracts;
using Application.Dtos;
using Application.PaginationHelper;
using AutoMapper;
using Core;
using DataAccess.Repository.Contracts;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private int PageSize = 3;
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryViewDto> CreateCategory(CategoryDto categoryCreate)
        {
            try
            {
                Category category = new Category();
                if (categoryCreate != null)
                {
                    category.Id = Guid.NewGuid();
                    category.Name = categoryCreate.Name;
                    category.Description = categoryCreate.Description;
                    category.UrlSlug = categoryCreate.UrlSlug;
                    await _unitOfWork.CategoryRepository.Create(category);
                    await _unitOfWork.CategoryRepository.SaveChange();
                }
                return _mapper.Map<CategoryViewDto>(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> DeletePostsByCategoryId(Guid categoryId)
        {
            try
            {
                return await _unitOfWork.CategoryRepository.DeletePostsByCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<ICollection<CategoryViewDto>> GetAll(string keyWord, int page)
        {
            try
            {
                var result = await _unitOfWork.CategoryRepository.GetAll(keyWord);
                var categories = _mapper.Map<ICollection<CategoryViewDto>>(result);

                var paginationHelper = new PaginationHelper<CategoryViewDto>();
                var categoriesPagination = paginationHelper.Paginate(categories, page, PageSize);

                return categoriesPagination;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<CategoryViewDto> GetCategoryById(Guid categoryId)
        {
            try
            {
                return _mapper.Map<CategoryViewDto>(await _unitOfWork.CategoryRepository.GetCategoryById(categoryId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<CategoryViewDto> UpdateCategory(Guid categoryId, CategoryDto categoryUpdate)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetCategoryById(categoryId);
                if (categoryUpdate != null && category != null)
                {
                    category.Name = categoryUpdate.Name;
                    category.Description = categoryUpdate.Description;
                    category.UrlSlug = categoryUpdate.UrlSlug;

                    _unitOfWork.CategoryRepository.Update(category);
                    await _unitOfWork.CategoryRepository.SaveChange();
                }
                return _mapper.Map<CategoryViewDto>(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}