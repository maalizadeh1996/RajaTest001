using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCompanyRaja.Areas.Admin.FactoryModel;
using TestCompanyRaja.Areas.Admin.Models.Domain;
using TestCompanyRaja.Areas.Admin.Models;
using TestCompanyRaja.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Newtonsoft.Json;

namespace TestCompanyRaja.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IFactoryModel _factoryModel;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public ShopController(ICustomerService customerService,
            IFactoryModel factoryModel,
            IProductService productService,
            IOrderService orderService)
        {
            _customerService = customerService;
            _factoryModel = factoryModel;
            _productService = productService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View("List");
        }

        public IActionResult List()
        {
            var shopModel = new ShopModel();
            var customers = _customerService.GetAllCustomer();
            var products = _productService.GetAllProduct();

            shopModel.CustomerModels = _factoryModel.PrepareCustomerListModel(customers);
            shopModel.ProductModels = _factoryModel.PrepareProductListModel(products);
            shopModel.OrderModels = _factoryModel.PrepareOrderListModel();

            shopModel.CustomerList = new SelectList(shopModel.CustomerModels, "Id", "Name");
            shopModel.ProductList = new SelectList(shopModel.ProductModels, "Id", "ProductName");

            return View(shopModel);
        }

        #region customer
        public IActionResult CreateCustomer() => View();

        [HttpPost]
        public IActionResult CreateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<CustomerModel, Customer>();

                });
                Customer customer = config.CreateMapper().Map<Customer>(model);
                _customerService.InsertCustomerAsync(customer);
                ViewData["Message"] = true;
                return RedirectToAction("List");

            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            var customerModel = _factoryModel.PrepareCustomer(customer);

            customerModel.Orders = _factoryModel.PrepareOrderList(id);

            return View(customerModel);
        }

        [HttpPost]
        public IActionResult EditCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<CustomerModel, Customer>();

                });
                Customer customer = config.CreateMapper().Map<Customer>(model);
                _customerService.UpdateCustomerAsync(customer);
                return RedirectToAction("List");

            }
            model.Orders = _factoryModel.PrepareOrderList(model.Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(int Id)
        {
            var customer = _customerService.GetCustomerById(Id);
            _customerService.DeleteCustomerAsync(customer);
            return Json(new { Result = true });
        }

        #endregion


        #region product
        [HttpPost]
        public IActionResult ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<ProductModel, Product>();

                });
                Product product = config.CreateMapper().Map<Product>(model);
                _productService.InsertProduct(product);
                return RedirectToAction("List");

            }

            return View();
        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<ProductModel, Product>();

                });
                Product product = config.CreateMapper().Map<Product>(model);
                _productService.UpdateProduct(product);
                return RedirectToAction("List");

            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(int Id)
        {
            var product = _productService.GetProductById(Id);
            _productService.DeleteProduct(product);
            return Json(new { Result = true });
        }

        #endregion

        #region order

        [HttpPost]
        public IActionResult GetOrders(int Id)
        {
            var Orders = _factoryModel.PrepareOrderList(Id);
            return Json(JsonConvert.SerializeObject(Orders));
        }
        [HttpPost]
        public IActionResult OrderCreate(ShopModel model)
        {
            if (ModelState.IsValid)
            {
                _orderService.InsertOrder(new Order
                {
                    ProductId = model.productId,
                    CustomerID = model.customerId,
                    OrderDate = DateTime.Now,
                });
                return RedirectToAction("List");
            }

            return View();
        }
        #endregion

    }
}
