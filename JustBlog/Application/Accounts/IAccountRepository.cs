using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Repository.Contracts
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpDto model);

        public Task<string> SignInAsync(SignInDto model);
    }
}