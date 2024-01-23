using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Post>> GetAll(string keyWord)
        {
            if (string.IsNullOrEmpty(keyWord))
                return await _context.Posts.ToListAsync();
            return await _context.Posts
            .Include(p => p.Category)
            .Include(p => p.PostTags)
            .ThenInclude(pt => pt.Tag)
            .Where(p => p.Title.Contains(keyWord) || p.ShortDescription.Contains(keyWord) || p.PostTags.Any(pt => pt.Tag.Name.Contains(keyWord)))
            .ToListAsync();
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == postId);
        }

        public bool Exists(Guid postId)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == postId);
            return post != null;
        }
    }
}