using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Tag>> GetAll()
        {
            return await _context.Tags.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Tag> GetTagById(Guid tagId)
        {
            return await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagId);
        }

        public bool Exists(Guid tagId)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == tagId);
            return tag != null;
        }
    }
}