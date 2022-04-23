using APIProject.Common.Models;
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

        public async Task<JsonResultModel> RegisterUser(RegisterModel registerModel)
        {
            // Check Email
            var Email = await _userRepository.GetFirstOrDefaultAsync(x => x.Email.Equals(registerModel.Email));
            if (Email != null) return JsonResultModel.Response(444, null, "Email Exist in Server");
            // Check Phone : 
            var Phone = await _userRepository.GetFirstOrDefaultAsync(x => x.Phone.Equals(registerModel.Phone));
            if (Phone != null) return JsonResultModel.Response(444, null, "Phone Da ton tai, vui long kiem tra lai");

            // pass then=>
            User user = new User();
            user.Phone = registerModel.Phone;
            user.UserName = registerModel.UserName;
            user.PassWord = Util.GenPass(registerModel.PassWord);
            user.Email = registerModel.Email;
            var Adduser = await _userRepository.AddAsync(user);
            return JsonResultModel.SUCCESS(Adduser);


        }
    }
}
