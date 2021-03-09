using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Data.Entity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
