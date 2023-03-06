using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Services
{
    public interface IOrderService
    {
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        List<Order> GetAllOrder();
        Order GetOrderById(int Id);
    }
}
