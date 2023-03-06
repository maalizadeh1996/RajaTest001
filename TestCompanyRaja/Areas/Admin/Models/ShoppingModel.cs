using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCompanyRaja.Areas.Admin.Models
{
    public class ShoppingModel : BaseModel
    {
        public List<ProductModel> products { get; set; }
        public ProductModel Product { get; set; }

        public List<CustomerModel> CustomerModelList { get; set; }
        public SelectList CustomerList { get; set; }

        [Display(Name = "مشتری")]
        [Required(ErrorMessage = "وارد نمودن {0}  اجباری است")]
        public int customerId { get; set; }
        public int productId { get; set; }
    }
}
