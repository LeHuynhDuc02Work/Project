using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
                return await _context.Categories.Where(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord)).ToListAsync();
            else
                return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            return await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<bool> DeletePostsByCategoryId(Guid categoryId)
        {
            var posts = _context.Posts.Where(x => x.CategoryId == categoryId);
            _context.RemoveRange(posts);
            return await SaveChange();
        }

        public bool Exists(Guid categoryId)
        {
            var category = _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            return category != null;
        }
    }
}