
using APIProject.Domain.Models;
using APIProject.Service.Interface;
using APIProject.Service.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace APIProject.Controllers.App
{
    [Route("api/app/[controller]")]
    [ApiExplorerSettings(GroupName = "App")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public IConfiguration _Configuration;
 
        public CustomerController(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _Configuration = configuration;

        }
        [HttpGet]
        public string GetName()
        {
            return "Nguhen Viet Minh Tien";

        }
    }


}
