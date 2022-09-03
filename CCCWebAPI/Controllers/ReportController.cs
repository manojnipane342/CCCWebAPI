using CCCWebAPI.Model;
using CCCWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCCWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("ManageBusinessAccount")]
        public ServiceResponse<confirmPassVM> ManageBusinessAccount(confirmPassVM model)
        {
            var response = new ServiceResponse<confirmPassVM>();
            try
            {
                if (model.NewPassword != model.ConfirmPassword)
                {
                    response.Message = "New Password and Confirm Password is not match";
                    response.Success = false;
                    return response;
                }
                //int user = _user.confirpassword(model);
                //if (user == 1)
                //{
                //    response.Message = "Succefully Registration";
                //    //response.Data = user;
                //    response.Success = true;
                //}
                //else
                //{
                //    response.Message = "User is not exits";
                //    //response.Data = user;
                //    response.Success = false;
                //}
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }
}
