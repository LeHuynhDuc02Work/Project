using Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpDto model);

        public Task<string> SignInAsync(SignInDto model);
    }
}
