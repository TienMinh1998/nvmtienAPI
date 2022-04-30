using APIProject.Common.Models;
using APIProject.Common.Request;
using APIProject.Domain.Models;
using APIProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service.Interfaces
{
    public interface IMaterialServices : IServices<Material>
    {
        Task<JsonResultModel> GetAllMaterial();
        Task<JsonResultModel> AddNewMaterial(AddNewMaterialRequest model);
    }
} 
