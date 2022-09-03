using AutoMapper;
using Common.Models;
using Common.ViewModel;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCCWebAPI.Model;
using Core;
using CCCWebAPI.Repository.Abstract;
using CCCWebAPI.Models.ViewModels;

namespace CCCWebAPI.Controllers.User
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        //private readonly IUserManager<UserModel> _manager;

        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }
        public IUserRepository _user { get; }

        //private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        //private IWebHelper _webHelper;
        private readonly ILogger _Logger;

        public UsersController(
            IUserRepository user
            ,ILoggerFactory DepLoggerFactory
            //, IWebHelper webHelper
            , IMapper mapper
            , IConfiguration configuration
            //, IHostingEnvironment hostingEnvironment
            )
        {
           // _manager = manager;
            _user = user;

           // _webHelper = webHelper;
            _Logger = DepLoggerFactory.CreateLogger("Controllers.UserMasterController");
            _mapper = mapper;

            Configuration = configuration;
            //_hostingEnvironment = hostingEnvironment;
        }



        /// <summary>
        /// This API Use To Verfiy The User By The User Name.
        /// </summary>
        /// <param name="objusername">User Name User to verify the user.</param>
        /// <returns></returns>        
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ServiceResponse<UserModelVM> Login(LoginVM objusername)
        {
            var response = new ServiceResponse<UserModelVM>();
            try
            {

                var user = _user.LoginUser(objusername.Email, objusername.Password);
                if (user != null)
                {

                   // UserModelVM userInfo = _mapper.Map<UserModelVM>(user);

                    response.Message = "Successfully Login";
                    response.Data = user;
                    response.Success = true;
                }
            }
            catch (ArgumentNullException ex)
            {
                response.Success = false;
                response.Message = ex.ParamName;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
            }
            return response;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Registration")]
        public ServiceResponse<UsersSignupVM> registration(UsersSignupVM model) {
            var response = new ServiceResponse<UsersSignupVM>();
            try
            {

                int user = _user.signUpUser(model);
                if (user != null)
                {

                    // UserModelVM userInfo = _mapper.Map<UserModelVM>(user);

                    response.Message = "Please check mail for verify";
                    //response.Data = user;
                    response.Success = true;
                }
            }
            catch (ArgumentNullException ex)
            {
                response.Success = false;
                response.Message = ex.ParamName;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ConfirmPassword")]
        public ServiceResponse<confirmPassVM> ConfirmPassword(confirmPassVM model)
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
                int user = _user.confirpassword(model);
                if (user == 1)
                {
                    response.Message = "Succefully Registration";
                    //response.Data = user;
                    response.Success = true;
                }
                else {
                    response.Message = "User is not exits";
                    //response.Data = user;
                    response.Success = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
        

        /// <summary>
        /// This API Will Be Use TO Get The User Change Password Information By Its User Name.
        /// </summary>
        /// <param name="username">Username Is Use To Fetch the Users.</param>
        /// <param name="Password">Password Is Use To Fetch The User Password.</param>
        /// <returns></returns>
        //[HttpGet]

        //[Route("ChangePassword")]
        //public ServiceResponse<UserModelVM> ChangePassword(string username, string Password)
        //{
        //    var response = new ServiceResponse<UserModelVM>();
        //    try
        //    {
        //        var password = Password;

        //        if (!string.IsNullOrEmpty(password))
        //        {
        //            if (string.IsNullOrEmpty(username))
        //            {
        //                response.Success = false;
        //                response.Message = "Please provide mobile number";
        //                //throw new Exception("Please provide mobile number");
        //            }
        //            else
        //            {
        //                //var user = _manager.VerifyUserByUsername(username);
        //                //if (user != null)
        //                //{
        //                //    var userInfo = _manager.Get(user.UserID);
        //                //    if (!string.IsNullOrEmpty(Password))
        //                //    {
        //                //        string salt = _webHelper.RandomString(_webHelper.RandomStringSize) + "=";
        //                //        string newpassword = _webHelper.ComputeHash(Password, salt, HashName.MD5);

        //                //        userInfo.Password = newpassword;
        //                //        userInfo.PasswordSalt = salt;
        //                //    }
        //                //    _manager.Update(userInfo);

        //                //    user.Password = Password;

        //                //    response.Model = user;
        //                //    response.Success = true;
        //                //    response.Message = "Successfully.";
        //                //}
        //                //else
        //                //{
        //                //    response.Success = false;
        //                //    response.Message = "Invalid user id.";
        //                //}
        //            }
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "Password cannot be empty.";
        //        }
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        response.Success = false;
        //        response.Message = ex.ParamName;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //    }
        //    return response;
        //}

        /// <summary>
        /// This API Will Be Use To Reset The User Password Information By Its Id.
        /// </summary>
        /// <param name="UserId">User Id Is Use To Fetch User Data.</param>
        /// <param name="OldPassword">Old Password Is Used To Fetch Old Password To The User.</param>
        /// <param name="Password">Password Is Used To Set The New Password To User.</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("ResetPassword")]
        //public ServiceResponse<UserModelVM> ResetPassword(int UserId, string OldPassword, string Password)
        //{
        //    var response = new ServiceResponse<UserModelVM>();
        //    try
        //    {
        //        var password = Password;
        //        var userId = UserId;
        //        if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(OldPassword))
        //        {

        //            if (userId <= 0)
        //            {
        //                response.Success = false;
        //                response.Message = "Invalid user id.";
        //                //throw new ArgumentNullException(nameof(userId));
        //            }
        //            else
        //            {
        //                var user = _manager.Get(userId);
        //                if (user != null)
        //                {

        //                    string oldSlat = user.PasswordSalt;
        //                    string currentPasswordHash = _webHelper.ComputeHash(OldPassword, oldSlat, HashName.MD5);
        //                    if (user.Password.Equals(currentPasswordHash))
        //                    {
        //                        string salt = _webHelper.RandomString(_webHelper.RandomStringSize) + "=";
        //                        string newPassword = _webHelper.ComputeHash(password, salt, HashName.MD5);
        //                        user.Password = newPassword;
        //                        user.PasswordSalt = salt;

        //                        _manager.Update(user);


        //                        var userInfo = _mapper.Map<UserModelVM>(user);
        //                        userInfo.Password = password;


        //                        response.Model = userInfo;
        //                        response.Success = true;
        //                        response.Message = "Successfully.";
        //                    }
        //                    else
        //                    {
        //                        response.Success = false;
        //                        response.Message = "Old Password is incorrect.";
        //                    }
        //                }
        //                else
        //                {
        //                    response.Success = false;
        //                    response.Message = "Invalid user id.";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "New Password or Old Password cannot be empty.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //    }
        //    return response;
        //}

        // GET: api/User/5
        /// <summary>
        ///  This API Will Be Use To Get The User Information By Its Id.
        /// </summary>
        /// <param name="id">Id Is Use To Fetch The User By Its Id.</param>
        /// <returns></returns>
        //[HttpGet("{id}")]
        //public Task<ServiceResponse<UserModelVM>> Get(int id)
        //{
        //    var response = new ServiceResponse<UserModelVM>();

        //    try
        //    {
        //        var data = _manager.Get(id);

        //        if (data != null)
        //        {
        //            UserModelVM objUserInfo = _mapper.Map<UserModelVM>(data);

        //            response.Model = objUserInfo;
        //            response.Success = true;
        //            response.Message = "User Service type Information";
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "Unable to fetch User service type information for given Id, Please try with correct Id";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //        //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in fetching User details by id. Please try again.");
        //    }

        //    return Task.FromResult(response);
        //}


        // GET: api/c/
        /// <summary>
        ///  This API Will Be Use To Get All User Information.
        /// </summary>
        /// <returns></returns>       
        // [Authorize(Roles = "Admin")]
        //[Route("All")]
        //[HttpGet]
        //public ServiceResponse<List<UserModelVM>> Get()
        //{

        //    var response = new ServiceResponse<List<UserModelVM>>();

        //    try
        //    {
        //        var data = _manager.GetList();

        //        if (data != null && data.Count > 0)
        //        {
        //            List<UserModelVM> objUserList = new List<UserModelVM>();

        //            foreach (var user in data)
        //            {
        //                UserModelVM objUserInfo = _mapper.Map<UserModelVM>(user);

        //                objUserList.Add(objUserInfo);
        //            }

        //            response.Model = objUserList;
        //            response.Success = true;
        //            response.Message = "User List";
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "Unable to fetch user list, Please Try again";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //        //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in fetching all User. Please try again.");
        //    }

        //    return response;
        //}

        // POST: api/User
        /// <summary>
        /// This API Will Be Use To Insert The New Users In The System. 
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[AllowAnonymous]
        //public Task<ServiceResponse<UserModelVM>> Post([FromForm] UserModelVM UserData)
        //{

        //    var response = new ServiceResponse<UserModelVM>();
        //    //IActionResult Response = Unauthorized();
        //    try
        //    {

        //        UserModel model = _mapper.Map<UserModel>(UserData);

        //        if (!string.IsNullOrEmpty(model.Password))
        //        {
        //            string salt = _webHelper.RandomString(_webHelper.RandomStringSize) + "=";
        //            string password = _webHelper.ComputeHash(model.Password, salt, HashName.MD5);

        //            model.Password = password;
        //            model.PasswordSalt = salt;
        //        }

        //        model.IsActive = true;
        //        model.IsDelete = false;

        //        var data = _manager.Create(model);

        //        UserModelVM objUser = _mapper.Map<UserModelVM>(data);


        //        response.Model = objUser;
        //        response.Success = true;
        //        response.Message = "User created successfully";

        //        //string a = objUser.DatabaseName;
        //        //return Response;


        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        response.Success = false;
        //        response.Message = ex.ParamName;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //        //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in creating User login details. Please try again.");
        //    }

        //    return Task.FromResult(response);

        //}

        // PUT: api/User/5
        /// <summary>
        /// This API Will Be Use To Update The Existing Users Information.
        /// </summary>
        /// <param name="UserData"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //public ServiceResponse<UserModelVM> Put(int id, [FromForm] UserModelVM UserData)
        //{
        //    var response = new ServiceResponse<UserModelVM>();
        //    try
        //    {
        //        var UserInfo = _manager.Get(id);
        //        if (id > 0 && UserInfo != null)
        //        {
        //            string OldPassword = UserInfo.Password;


        //            if (!string.IsNullOrEmpty(UserData.EmployerName))
        //            {
        //                UserInfo.EmployerName = UserData.EmployerName;
        //            }


        //            if (UserData.CreatedBy!=null)
        //            {
        //                UserInfo.CreatedBy = UserData.CreatedBy;
        //            }
        //            if (UserData.ModifyBy!=null)
        //            {
        //                UserInfo.ModifyBy = UserData.ModifyBy;
        //            }



        //            if (!string.IsNullOrEmpty(UserData.Password) && !OldPassword.Equals(UserData.Password))
        //            {
        //                string salt = _webHelper.RandomString(_webHelper.RandomStringSize) + "=";
        //                string password = _webHelper.ComputeHash(UserData.Password, salt, HashName.MD5);

        //                UserInfo.Password = password;
        //                UserInfo.PasswordSalt = salt;
        //            }
        //            UserInfo.IsActive = true;
        //            UserInfo.IsDelete = false;
        //            UserInfo.ModifyDate = DateTime.Now;
        //            _manager.Update(UserInfo);

        //            response.Model = UserData;
        //            response.Success = true;
        //            response.Message = "User updated successfully";
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "Please select valid User Id.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //        //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in updating User. Please try again.");
        //    }
        //    return response;
        //}

        // DELETE: api/User/5
        /// <summary>
        ///  This API Will Be Use To Delete The User From The System. 
        /// </summary>
        /// <param name="id">Id Use To Delete The Data By Its Id.</param>
        /// <returns></returns>
        //[HttpDelete("{id}")]
        //public ServiceResponse<bool> Delete(int id)
        //{
        //    var response = new ServiceResponse<bool>();

        //    try
        //    {
        //        _manager.Delete(id);

        //        response.Model = true;
        //        response.Success = true;
        //        response.Message = "Vendor Service type deleted successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //        //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in deleting User. Please try again.");
        //    }

        //    return response;
        //}

        /// <summary>
        /// This API Will Be Use TO Update User Token ID.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="DeviceTokenId"></param>
        /// <returns></returns>
        //[Route("UpdateUserDeviceTokenId")]
        //[HttpPost]
        //public ServiceResponse<bool> UpdateUserDeviceTokenId(int UserId, string DeviceTokenId)
        //{
        //    var response = new ServiceResponse<bool>();
        //    try
        //    {
        //        bool IsSuccess = _manager.UpdateUserDeviceTokenId(UserId, DeviceTokenId);
        //        if (IsSuccess)
        //        {
        //            response.Model = true;
        //            response.Success = true;
        //            response.Message = "User(s) Device Token updated successfully";
        //        }
        //        else
        //        {
        //            response.Model = false;
        //            response.Success = false;
        //            response.Message = "Unable to update User(s) Device Token";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
        //    }
        //    return response;
        //}

    }
}