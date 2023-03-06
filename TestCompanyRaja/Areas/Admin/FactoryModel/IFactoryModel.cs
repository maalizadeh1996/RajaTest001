
using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.FactoryModel
{
    public interface IFactoryModel
    {
        List<ProductModel> PrepareProductListModel(List<Product> products);

        ProductModel PrepareProduct(Product product);

        List<CustomerModel> PrepareCustomerListModel(List<Customer> customers);
        CustomerModel PrepareCustomer(Customer customer);
        List<OrderModel> PrepareOrderList(int CustomerId);
        List<OrderModel> PrepareOrderListModel();
    }
}
