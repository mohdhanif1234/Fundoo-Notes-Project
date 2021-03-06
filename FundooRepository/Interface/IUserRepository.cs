using FundooModel;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface IUserRepository
    {
        string Register(RegisterModel userData);
        string LogIn(LoginModel logIn);
        string ResetPassword(ResetPasswordModel userData);
        string ForgottenPassword(string email);
        string JWTGenerator(string email);
    }
}