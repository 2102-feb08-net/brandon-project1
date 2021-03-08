
using System;
using System.Collections.Generic;



namespace Project1.Library.Model
{
    public class Location
    {
        public int LocationId { get; set; }
        public int StoreNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public List<InventoryLine> Inventory { get; set; }
    }
}