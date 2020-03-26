using InvoiceProcessWeb.Models;
using InvoiceProcessWeb.MVCManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static InvoiceProcessWeb.MVCManager.ViewModelClass;

namespace InvoiceProcessWeb.Controllers
{
    public class IPController : Controller
    {
        // GET: IP
        public ActionResult Home(string Name, string Gst)
        {
            try
            {
                if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Gst))
                {
                    ViewBag.list = MVCHelper.GetAllUsers(Name, Gst);
                }
                else
                {
                    ViewBag.list = MVCHelper.GetAllUsers();
                }


            }
            catch (Exception ex)
            {

            }


            return View();
        }

        public ActionResult Action(long? ID)
        {
            try
            {
                if (ID != null)
                {
                    ViewBag.obj = MVCHelper.GetUser(Convert.ToInt64(ID));
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }


            return View();
        }
        [HttpPost]
        public ActionResult Action(Tbl_ReportMaster reportobj, LineItem list)
        {
            try
            {
                MVCManager.MVCHelper.SaveReport(reportobj, list);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Home");
        }
        public JsonResult GetState(int code)
        {
            return Json(MVCHelper.GetStateName(code), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Userpage(long? ID)
        {
            try
            {
                if (ID != null)
                {
                    ViewBag.list = MVCHelper.GetReportByClientID(Convert.ToInt64(ID));
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }


            return View();
        }
    }
}