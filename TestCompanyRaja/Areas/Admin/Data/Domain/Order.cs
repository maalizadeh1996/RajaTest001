using System;

namespace TestCompanyRaja.Areas.Admin.Models.Domain
{
    public class Order :BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
