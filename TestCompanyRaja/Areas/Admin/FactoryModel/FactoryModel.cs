using AutoMapper;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using TestCompanyRaja.Areas.Admin.Models.Domain;
using TestCompanyRaja.Areas.Admin.Models;
using TestCompanyRaja.Areas.Admin.Services;

namespace TestCompanyRaja.Areas.Admin.FactoryModel
{
    public class FactoryModel : IFactoryModel
    {
        private readonly IOrderService _orderService;
        private readonly TestCompanyRajaDbContext _dbContext;
        public FactoryModel(IOrderService orderService, TestCompanyRajaDbContext context)
        {
            _dbContext = context;

            _orderService = orderService;
        }
        public List<CustomerModel> PrepareCustomerListModel(List<Customer> customers)
        {
            return customers.Select(c => new CustomerModel()
            {
                Id = c.Id,
                Name = c.Name,
                NationalCode = c.NationalCode,
                Address = c.Address,
                Mobile = c.Mobile,

            }).ToList();
        }

        public CustomerModel PrepareCustomer(Customer customer)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Customer, CustomerModel>();

            });
            CustomerModel customerModel = config.CreateMapper().Map<CustomerModel>(customer);

            return customerModel;
        }

        public List<ProductModel> PrepareProductListModel(List<Product> products)
        {
            return products.Select(p => new ProductModel()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,


            }).ToList();
        }

        public ProductModel PrepareProduct(Product product)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Product, ProductModel>();

            });
            ProductModel productModel = config.CreateMapper().Map<ProductModel>(product);

            return productModel;
        }

        public List<OrderModel> PrepareOrderList(int CustomerId)
        {
            var Data = _dbContext.Orders.Where(o => o.CustomerID == CustomerId).Include(p => p.Product).Select(om => new OrderModel()
            {
                Id = om.Id,
                ProductName = om.Product.ProductName,
                CustomerName=om.Customer.Name
            }).ToList();

            return Data;

        }

        public List<OrderModel> PrepareOrderListModel()
        {
            var Data = _dbContext.Orders.Include(p => p.Product).Select(om => new OrderModel()
            {
                Id = om.Id,
                ProductName = om.Product.ProductName,
                CustomerName = om.Customer.Name,
            }).ToList();

            return Data;
        }
    }
}
