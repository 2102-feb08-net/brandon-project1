


namespace Project1.Library.Model
{
    public class InventoryLine
    {
        public int InventoryLineId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }

        public Product Product { get; set; }
    }
}