using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using test1.Models;

namespace test1.Controllers
{
    public class DefaultController : Controller
    {

        string connString = "server=127.0.0.1;port=3306;user id=qqq;password=123;database=dbtest;charset=utf8;";
        MySqlConnection conn = new MySqlConnection();



        public ActionResult Index()
        {
            return View(new UserData());
        }

        [HttpPost]
        public ActionResult Index(UserData data)
        {

            if (string.IsNullOrWhiteSpace(data.password1) || data.password1 != data.password2)
            {
                ViewBag.Msg = "密碼輸入錯誤";
                return View(data);
            }
            else
            {
                conn.ConnectionString = connString;
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string id = "0";
                string sql = @"INSERT INTO `edata` (`id`, `account`, `password`, `name`, `job`)
                                VALUES (@id, @account, @password, @name, @job)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@account", MySqlDbType.VarChar).Value = data.account;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = data.password1;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = data.name;
                cmd.Parameters.Add("@job", MySqlDbType.VarChar).Value = data.job;

                int index = cmd.ExecuteNonQuery();
                conn.Close();

               ViewBag.Msg = "註冊成功";
                return View(data);
            }
        }

        





    }
}