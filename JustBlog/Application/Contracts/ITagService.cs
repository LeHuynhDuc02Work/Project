using Application.Dtos;

namespace Application.Contracts
{
    public interface ITagService
    {
        Task<ICollection<TagViewDto>> GetAll(int page);

        Task<TagViewDto> GetTagById(Guid tagId);

        Task<TagViewDto> CreateTag(TagDto tagCreate);

        Task<TagViewDto> UpdateTag(Guid tagId, TagDto tagUpdate);

        Task<bool> DeleteTag(Guid tagId);
    }
}