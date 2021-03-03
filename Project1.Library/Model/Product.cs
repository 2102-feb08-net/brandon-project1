
using System;



namespace Project1.Library.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime? BestBy { get; set; }
        public decimal UnitPrice { get; set; }
    }
}