using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Services
{
    public interface IProductService
    {
        void InsertProduct(Product Product);
        void UpdateProduct(Product Product);
        void DeleteProduct(Product Product);
        List<Product> GetAllProduct();
        Product GetProductById(int Id);
    }
}
