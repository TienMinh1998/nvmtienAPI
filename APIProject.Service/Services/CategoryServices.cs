using APIProject.Domain.Models;
using APIProject.Repository.Interfaces;
using APIProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Service.Services
{
   public class CategoryServices : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepositioryu;
        public CategoryServices(ICategoryRepository categoryRepo) : base(categoryRepo)
        {
            _categoryRepositioryu = categoryRepo;
        }
    }
}
