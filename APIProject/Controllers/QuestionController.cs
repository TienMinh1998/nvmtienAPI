using APIProject.Common.Models;
using APIProject.Common.Request;
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
    [Route("api/app/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }


        [HttpPost]
        [Route("Get_QuestionsBy_SubjectID")]
        public async Task<JsonResultModel> Get_Questions_By_ID(QuestionByIDSubjectRequest request)
        {
            return await questionService.Get_Questions_By_ID(request);
        }

        /// <summary>
        /// Thêm câu hỏi
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewQuestion")]
        public async Task<JsonResultModel> AddNewMaterial(AddNewQuestionRequest request)
        {
            return await questionService.AddNewQuestion(request);
        }

        /// <summary>
        /// Tìm kiếm câu Hỏi
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SearchQuestion")]
        public async Task<JsonResultModel> SearchAction(SearchQuestionModel request)
        {
            return await questionService.Search(request);
        }
        
        /// <summary>
        /// Cập nhật lượt xem cho câu hỏi
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateViewCount")]
        public async Task<JsonResultModel> UpdateViewCount(UpdateCountView request)
        {
            return await questionService.UpdateViewCount(request);
        }    

    }
}
