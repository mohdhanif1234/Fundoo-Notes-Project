using Experimental.System.Messaging;
using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        public IConfiguration Configuration { get; }
        public string Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.User.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        // Encrypting the password
                        userData.Password = this.EncryptPassword(userData.Password);
                        // Add the data to the database
                        this.userContext.Add(userData);
                        // Save the change in database
                        this.userContext.SaveChanges();
                        return "Registration Successful";
                    }
                    return "Registration UnSuccessful";
                }
                return "Email Id Already Exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string LogIn(LoginModel logIn)//here class is used as datatype and its parameter
        {
            try
            {
                var validEmail = this.userContext.User.Where(x => x.Email == logIn.Email).FirstOrDefault();
                var validPassword = this.userContext.User.Where(x => x.Password == logIn.Password).FirstOrDefault();
                if (validEmail == null && validPassword == null)
                {
                    return "Login UnSuccessful";
                }
                else
                {
                    return "Login Successful";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public string EncryptPassword(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        public string ResetPassword(ResetPasswordModel userData)
        {
            try
            {
                var validEmailId = this.userContext.User.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmailId != null)
                {
                    validEmailId.Password = EncryptPassword(userData.NewPassword);
                    this.userContext.Update(validEmailId);
                    this.userContext.SaveChanges();
                    return "Password is updated";
                }

                return "Password is not updated, Kindly register yourself first";
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
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("mohd.haniftopia@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from Gmail";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mohd.haniftopia@gmail.com", "agfs1w2.jgihgi");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Email is sent sucessfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string JWTGenerator(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["SecretKey"]); 
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30), 
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler(); 
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
