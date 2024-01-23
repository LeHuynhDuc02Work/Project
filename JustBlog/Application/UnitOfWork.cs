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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private IPostTagMapRepository _postTagMapRepository;
        private ITagRepository _tagRepository;
        private IAccountRepository _accountRepository;

        public UnitOfWork(ApplicationDbContext dbContext,
                          UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          RoleManager<IdentityRole> roleManager,
                          IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);

        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_dbContext);

        public IPostTagMapRepository PostTagMapRepository => _postTagMapRepository ??= new PostTagMapRepository(_dbContext);

        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_dbContext);

        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_userManager, _signInManager, _roleManager, _configuration, _dbContext);
    }
}