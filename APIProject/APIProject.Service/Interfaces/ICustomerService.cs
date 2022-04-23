
using APIProject.Common.Models;
using APIProject.Domain.Models;
using System.Threading.Tasks;

namespace APIProject.Service.Interface
{
    public interface ICustomerService : IServices<Customer>
    {
        Task<JsonResultModel> AddCustomer(AddCustomerRequest addCustomerRequest);
    }
}
