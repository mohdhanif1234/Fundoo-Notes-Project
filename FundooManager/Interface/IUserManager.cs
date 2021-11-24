using FundooModel;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel userData);
        string LogIn(LoginModel login);
        string ResetPassword(ResetPasswordModel userData);
        string ForgottenPassword(string email);
    }
}