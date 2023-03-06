using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteOrder(Order order)
        {
            _orderRepository.Delete(order);
        }

        public List<Order> GetAllOrder()
        {
           return _orderRepository.GetAll();

        }

        public Order GetOrderById(int Id)
        {
            return _orderRepository.FindBy(Id);
            
        }

        public void InsertOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Edit(order);

        }
    }
}
