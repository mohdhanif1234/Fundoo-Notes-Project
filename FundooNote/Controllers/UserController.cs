using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                string result = this.manager.Register(userData);

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
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/login")]
        public IActionResult LogIn([FromBody] LoginModel login)
        {
            try
            {
                string result = this.manager.LogIn(login);

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
                        Email = login.Email
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
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                string result = this.manager.ResetPassword(reset);

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
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/forgetpassword")]
        public IActionResult ForgottenPassword(string email)
        {
            try
            {
                string result = this.manager.ForgottenPassword(email);

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
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
