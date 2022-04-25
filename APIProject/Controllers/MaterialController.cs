using APIProject.Common.Models;
using APIProject.Service.Interface;
using APIProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers
{
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialServices _materialServices;
        public MaterialController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }

        /// <summary>
        /// Get all material 
        /// </summary>
        /// <returns>list</returns>
        [HttpGet]
        [Route("GetAllMaterial")]
        public async Task<JsonResultModel> AddNewCustomer()
        {
            return await _materialServices.GetAllMaterial();
        }

        /// <summary>
        /// Add New Material
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("AddNewMaterial")]
        public async Task<JsonResultModel> AddNewMaterial()
        {
            return await _materialServices.GetAllMaterial();
        }
    }
}
