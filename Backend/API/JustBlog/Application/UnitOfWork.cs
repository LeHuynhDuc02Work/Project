using Application.Contracts;
using Core;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private IPostTagMapRepository _postTagMapRepository;
        private ITagRepository _tagRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);

        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_dbContext);

        public IPostTagMapRepository PostTagMapRepository => _postTagMapRepository ??= new PostTagMapRepository(_dbContext);

        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_dbContext);
    }
}