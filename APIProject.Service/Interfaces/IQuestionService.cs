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
  public interface IQuestionService : IServices<Question>
    {
        Task<JsonResultModel> AddNewQuestion(AddNewQuestionRequest Request);
        Task<JsonResultModel> Get_Questions_By_ID(QuestionByIDSubjectRequest request);
        Task<JsonResultModel> Search(SearchQuestionModel request);

        Task<JsonResultModel> UpdateViewCount(UpdateCountView request);
    }
}
