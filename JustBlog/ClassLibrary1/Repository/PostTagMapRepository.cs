using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class PostTagMapRepository : BaseRepository<PostTagMapRepository>, IPostTagMapRepository
    {
        private readonly ApplicationDbContext _context;

        public PostTagMapRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> LinkTagsToPost(Guid postId, ICollection<Guid> tagIds)
        {
            var post = _context.Posts.Include(p => p.PostTags).FirstOrDefault(p => p.Id == postId);
            post.PostTags.Clear();
            foreach (var tagId in tagIds)
            {
                var tag = _context.Tags.Find(tagId);
                if (tag != null)
                {
                    post.PostTags.Add(new PostTagMap { Post = post, Tag = tag });
                }
            }
            return await SaveChange();
        }

        public async Task<bool> UnlinkTagFromPost(Guid postId, Guid tagId)
        {
            var post = await _context.Posts.Include(p => p.PostTags).FirstOrDefaultAsync(p => p.Id == postId);
            var postTagMap =  post.PostTags.FirstOrDefault(pt => pt.Tag_id == tagId);
            post.PostTags.Remove(postTagMap);
            return await SaveChange();
        }

        public async Task<ICollection<Tag>> GetTagsForPost(Guid postId)
        {
            var post = await _context.Posts.Include(p => p.PostTags).ThenInclude(pt => pt.Tag).FirstOrDefaultAsync(p => p.Id == postId);
            var tags = post.PostTags.Select(pt => pt.Tag).ToList();
            return tags;
        }

        public bool PostExists(Guid postId)
        {
            var postIds = _context.PostTagsMaps.FirstOrDefault(x => x.Post_id == postId);
            return postIds != null;
        }

        public bool TagExists(Guid tagId)
        {
            var tagIds = _context.PostTagsMaps.FirstOrDefault(x => x.Tag_id == tagId);
            return tagIds != null;
        }

        public bool PostTagExists(Guid postId, Guid tagId)
        {
            var postTagMap = _context.PostTagsMaps.FirstOrDefault(x => x.Post_id == postId && x.Tag_id == tagId);
            return postTagMap != null;
        }

        public Task<bool> UpdatePostTags(Guid postId, List<Guid> tagIds)
        {
            var post = _context.Posts.Include(p => p.PostTags).FirstOrDefault(p => p.Id == postId);
            post.PostTags.Clear();
            foreach (var tagId in tagIds)
            {
                var tag = _context.Tags.FirstOrDefault(t => t.Id == tagId);
                if (tag != null)
                {
                    post.PostTags.Add(new PostTagMap { Post_id = postId, Tag_id = tagId });
                }
            }
            return SaveChange();
        }

        public Task<bool> DeleteAllRelatedTags(Guid postId)
        {
            var postTagMaps = _context.PostTagsMaps.Where(ptm => ptm.Post_id == postId).ToList();
            _context.PostTagsMaps.RemoveRange(postTagMaps);
            return SaveChange();
        }
    }
}