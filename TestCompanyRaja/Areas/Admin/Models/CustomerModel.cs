
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCompanyRaja.Areas.Admin.Models
{
    public class CustomerModel :BaseModel
    {
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "وارد نمودن {0}  اجباری است")]
        public string Name { get; set; }
        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد نمودن {0}  اجباری است")]
        public string NationalCode { get; set; }
        [Display(Name = "موبایل")]

        public string Mobile { get; set; }
        [Display(Name = "آدرس")]

        public string Address { get; set; }

        public List<OrderModel> Orders { get; set; }
    }
}
