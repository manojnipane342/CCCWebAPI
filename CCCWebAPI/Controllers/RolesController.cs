using AutoMapper;
using Common.Models;
using Common.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Interface;
using CCCWebAPI.Model;
using System.Security.Claims;

namespace CCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController
    {
        private readonly IGetManager<RoleModel> _manager;

        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }
        //private readonly IHostingEnvironment _hostingEnvironment;

        private Core.Interface.IWebHelper _webHelper;
        private readonly ILogger<RolesController> _Logger;

        public RolesController(IGetManager<RoleModel> manager
            , ILogger<RolesController> logger
            //, ILoggerFactory DepLoggerFactory
            , Core.Interface.IWebHelper webHelper
            , IMapper mapper
            , IConfiguration configuration
            //, IHostingEnvironment hostingEnvironment
            )
        {
            _manager = manager;
            _Logger = (ILogger<RolesController>)logger;
            _webHelper = webHelper;
            _mapper = mapper;

            Configuration = configuration;
            //_hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Roles/5
        /// <summary>
        /// This API Will Be Use To Get The Role Information By Its Id. 
        /// This API Information Can Be Use To Link The User With Appropriate Role. 
        /// </summary>
        /// <param name="id">Id Is Use To Fetch The Roles By Its Id.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin,User,Client")]
        public ServiceResponse<RoleModelVM> Get(int id)
        {
            var response = new ServiceResponse<RoleModelVM>();
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int UserId = Convert.ToInt32(user);


                var data = _manager.Get(id);
                if (data != null)
                {
                    RoleModelVM objRolesInfo = _mapper.Map<RoleModelVM>(data);


                    response.Model = objRolesInfo;
                    response.Success = true;
                    response.Message = "Roles Information";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Unable to fetch Roles information for given Id, Please try with correct Id";
                }


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";
            }

            return response;
        }

        // GET: api/Roles/
        /// <summary>
        /// This API Will Be Use To Fetch The All The Roles Which Are Active. 
        /// This API May Use While Register User And Update User Role. 
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        [HttpGet]
        public ServiceResponse<List<RoleModelVM>> Get()
        {

            var response = new ServiceResponse<List<RoleModelVM>>();

            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int UserId = Convert.ToInt32(user);

                var data = _manager.GetList();
                if (data != null && data.Count > 0)
                {
                    List<RoleModelVM> objRolesList = new List<RoleModelVM>();

                    foreach (var Roles in data)
                    {
                        RoleModelVM objRolesInfo = _mapper.Map<RoleModelVM>(Roles);

                        objRolesList.Add(objRolesInfo);
                    }
                    response.Model = objRolesList;
                    response.Success = true;
                    response.Message = "Roles List";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Unable to fetch Roles list, Please Try again";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";
            }

            return response;
        }
    }
}