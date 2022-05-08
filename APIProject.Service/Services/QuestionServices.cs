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
using System.Linq;

namespace APIProject.Service.Services
{
   public class QuestionServices : BaseService<Question>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionServices(IQuestionRepository questionRepository) : base(questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<JsonResultModel> AddNewQuestion(AddNewQuestionRequest Request)
        {
            Question question = new Question
            {
                cauhoi = Request.Cauhoi,
                cautraloi = Request.CauTraLoi,
                Subject = Request.IdSubject
                ,UserId = Request.UserId
            };
            await _questionRepository.AddAsync(question);
            return JsonResultModel.SUCCESS(Request);
        }

        public async Task<JsonResultModel> Get_Questions_By_ID(QuestionByIDSubjectRequest request)
        {
            var response = await _questionRepository.GetAllAsync(o => o.Subject == request.Id);
            List<QuestionResponse> questionResponse = new List<QuestionResponse>();
            foreach (var item in response)
            {
                QuestionResponse a = new QuestionResponse();
                a.Id = item.ID;
                a.Subject_Id = item.Subject;
                a.Question = item.cauhoi;
                a.Answer = item.cautraloi;
                questionResponse.Add(a);
            }
            return JsonResultModel.SUCCESS(questionResponse);
        }

        public async Task<JsonResultModel> Search(SearchQuestionModel request)
        {
            List<QuestionResponse> questionResponse = new List<QuestionResponse>();
            var response = await _questionRepository.GetAllAsync(x=>x.cauhoi.ToLower().Contains(request.SearchText.ToLower())
                                                            && x.CreatedDate >= request.FromDate
                                                            && x.CreatedDate <= request.ToDate
                                                            && x.Subject.Equals(request.SubjectId)
                                                            && x.UserId.Equals(request.UserId)
                                                            );
            response = response.OrderByDescending(x => x.CreatedDate).ToList();
            foreach (var item in response)
            {
                QuestionResponse a = new QuestionResponse();
                a.Id = item.ID;
                a.Subject_Id = item.Subject;
                a.Question = item.cauhoi;
                a.Answer = item.cautraloi;
                a.CountIt = item.CountIt;
                questionResponse.Add(a);
            }
            return JsonResultModel.SUCCESS(questionResponse);
        }

        public async Task<JsonResultModel> UpdateViewCount(UpdateCountView request)
        {
            var subject = _questionRepository.GetFirstOrDefaultAsync(x => x.Subject.Equals(request.SubjectId));
            if (subject!= null)
            {
                var question = await _questionRepository.GetFirstOrDefaultAsync(x => x.ID.Equals(request.QuestionId));
                question.CountIt += 1;
                var question1 =  await _questionRepository.UpdateAsync(question);
                return JsonResultModel.SUCCESS(question1.CountIt);
            }
            else
            {
                return JsonResultModel.Response(500, "", "SERVER ERROR");
            }
        }
    }
}
