using Application.Contracts;
using Application.Dtos;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> SignIn(SignInDto signInDto)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.SignInAsync(signInDto);
                if (string.IsNullOrEmpty(result))
                    return "Account information or password is incorrect";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> SignUp(SignUpDto signUpDto)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.SignUpAsync(signUpDto);
                if (result.Succeeded)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            
        }
    }
}