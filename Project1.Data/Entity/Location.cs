using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Data.Entity
{
    public partial class Location
    {
        public Location()
        {
            InventoryLines = new HashSet<InventoryLine>();
            Orders = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public int StoreNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<InventoryLine> InventoryLines { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
