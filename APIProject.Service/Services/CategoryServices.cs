using APIProject.Common.Models;
using APIProject.Common.Request;
using APIProject.Common.Response;
using APIProject.Domain.Models;
using APIProject.Repository.Interfaces;
using APIProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service.Services
{
   public class CategoryServices : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepositioryu;
        public CategoryServices(ICategoryRepository categoryRepo) : base(categoryRepo)
        {
            _categoryRepositioryu = categoryRepo;
        }

        public async Task<JsonResultModel> Add(CategoryRequestModel request)
        {
            Category category = new Category();
            category.Name = request.Name;
            category.UserId = request.userId;
            await _categoryRepositioryu.AddAsync(category);
            return JsonResultModel.SUCCESS(request);
        }

        public async Task<JsonResultModel> GetAll(int userId)
        {
            List<CatagotiesResponseModel> response = new List<CatagotiesResponseModel>();
            var responseFromRepo = await _categoryRepositioryu.GetAllAsync(x=>x.UserId.Equals(userId));
            foreach (var item in responseFromRepo)
            {
                response.Add(new CatagotiesResponseModel { Id = item.ID, Name = item.Name });
            }
            return JsonResultModel.SUCCESS(response);
        }
    }
}
