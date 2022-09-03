using AutoMapper;
using Common.Models;
using Common.ViewModel;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Implementation
{
    public class UsersManager : IUserManager<UserModel>
    {
        private Data.Repositories.Interfaces.IRepository<UserModel> _repository { get; set; }
        private Data.Repositories.Interfaces.IRepository<RoleModel> _Rolerepository { get; set; }
        private IWebHelper _webHelper;
        private IConfiguration _config;
        private readonly IMapper _mapper;

        public UsersManager(
            Data.Repositories.Interfaces.IRepository<UserModel> repository
            , Data.Repositories.Interfaces.IRepository<RoleModel> Rolerepository
            , IWebHelper webHelper, IConfiguration config, IMapper mapper)
        {
            _repository = repository;
            _Rolerepository = Rolerepository;
            _webHelper = webHelper;
            _config = config;
            _mapper = mapper;
        }

        public UserModel Get(int id)
        {
            return _repository.GetById(id);
        }

        public List<UserModel> GetList()
        {
            return _repository.Table.Where(w => w.IsActive == true && w.IsDelete == false).ToList();
        }

        public UserModel Create(UserModel usermaster)
        {
            if (string.IsNullOrEmpty(usermaster.FirstName))
                throw new ArgumentNullException("Please enter First Name");

            if (string.IsNullOrEmpty(usermaster.LastName))
                throw new ArgumentNullException("Please enter Last Name");

            if (string.IsNullOrEmpty(usermaster.Email))
                throw new ArgumentNullException("Please enter Email Id");

            return _repository.Create(usermaster);
        }

        public void Update(UserModel usermaster)
        {
            _repository.Update(usermaster);
        }

        public void Delete(int id) => _repository.DeleteById(id);

        public UserModelVM LoginUser(string EmailId, string Password)
        {
            if (string.IsNullOrEmpty(EmailId))
                throw new ArgumentNullException("Please enter Email Id");

            if (string.IsNullOrEmpty(Password))
                throw new ArgumentNullException("Please enter Password");


            var user = _repository.Table.FirstOrDefault(u => u.Email.ToLower().Trim().Equals(EmailId));
            UserModelVM userInfo = _mapper.Map<UserModelVM>(user);

            if (userInfo != null)
            {
                if (userInfo.IsActive == true)
                {
                    if (userInfo.IsDelete == true)
                        throw new ArgumentNullException("Oops! Your account is Deleted");

                    var salt = userInfo.PasswordSalt;
                    var pass = _webHelper.ComputeHash(Password, salt);
                    if (userInfo.Password != pass)

                        throw new ArgumentNullException("Oops! Invalid Username or Password");
                }
                else
                {
                    throw new ArgumentNullException("Oops! Your account is not activated. Please contact Administrator to activate your account.");
                }
                var tokenString = generateJwtToken(userInfo);
                userInfo.Token = tokenString;
            }
            else
            {
                throw new ArgumentNullException("Oops! Invalid Username or Password.");
            }
            return userInfo;
        }

        public bool UpdateUserDeviceTokenId(int UserId, string DeviceTokenId)
        {
            try
            {

                var UserDetails = _repository.Table.FirstOrDefault(p => p.Id == UserId);
                if (UserDetails != null)
                {
                    UserDetails.DeviceTokenId = DeviceTokenId;
                    _repository.Update(UserDetails);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string generateJwtToken(UserModelVM user)
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["AppSettings:Issuer"], _config["AppSettings:Issuer"], claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(token);


        }


    }
}