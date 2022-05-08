
using APIProject.Common.Models;
using APIProject.Common.ResponseModels;
using APIProject.Domain.Models;
using APIProject.Models;
using APIProject.Service.Interface;
using APIProject.Service.Interfaces;
using APIProject.Service.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Controllers
{
    [Route("api/app/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserServices _userServices;
        private readonly AppSettings _appSettings;

        public IConfiguration _Configuration;

        public CustomerController(ICustomerService customerService, IConfiguration configuration, IOptionsMonitor<AppSettings>  optionsMonitor, IUserServices userServices = null)
        {
            _customerService = customerService;
            _Configuration = configuration;
            _userServices = userServices;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Authorize]
        [Route("addnewcustomer")]
        public  async Task<JsonResultModel> AddNewCustomer(AddCustomerRequest customerRequest)
        {
            return  await _customerService.AddCustomer(customerRequest);
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<JsonResultModel> Action_Register(RegisterModel model)
        {
            return await _userServices.RegisterUser(model);
        }

        /// <summary>
        /// Login Application
        /// </summary>
        /// <param name="LoginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public  async Task<JsonResultModel> Login(LoginRequestModel LoginRequest)
        {
            string encryptionpassword = string.Empty;
            var user = await _userServices.GetFirstOrDefaultAsync(x => x.UserName == LoginRequest.UserName);
            if (user!=null)
            {
              encryptionpassword = user.PassWord;
            }
            

            if (user!=null && Util.CheckPass(LoginRequest.PassWord, encryptionpassword))
            {
                // Provice TOken
                var tokenGenerate = GenerateToken(user);
                LoginResponse APIResponse = new LoginResponse();
                APIResponse.Token = tokenGenerate;
                return JsonResultModel.SUCCESS("1");
            }
            return JsonResultModel.SUCCESS("0");
        }
        private string GenerateToken(User infomation)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler(); 
            var SecretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescRiption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, infomation.UserName),
                    new Claim(ClaimTypes.Email, infomation.Email),
                    
                    new Claim("Id", infomation.ID.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKeyBytes),SecurityAlgorithms.HmacSha512Signature)
                             
                };
            var Token = JwtTokenHandler.CreateToken(tokenDescRiption);
            return JwtTokenHandler.WriteToken(Token);
        }

        /// <summary>
        /// Trả ra tên và Url ảnh dựa vào tên đăng nhập của người đó
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNameByUserName")]
        public async Task<JsonResultModel> GetNameByUserName(string name)
        {
           return await  _userServices.GetNameByUserName(name);  
        }
    }

  


}
