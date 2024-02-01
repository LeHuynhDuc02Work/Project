using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        public Task<ICollection<Tag>> GetAll();

        public Task<Tag> GetTagById(Guid tagId);

        public bool Exists(Guid tagId);
    }
}