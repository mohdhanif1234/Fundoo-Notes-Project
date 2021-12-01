// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohammad Hanif"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using FundooRepository.Interface;

    /// <summary>
    /// This is a class for UserManager
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// Object created for IUserRepository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the UserManager class
        /// </summary>
        /// <param name="repository">The parameter passed is the object of the IUserRepository class</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// This methods implements the login functionality
        /// </summary>
        /// <param name="userData">This parameter represents the entire user data</param>
        /// <returns>This methods returns the result of the Register functionality in the form of a string</returns>
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

        /// <summary>
        /// This method implements the Login functionality
        /// </summary>
        /// <param name="login">Login model is passed as a parameter</param>
        /// <returns>This methods returns the result of the Login functionality in the form of a string</returns>
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

        /// <summary>
        /// This method resets the password for the user registration functionality
        /// </summary>
        /// <param name="userData">This parameter represents the entire user data</param>
        /// <returns>This methods returns the result of the Reset Password functionality in the form of a string</returns>
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

        /// <summary>
        /// This method is implements the forget password functionality
        /// </summary>
        /// <param name="email">This parameter represents an Email where the new password is to be sent</param>
        /// <returns>This methods returns the result of the Forget Password functionality in the form of a string</returns>
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

        /// <summary>
        /// This method generates the JWT for the user login functionality.
        /// </summary>
        /// <param name="email">This parameter represents an email whose JWT is to be generated</param>
        /// <returns>It returns a JWT in the form of an encrypted string</returns>
        public string JWTGenerator(string email)
        {
            try
            {
                return this.repository.JWTGenerator(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
