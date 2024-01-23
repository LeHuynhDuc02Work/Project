using Application.Dtos;

namespace Application.Contracts
{
    public interface IAccountService
    {
        Task<bool> SignUp(SignUpDto signUpDto);

        Task<string> SignIn(SignInDto signInDto);
    }
}