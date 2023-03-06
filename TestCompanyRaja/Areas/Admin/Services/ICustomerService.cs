using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Services
{
    public interface ICustomerService
    {
        void InsertCustomerAsync(Customer customer);
        void UpdateCustomerAsync(Customer customer);
        void DeleteCustomerAsync(Customer customer);
        List<Customer> GetAllCustomer();
        Customer GetCustomerById(int Id);
    }
}
