// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="KPMG">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohammad Hanif"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooManager.Interface
{
    using FundooModel;

    /// <summary>
    /// This is an interface of the UserManager class
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// This methods implements the login functionality
        /// </summary>
        /// <param name="userData">This parameter represents the entire user data</param>
        /// <returns>This methods returns the result of the Register functionality in the form of a string</returns>
        string Register(RegisterModel userData);

        /// <summary>
        /// This method implements the Login functionality
        /// </summary>
        /// <param name="login">Login model is passed as a parameter</param>
        /// <returns>This methods returns the result of the Login functionality in the form of a string</returns>
        string LogIn(LoginModel login);

        /// <summary>
        /// This method resets the password for the user registration functionality
        /// </summary>
        /// <param name="userData">This parameter represents the entire user data</param>
        /// <returns>This methods returns the result of the Reset Password functionality in the form of a string</returns>
        string ResetPassword(ResetPasswordModel userData);
        
        // <summary>
        /// This method is implements the forget password functionality
        /// </summary>
        /// <param name="email">This parameter represents an Email where the new password is to be sent</param>
        /// <returns>This methods returns the result of the Forget Password functionality in the form of a string</returns>
        string ForgottenPassword(string email);

        /// <summary>
        /// This method generates the JWT for the user login functionality.
        /// </summary>
        /// <param name="email">This parameter represents an email whose JWT is to be generated</param>
        /// <returns>It returns a JWT in the form of an encrypted string</returns>
        string JWTGenerator(string email);
    }
}