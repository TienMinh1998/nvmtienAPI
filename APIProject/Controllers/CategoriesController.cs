using APIProject.Common.Models;
using APIProject.Common.Request;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        /// <summary>
        /// Get ALL chức năng của phần mềm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_All")]
        public async Task<JsonResultModel> GetALLCategories(int usserId)
        {
            return await categoryService.GetAll(usserId);
        }

        /// <summary>
        /// Thêm mới 1 danh mục
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Add_Categories")]
        public async Task<JsonResultModel> Add(CategoryRequestModel request)
        {
            return await categoryService.Add(request);
        }
    }
}
