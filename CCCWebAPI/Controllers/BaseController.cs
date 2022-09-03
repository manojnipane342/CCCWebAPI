using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CCCWebAPI.Controllers
{
    public class BaseController : ControllerBase

    {
        #region Fields

        private readonly IHostingEnvironment _hostingEnvironment;

        public string DomainUrl => (HttpContext.Request.IsHttps ? "https://" : "http://") + HttpContext.Request.Host.Value + "/";

        public string WebRootPath;
        #endregion

        #region Cors

        public BaseController()
        {

        }

        public BaseController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            WebRootPath = _hostingEnvironment.WebRootPath;
        }
        #endregion

        #region Methods
        protected string GetErrorMessageDetail(Exception ex)
        {
            return GetExceptionMessage(ex);
        }

        private string GetExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null)
                message += GetExceptionMessage(ex.InnerException);

            return message;
        }

        #endregion
    }
}