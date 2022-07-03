using HrmsCloneWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        #region  Variable Declaration
        private IConfiguration configuration;
        private readonly string _connectioSting;
        #endregion

        #region Constructor
        public HomeController(IConfiguration iConfig)
        {
            configuration = iConfig;
            _connectioSting = configuration.GetValue<string>("ConnectionStrings:HRMSDatabase");
        }
        #endregion

        [HttpGet]
        [Route("GetOpportunities")]
        public async Task<ResponseModel> GetOpportunities()
        {
            ResponseModel objResponseModel = new ResponseModel();
            // ITAdminCaller iTAdminCaller = new ITAdminCaller();
            var responseModel = "";
                //iTAdminCaller.GetOpportunities(new ITAdminService(_connectioSting));

            objResponseModel.Status = true;
            objResponseModel.StatusCode = 200;
            objResponseModel.Message = "Success";
            objResponseModel.ResponseData = responseModel;
            return await Task.FromResult(objResponseModel);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
