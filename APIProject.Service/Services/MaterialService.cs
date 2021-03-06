using APIProject.Common.Models;
using APIProject.Common.Request;
using APIProject.Domain.Models;
using APIProject.Repository;
using APIProject.Repository.Interfaces;
using APIProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service.Services
{
    public class MaterialService : BaseService<Material>, IMaterialServices
    {
        private readonly IMaterialRepository _MaterialRepository;

        public MaterialService(IMaterialRepository materialRepository) :base(materialRepository)
        {
            _MaterialRepository = materialRepository;
        }

        public async Task<JsonResultModel> AddNewMaterial(AddNewMaterialRequest model)
        {
            Material material = new Material();
            material.Name = model.Name;
            material.Rb = model.Rb;
            material.Eb = model.Eb;
            material.Definition = model.Definition;
            var response = await _MaterialRepository.AddAsync(material);
            return JsonResultModel.SUCCESS(model);
        }
        

        public async Task<JsonResultModel> GetAllMaterial()
        {
            var list = await _MaterialRepository.GetAllAsync();
            JsonResultModel jsonResultModel = new JsonResultModel();
            jsonResultModel.Data = list;
            jsonResultModel.Status = 200;
            jsonResultModel.Message = "SUCCESS";
            return jsonResultModel;
        }


    }
}
