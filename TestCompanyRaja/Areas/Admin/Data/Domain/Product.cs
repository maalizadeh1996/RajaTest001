using System.Collections.Generic;

namespace TestCompanyRaja.Areas.Admin.Models.Domain
{
    public class Product :BaseEntity
    {
        public string ProductName { get; set; }

        public long Price { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }

        public List<Order> orders { get; set; }
    }
}
