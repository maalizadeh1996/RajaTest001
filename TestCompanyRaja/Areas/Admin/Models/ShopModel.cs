using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestCompanyRaja.Areas.Admin.Models
{
    public class ShopModel : BaseModel
    {
        public List<CustomerModel> CustomerModels { get; set; }
        public List<ProductModel> ProductModels { get; set; }
        public List<OrderModel> OrderModels { get; set; }

        public SelectList CustomerList { get; set; }
        public SelectList ProductList { get; set; }

        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "وارد نمودن {0}  اجباری است")]
        public int customerId { get; set; }
        public int productId { get; set; }
    }
}
