using DataAccess.Repository.Contracts;

namespace Application.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IPostRepository PostRepository { get; }
        IPostTagMapRepository PostTagMapRepository { get; }
        ITagRepository TagRepository { get; }
        IAccountRepository AccountRepository { get; }
    }
}