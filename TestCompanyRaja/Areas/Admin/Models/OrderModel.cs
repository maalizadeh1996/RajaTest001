using System;

namespace TestCompanyRaja.Areas.Admin.Models
{
    public class OrderModel :BaseModel
    {
        public DateTime OrderDate { get; set; }

        public int CustomerID { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string CustomerName { get; set; }



    }
}
