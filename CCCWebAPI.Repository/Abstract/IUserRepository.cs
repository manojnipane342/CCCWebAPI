using CCCWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCCWebAPI.Repository.Abstract
{
    public interface IUserRepository
    {
        public string LoginUser(string EmailId, string Password);
        public int signUpUser(UsersSignupVM model);
        public int confirpassword(confirmPassVM model);
    }
}
