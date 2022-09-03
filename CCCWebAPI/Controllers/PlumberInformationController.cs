﻿using CCCWebAPI.ApiShare;
using CCCWebAPI.Models.ViewModels;
using CCCWebAPI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlumberInformationController : Controller
    {
        #region Declarations
        private IPlumberInformationRepository _db;
        #endregion

        #region Constructor
        public PlumberInformationController(IPlumberInformationRepository db)
        {
            _db = db;
        }
        #endregion
        #region Methods
        [HttpGet]
        [Route("GetPlumInformation")]
        public IActionResult GetPlumInformation(int searchcriteria)
        {
            ActionResponse<Object> result;
            try
            {
                var data = _db.GetPlumbInfo(searchcriteria);
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
        [Route("AddUpdatePlumberInfo")]
        public async Task<IActionResult> AddUpdatePlumberInfo(IndividualInfoVM addInfoDetailsVM)
        {
            ActionResponse<Object> JSOnresult;

            int result = 0;
            try
            {
                result = _db.AddUpdatePlumberInfo(addInfoDetailsVM);
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
        [Route("DeletePlumberInfo")]
        public async Task<IActionResult> DeletePlumberInfo(int houseNumber)
        {
            ActionResponse<Object> JSOnresult;

            int result = 0;
            try
            {
                result = _db.DelPlumberInfo(houseNumber);
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
