using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IPostTagMapRepository : IBaseRepository<PostTagMapRepository>
    {
        public bool TagExists(Guid tagId);

        public bool PostExists(Guid postId);

        public bool PostTagExists(Guid postId, Guid tagId);

        public Task<bool> LinkTagsToPost(Guid postId, ICollection<Guid> tagIds);

        public Task<ICollection<Tag>> GetTagsForPost(Guid postId);

        public Task<bool> UnlinkTagFromPost(Guid postId, Guid tagId);

        public Task<bool> UpdatePostTags(Guid postId, List<Guid> tagIds);

        public Task<bool> DeleteAllRelatedTags(Guid postId);
    }
}