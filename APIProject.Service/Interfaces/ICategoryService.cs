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
   public interface ICategoryService  : IServices<Category>
    {
        Task<JsonResultModel> GetAll(int userId);
        Task<JsonResultModel> Add(CategoryRequestModel request);
    }
}
