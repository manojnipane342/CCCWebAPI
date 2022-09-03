using AutoMapper;
using CCCWebAPI.Models.EF_Models;
using CCCWebAPI.Models.ViewModels;
using CCCWebAPI.Repository.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using System.Net;
using Org.BouncyCastle.Utilities.Net;
using Microsoft.AspNetCore.Hosting;

namespace CCCWebAPI.Repository.Repository
{
    public class UserRepository: IUserRepository
    {
        private CCCWebAPIEntities _context;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        private readonly IHostingEnvironment env;
        public UserRepository(CCCWebAPIEntities context, IMapper mapper, IConfiguration config, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
            env = hostingEnvironment;
        }
        public string LoginUser(string EmailId, string Password) {
            var user = _context.TblUsers.Where(u => u.Email == EmailId && u.Password == Password).FirstOrDefault();
            var userInfo = _mapper.Map<TblUsers>(user);
            if (userInfo != null)
            {
                var tokenString = generateJwtToken(userInfo);
                return tokenString;
            }
            else
            {
                throw new ArgumentNullException("Oops! Invalid Username or Password");
            }
           // return userInfo;

        }
        public int signUpUser(UsersSignupVM model)
        {
            if (model != null) {
                TblUsers _infoAdd = new TblUsers();
                _infoAdd.FirstName = model.FirstName;
                _infoAdd.LastName = model.LastName;
                _infoAdd.Email = model.Email;
                _context.TblUsers.Add(_infoAdd);

                _context.SaveChanges();
                //return _infoAdd.Id;
                
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //Random generator = new Random();
                    
                    //TblOtpVerify _otp = new TblOtpVerify();
                    //_otp.Createddate = DateTime.Now;
                    //_otp.ExpiryDate = DateTime.Now;
                    //_otp.UserId = _infoAdd.Id;
                    //_otp.Otp = r;
                    //_otp.Isverify = false;
                    //_context.TblOtpVerify.Add(_otp);
                    //_context.SaveChanges();
                    //var email = new MimeMessage();
                    //email.From.Add(MailboxAddress.Parse("manojshewale079@gmail.com"));
                    //email.To.Add(MailboxAddress.Parse(_infoAdd.Email));
                    //email.Subject = "Test Email Subject";
                    //email.Body = new TextPart(TextFormat.Html) { Text = "Verification Code is = "+ r };

                    //using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
                    //{

                    //    smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    //    smtpClient.Authenticate("manoj.piecode@gmail.com", "manojpc#123");
                    //    smtpClient.Send(email);
                    //    smtpClient.Disconnect(true);
                    //}
                
            if (_infoAdd.Id != null && _infoAdd.Id != 0)
            {
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number  
                int SmtpPortNumber = 587;
                Random generator = new Random();
                String r = generator.Next(0, 100000).ToString("D5");
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Verify Account", "manoj.piecode@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress("Verify Account 2", "manojshewale079@gmail.com"));
                mimeMessage.Subject = "Verify Account";

                var builder = new BodyBuilder();
                builder.HtmlBody = "Otp Of registration ="+ r;
                //foreach (string file in Directory.EnumerateFiles(env.WebRootPath + "\\dimage\\","*",SearchOption.AllDirectories))
                //{
                //    builder.Attach//}ments.Add(file);
                
                mimeMessage.Body = builder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    client.ConnectAsync(SmtpServer, SmtpPortNumber, false).ConfigureAwait(false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.AuthenticateAsync("manoj.piecode@gmail.com", "manojpc#123").ConfigureAwait(false);
                    client.SendAsync(mimeMessage).ConfigureAwait(false);
                    client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            }
            //var user = _context.TblUsers.Where(u => u.Email == EmailId && u.Password == Password).FirstOrDefault();
            //var userInfo = _mapper.Map<UsersSignupVM>(user);
            //if (userInfo != null)
            //{
            //    var tokenString = generateJwtToken(userInfo);
            //    return tokenString;
            //}
            //else
            //{
            //    throw new ArgumentNullException("Oops! Invalid Username or Password");
            //}
            return 1;

        }
        public int confirpassword(confirmPassVM model)
        {
            if (model != null)
            {
                var user = _context.TblUsers.Where(u => u.Id == model.UserId).FirstOrDefault();
                if (user != null)
                {
                    TblUsers _infoAdd = new TblUsers();
                    user.Password = model.ConfirmPassword;
                    _context.TblUsers.Update(user);
                    _context.SaveChanges();
                }
                else {
                    return 0;
                }
            }
            return 1;
        }
        public string generateJwtToken(TblUsers user)
        {
            //var role = _Rolerepository.Table.FirstOrDefault(u => u.RoleID.Equals(user.RoleID));

            // generate token that is valid for 7 days
            var claims = new[] {
                 //new Claim(JwtRegisteredClaimNames.Sub,user.Name),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim(JwtRegisteredClaimNames.NameId, Convert.ToString(user.Id)),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 //new Claim(ClaimTypes.Role,role.RoleName !=null ? role.RoleName :"")

            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Secret").Value));

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string accessToken = tokenHandler.WriteToken(token);

            return accessToken;

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //string accessToken = tokenHandler.WriteToken(token);

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppSettings:Secret"]));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var token = new JwtSecurityToken(_config["AppSettings:Issuer"], _config["AppSettings:Issuer"], claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: creds);


            //return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
