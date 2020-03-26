using InvoiceProcessWeb.Models;
using InvoiceProcessWeb.MVCManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceProcessWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegistrationPage()
        {
            try
            {

            }
            catch (Exception ex) 
            {
            
            }
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationPage(Tbl_ClientMaster tblobj,HttpPostedFileBase gstdoc)
        {
            try
            {
                MVCHelper.SaveUser(tblobj, gstdoc);
                TempData["msg"] = "Data saved successfully.";
            }
            catch (Exception ex) 
            {
                TempData["error"] = "Somthing went wrong.!";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}