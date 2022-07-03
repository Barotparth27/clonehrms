using hrmscloneapi.Interface;
using hrmscloneapi.Model;
using hrmscloneapi.Provider;
using hrmscloneapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private AccountMaster _authenticateService;
        private readonly string _connectioSting;
        private IConfiguration configuration;
        private readonly AppSettings _appSettings;
        private readonly string _appSettKey;
        public AccountController(AccountMaster authenticateService, IConfiguration iConfig, IOptions<AppSettings> appSettings)
        {
            _authenticateService = authenticateService;
            configuration = iConfig;
            _connectioSting = configuration.GetValue<string>("ConnectionStrings:HRMSDatabase");
            _appSettings =  appSettings.Value;
            _appSettKey = _appSettings.ToString();


        }
        
        [HttpPost("Login")]
        public async Task<ResponseModel> Login(Account obj)
        {
            ResponseModel objResponseModel = new ResponseModel();
            AccountCaller IAccountCaller = new AccountCaller();
            var responseModel = IAccountCaller.Login(new AccountService(_connectioSting, _appSettKey), obj.EmailId, obj.password);
            objResponseModel.Status = true;
            objResponseModel.StatusCode = 200;
            objResponseModel.Message = "Success";
            objResponseModel.ResponseData = responseModel;
            return await Task.FromResult(objResponseModel);
        }
        [HttpPost("GetUserPageAccessList")]
        public async Task<ResponseModel> GetUserPageAccessList(usermageaccessreq obj)
        {
            ResponseModel objResponseModel = new ResponseModel();
            AccountCaller IAccountCaller = new AccountCaller();
            var responseModel = IAccountCaller.GetUserPageAccessList(new AccountService(_connectioSting, _appSettKey), obj);
            objResponseModel.Status = true;
            objResponseModel.StatusCode = 200;
            objResponseModel.Message = "Success";
            objResponseModel.ResponseData = responseModel;
            return await Task.FromResult(objResponseModel);
        }


    }
}
