using Application.Dtos;
using System.Collections.ObjectModel;

namespace Application.Contracts
{
    public interface IPostTagService
    {
        Task<Collection<TagViewDto>> GetTagsByPostId(Guid postId, int page);

        Task<bool> LinkTagsToPost(Guid postId, ICollection<Guid> tagIds);

        Task<bool> UnlinkTagFromPost(Guid postId, Guid tagId);

        Task<bool> UpdatePostTags(Guid postId, List<Guid> tagIds);

        Task<bool> DeletePostTag(Guid postId);
    }
}