using InvoiceProcessWeb.Models;
using InvoiceProcessWeb.MVCManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceProcessWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string pwd)
        {
            string cntroller = string.Empty,action=string.Empty;
            try
            {
                Tbl_LoginMaster obj = new Tbl_LoginMaster();
                if (MVCHelper.CheckLogin(user.Trim(), pwd.Trim(), ref obj))
                {
                    if (Convert.ToBoolean(obj.IsClient))
                    {
                        action = "Userpage";cntroller = "IP";
                    }
                    else
                    {
                        action = "Home"; cntroller = "IP";
                    }
                }
                else
                {
                    action = "Login"; cntroller = "Login";
                    TempData["invalidmsg"] = "Wrong Credential!!!.";
                }
                return RedirectToAction(action,cntroller);
            }            
            catch (Exception ex)
            {
                TempData["invalidmsg"] = "Somthing wrong!!!.";
                return View();
            }
           
        }
        public ActionResult Logout()
        {
            return Redirect("Login");
        }
    }
}