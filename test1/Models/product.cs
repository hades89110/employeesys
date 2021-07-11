using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }

    }

    public class UserData
    {
        public string account { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public string name { get; set; }
        public string job { get; set; }
    }
}