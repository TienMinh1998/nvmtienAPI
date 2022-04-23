
using APIProject.Repository.Interfaces;
using APIProject.Service.Interface;
using APIProject.Domain.Models;
using System.Threading.Tasks;
using APIProject.Common.Models;

namespace APIProject.Service.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<JsonResultModel> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            Customer cus = new Customer()
            {
                Name = addCustomerRequest.Name,
                Password = addCustomerRequest.Password,
                Phone = addCustomerRequest.Phone
            };
             var Customer = await _customerRepository.AddAsync(cus);
            JsonResultModel response = new JsonResultModel();
            response.Data = Customer;
            return response;
        }

        //public async Task<JsonResultModel> Login(AddCustomerRequest addCustomerRequest)
        //{
        //  // Todo : 

        //}
    }


}

