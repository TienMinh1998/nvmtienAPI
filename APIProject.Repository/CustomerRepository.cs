


/*------------------------------------------------
 * AUthor   : NGuyễn Viết Minh Tiến
 * DateTime : 15/12/2021
 * Edit     : Chưa chỉnh Sửa
 * Content  : hàm đếm số điện thoại, hàm đếm Email
 * -----------------------------------------------*/

using APIProject.Domain;
using APIProject.Domain.Models;
using APIProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using APIProject.Service.Utils;


namespace APIProject.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}
