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


        MyDataBase db = new MyDataBase();
        string connString = "server=127.0.0.1;port=3306;user id=qqq;password=123;database=dbtest;charset=utf8;";
        MySqlConnection conn = new MySqlConnection();

        Boolean login = false;


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
                //自己找資料庫最大id+1設為id
                int id=0;
                string sql = @"SELECT MAX(id)max FROM`edata`";
                try
                {
                    MySqlCommand cmd2 = new MySqlCommand(sql, conn);
                    id = (int)cmd2.ExecuteScalar();
                    id++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //string id = "0";
                sql = @"INSERT INTO `edata` (`id`, `account`, `password`, `name`, `job`)    
                                VALUES (@id, @account, @password, @name, @job)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@account", MySqlDbType.VarChar).Value = data.account;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = data.password1;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = data.name;
                cmd.Parameters.Add("@job", MySqlDbType.VarChar).Value = data.job;

                int index = cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("~/Default/Login");
                return new EmptyResult();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection post)
        {
            string account = post["account"];
            string password = post["password"];

            if (db.CheckUserData(account, password))
            {

                Response.Redirect("~/Default/Update");
                return new EmptyResult();
            }
            else
            {
                ViewBag.Msg = "登入失敗";
                return View();
            }
        }



    }
}