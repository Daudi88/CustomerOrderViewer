namespace CustomerOrderViewer.Models
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class CustomerOrderDetailsModel
    {
        public int CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
