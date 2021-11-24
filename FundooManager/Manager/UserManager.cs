using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public string Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public string LogIn(LoginModel login)
        {
            try
            {
                return this.repository.LogIn(login);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string ResetPassword(ResetPasswordModel userData)
        {
            try
            {
                return this.repository.ResetPassword(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ForgottenPassword(string email)
        {
            try
            {
                return this.repository.ForgottenPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
