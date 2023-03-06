using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void DeleteCustomerAsync(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public virtual void InsertCustomerAsync(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void UpdateCustomerAsync(Customer customer)
        {
            _customerRepository.Edit(customer);
        }

        public List<Customer> GetAllCustomer()
        {
            return  _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int Id)
        {
            return _customerRepository.FindBy(Id);
        }
    }
}
