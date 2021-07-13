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
        public string account { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public string name { get; set; }
        public string job { get; set; }
    }

    public class MyDataBase
    {

        public bool CheckUserData(string account, string password)
        {

            string connString = "server=127.0.0.1;port=3306;user id=qqq;password=123;database=dbtest;charset=utf8;";
            MySqlConnection conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = connString;
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                //Connect();
                string strSQL = "SELECT 1 FROM `edata` WHERE `account` = '" + account + "' AND `password` = '" + password + "';";
                MySqlCommand cmd = new MySqlCommand(strSQL, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}