using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace test1.Models
{


    public class UserData
    {
        public string id { get; set; }
        public string account { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public string name { get; set; }
        public string job { get; set; }
    }

    public class MyDataBase
    {

        
    }

}