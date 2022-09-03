using CCCWebAPI.ApiShare;
using CCCWebAPI.Models.ViewModels;
using CCCWebAPI.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CCCWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class IndividualInfoController : Controller
    {
        #region Declarations
        private IIndividualInfoRepository _db;
        private IPlumberInformationRepository _plumberdb;
        #endregion

        #region Constructor
        public IndividualInfoController(IIndividualInfoRepository db, IPlumberInformationRepository plumberdb)
        {
            _db = db;
            _plumberdb = plumberdb;
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetIndividualInfo")]
        public IActionResult GetIndividualInfo(int searchcriteria)
        {
            ActionResponse<Object> result;
            try
            {
                var data = _db.GetIndividualInfo(searchcriteria);
                if (data == null)
                {
                    result = new ActionResponse<Object>(true, String.Empty, null, (int)HttpStatusCode.NotFound);
                    return new JsonResult(result);
                }
                else
                {
                    result = new ActionResponse<Object>(false, String.Empty, data, (int)HttpStatusCode.OK);
                    return new JsonResult(result);
                }
            }
            catch (Exception ex)
            {
                result = new ActionResponse<Object>(true, string.Concat("Error!..", ex.Message), null, (int)HttpStatusCode.InternalServerError);
                return new JsonResult(result);
            }
        }
        [HttpPost]
        [Route("AddUpdateIndividualInfo")]
        public async Task<IActionResult> AddUpdateIndividualInfo(IndividualInfoVM individualInfoDetailsVM)
        {
            ActionResponse<Object> JSOnresult;

            int result = 0;
            try
            {

                result = _db.AddUpdateIndividualInfo(individualInfoDetailsVM);
                JSOnresult = new ActionResponse<Object>(false, String.Empty, result, (int)HttpStatusCode.OK);
                return new JsonResult(JSOnresult);

            }
            catch (Exception e)
            {
                JSOnresult = new ActionResponse<Object>(true, string.Concat("Error!..", e.Message), result, (int)HttpStatusCode.InternalServerError);
                return new JsonResult(JSOnresult);
            }

        }
        [HttpPost]
        [Route("DeleteIndividualInfo")]
        public async Task<IActionResult> DeleteIndividualInfo(int id)
        {
            ActionResponse<Object> JSOnresult;

            int result = 0;
            try
            {
                result = _db.DelIndividualInfo(id);
                JSOnresult = new ActionResponse<Object>(false, String.Empty, result, (int)HttpStatusCode.OK);
                return new JsonResult(JSOnresult);
            }
            catch (Exception e)
            {
                JSOnresult = new ActionResponse<Object>(true, string.Concat("Error!..", e.Message), result, (int)HttpStatusCode.InternalServerError);
                return new JsonResult(JSOnresult);
            }
        }
        #endregion
    }
}
