using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Data.Entity
{
    public partial class InventoryLine
    {
        public int InventoryLineId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
