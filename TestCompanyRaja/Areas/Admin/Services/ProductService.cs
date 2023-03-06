using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
      
        public void DeleteProduct(Product Product)
        {
            _productRepository.Delete(Product);
        }

        public List<Product> GetAllProduct()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int Id)
        {
            return _productRepository.FindBy(Id);
        }

        public void InsertProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Edit(product);
        }
    }
}
