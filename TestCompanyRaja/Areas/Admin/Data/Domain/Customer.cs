using System.Collections.Generic;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin.Models.Domain
{
    public partial class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }


        public int OrderId { get; set; }

        public List<Order> orders { get; set; }
    }
}
