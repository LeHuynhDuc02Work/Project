using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public Task<ICollection<Post>> GetAll(string keyWord);

        public Task<Post> GetPostById(Guid postId);

        public bool Exists(Guid postId);

    }
}