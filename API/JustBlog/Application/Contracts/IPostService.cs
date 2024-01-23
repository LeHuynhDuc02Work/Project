using Application.Dtos;

namespace Application.Contracts
{
    public interface IPostService
    {
        Task<ICollection<PostViewDto>> GetAll(string keyWord ,int page);

        Task<PostViewDto> GetPostById(Guid postId);

        Task<PostViewDto> CreatePost(PostDto postCreate);

        Task<PostViewDto> UpdatePost(Guid postId, PostDto postUpdate);

        Task<bool> DeletePost(Guid postId);

    }
}