
using APIProject.Repository.Interfaces;
using APIProject.Service.Interface;
using APIProject.Domain.Models;


namespace APIProject.Service.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
   
    }


}

