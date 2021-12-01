// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohammad Hanif"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNote.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StackExchange.Redis;

    /// <summary>
    /// It is a class for UserController
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Object created for IUserManager
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Object created for ILogger
        /// </summary>
        private readonly ILogger<UserController> logger;

        /// <summary>
        /// Initializes a new instance of the UserController class
        /// </summary>
        /// <param name="manager">It is an object of the IUserManager class</param>
        /// <param name="logger">It is an object of the ILogger class</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// This method is used for User Registration in the web application
        /// </summary>
        /// <param name="userData">userData contains the information about the User</param>
        /// <returns>This methods returns IActionResult for User Registration</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                string result = this.manager.Register(userData);
                this.logger.LogInformation("New user registered successfully with UserId: " + userData.UserId);
                if (result.Equals("Registration Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning("Exception caught while registering new user:" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// This method is used for User Login in the web application
        /// </summary>
        /// <param name="login">login contains the information about the User</param>
        /// <returns>This methods returns IActionResult for User Login</returns>
        [HttpPost]
        [Route("api/login")]
        public IActionResult LogIn([FromBody] LoginModel login)
        {
            try
            {
                string result = this.manager.LogIn(login);
                this.logger.LogInformation("New user logged in successfully with EmailId: " + login.Email);
                if (result.Equals("Login Successful"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");
                    RegisterModel data = new RegisterModel
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = login.Email,
                    };
                    string jwt = this.manager.JWTGenerator(login.Email);
                    return this.Ok(new { Status = true, Message = result, Token = jwt });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning("Exception caught while logging for the new user:" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// This method is used for Password Reset in the web application
        /// </summary>
        /// <param name="reset">reset contains the information about the User</param>
        /// <returns>This methods returns IActionResult for Reset Password</returns>
        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                string result = this.manager.ResetPassword(reset);
                this.logger.LogInformation("Password has been successfully resest for the user with EmailId: " + reset.Email);
                if (result.Equals("Password is updated"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning("Exception caught while reseting the password for the new user:" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// This method is used for retrieving the forgotten password in the web application
        /// </summary>
        /// <param name="email">It is the emailId of the user where we are sending the test email</param>
        /// <returns>This methods returns IActionResult for Forget Password</returns>
        [HttpPost]
        [Route("api/forgetpassword")]
        public IActionResult ForgottenPassword(string email)
        {
            try
            {
                string result = this.manager.ForgottenPassword(email);
                this.logger.LogInformation("Password has been successfully sent to the EmailId: " + email);
                if (result.Equals("Email is sent sucessfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogWarning("Exception caught while sending the password for the new user:" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
