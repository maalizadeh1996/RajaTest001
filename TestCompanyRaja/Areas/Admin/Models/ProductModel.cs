using System.ComponentModel.DataAnnotations;

namespace TestCompanyRaja.Areas.Admin.Models
{
    public class ProductModel :BaseModel
    {
        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }
        [Display(Name = "قیمت")]
        public long Price { get; set; }

    }
}
