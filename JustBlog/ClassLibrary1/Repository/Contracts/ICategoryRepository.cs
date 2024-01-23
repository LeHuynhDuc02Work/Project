using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public Task<ICollection<Category>> GetAll(string keyWord);

        public Task<Category> GetCategoryById(Guid categoryId);

        public Task<bool> DeletePostsByCategoryId(Guid categoryId);

        public bool Exists(Guid categoryId);
    }
}