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
        //連接DB
        string connString = "server=127.0.0.1;port=3306;user id=qqq;password=123;database=dbtest;charset=utf8;";

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


            if (AddUserData(data))
            {
                Response.Redirect("~/Home/Login");
                return new EmptyResult();
            }
            else
            {
                Response.Redirect("Login");
                return new EmptyResult();
            }
        }

        public bool AddUserData(UserData data)
        {
            try
            {
                Connect();
                string id = Guid.NewGuid().ToString();
                string strSQL = @"INSERT INTO `userdata` (`id`, `account`, `password`, `city`, `village`, `address`)
                          VALUES (@id, @account, @password, @city, @village, @address)";
                MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@account", MySqlDbType.VarChar).Value = data.account;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = data.password1;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Disconnect();
            }
        }



    }
}