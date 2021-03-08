
using System;
using System.Collections.Generic;



namespace Project1.Library.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderTotal { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}