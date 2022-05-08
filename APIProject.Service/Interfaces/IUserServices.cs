using APIProject.Common.Models;
using APIProject.Domain.Models;
using APIProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service.Interfaces
{
   public interface IUserServices : IServices<User>
    {
        Task<JsonResultModel> RegisterUser(RegisterModel registerModel);
        Task<JsonResultModel> GetNameByUserName(string username);

    }
}
