using APIProject.Common.Models;
using APIProject.Common.Response;
using APIProject.Common.ResponseModels;
using APIProject.Domain.Models;
using APIProject.Repository.Interfaces;
using APIProject.Service.Interfaces;
using APIProject.Service.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service.Services
{
    public class UserServices : BaseService<User>, IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<JsonResultModel> GetNameByUserName(string username)
        {
            try
            {
                var response = await _userRepository.GetFirstOrDefaultAsync(x => x.UserName.Equals(username) && x.IsActive == 1);
                if (response != null)
                {
                    UserInfomationResponse userresponse = new UserInfomationResponse();
                    userresponse.Id = response.ID;
                    userresponse.Name = response.Name;
                    userresponse.AvaterUrl = response.AvaterUrl;
                    return JsonResultModel.SUCCESS(userresponse);
                }
                else
                {
                    return JsonResultModel.ERROR();
                }

              
            }
            catch (Exception ex)
            {
                 Console.WriteLine("Error : " + ex.Message);
                return JsonResultModel.Response(404, string.Empty, "SERVER ERROR");
            }
            
        }

        public async Task<JsonResultModel> RegisterUser(RegisterModel registerModel)
        {
            // Check Email
            var Email = await _userRepository.GetFirstOrDefaultAsync(x => x.Email.Equals(registerModel.Email));
            if (Email != null) return JsonResultModel.Response(444, null, "Email đã tồn tại, vui lòng kiểm tra lại");

            // Check Phone : 
            var Phone = await _userRepository.GetFirstOrDefaultAsync(x => x.Phone.Equals(registerModel.Phone));
            if (Phone != null) return JsonResultModel.Response(444, null, "Số điện thoại đã tồn tại");

            // pass then=>
            User user = new User();
            user.Phone = registerModel.Phone;
            user.UserName = registerModel.UserName;
            user.PassWord = Util.GenPass(registerModel.PassWord);
            user.Email = registerModel.Email;
            user.Name = registerModel.Name;
            var Adduser = await _userRepository.AddAsync(user);     
            return JsonResultModel.SUCCESS(Adduser);
        }
    }
}
