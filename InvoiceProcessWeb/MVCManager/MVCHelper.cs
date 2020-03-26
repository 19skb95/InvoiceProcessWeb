using InvoiceProcessWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static InvoiceProcessWeb.MVCManager.ViewModelClass;

namespace InvoiceProcessWeb.MVCManager
{
    public static class MVCHelper
    {
        #region----------------------------User----------------------------------
        public static void SaveUser(Tbl_ClientMaster obj, HttpPostedFileBase doc)
        {
            string filepath = System.Configuration.ConfigurationManager.AppSettings["SaveFilePath"];
            using (GSTDB db = new GSTDB())
            {
                obj.DOJ = DateTime.Now;
                db.Tbl_ClientMaster.Add(obj);
                db.SaveChanges();
                if (doc != null && doc.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(doc.FileName);
                    doc.SaveAs(Path.Combine(filepath, DateTime.Now.ToString("ddMMyyyy_" + obj.ClientID + ".jpg")));
                }
                Tbl_LoginMaster loginObj = new Tbl_LoginMaster();
                loginObj.Email = obj.Mail1;
                loginObj.UserName = (string.IsNullOrEmpty(obj.Mail1) ? obj.Mob1 : obj.Mail1);
                loginObj.Password = "12345";
                loginObj.IsClient = true;
                loginObj.CilientID = obj.ClientID;
                db.Tbl_LoginMaster.Add(loginObj);
                db.SaveChanges();
            }

        }

        public static List<Tbl_ClientMaster> GetAllUsers(string name, string gst)
        {

            name = name.ToLower().Trim();
            gst = gst.Trim();
            using (GSTDB db = new GSTDB())
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return db.Tbl_ClientMaster.Where(x => x.Name.ToLower().Contains(name)).ToList();
                }
                else if (!string.IsNullOrEmpty(gst))
                {
                    return db.Tbl_ClientMaster.Where(x => x.GST.Equals(gst)).ToList();
                }
                else
                {
                    return db.Tbl_ClientMaster.Where(x => x.GST.Equals(gst) && x.Name.ToLower().Contains(name)).ToList();
                }
            }

        }
        public static List<Tbl_ClientMaster> GetAllUsers()
        {
            using (GSTDB db = new GSTDB())
            {
                return db.Tbl_ClientMaster.ToList();
            }

        }
        public static Tbl_ClientMaster GetUser(long id)
        {
            using (GSTDB db = new GSTDB())
            {
                return db.Tbl_ClientMaster.Where(x => x.ClientID == id).FirstOrDefault();
            }

        }
        #endregion--------------------------------------------------------------


        #region----------------------------Log In----------------------------------
        public static bool CheckLogin(string uname, string pwd, ref Tbl_LoginMaster obj)
        {
            bool check = false;
            using (GSTDB db = new GSTDB())
            {
                var user = db.Tbl_LoginMaster.Where(x => x.UserName.Equals(uname) && x.Password.Equals(pwd)).FirstOrDefault();
                if (user != null)
                {
                    check = true;
                    obj = user;
                }
            }
            return check;
        }

        #endregion---------------------------------------------------------------

        #region---------------------------State---------------------------------
        public static string GetStateName(int code)
        {
            string statename = string.Empty;
            try
            {
                using (GSTDB db = new GSTDB())
                {
                    var state = db.tbl_StateMaster.Where(x => x.Tin == code).FirstOrDefault();
                    if (state != null)
                    {
                        statename = (state.Tin<10?"0":"")+state.Tin.ToString() + "-" + state.StateName;
                    }
                    else
                    {
                        statename = "";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return statename;
        }
        #endregion---------------------------------------------------------

        #region---------------------------------Report-------------------------
        public static void SaveReport(Tbl_ReportMaster reportobj, LineItem list)
        {
            try
            {
                List<LineItemListClass> lineList = new List<LineItemListClass>();
                int rowcount = list.cgst.Length;
                for (int i = 0; i < rowcount; i++)
                {
                    LineItemListClass Lineobj = new LineItemListClass()
                    {
                        itemname = list.itemname[i],
                        hsn = list.hsn[i],
                        uom = list.uom[i],
                        qty = list.qty[i],
                        rpu = list.rpu[i],
                        tvalue = list.tvalue[i],
                        rate = list.rate[i],
                        igst = list.igst[i],
                        sgst = list.sgst[i],
                        cgst = list.cgst[i],
                        utgst = list.utgst[i],
                        total = list.total[i],
                        cess = list.cess[i],
                    };
                    lineList.Add(Lineobj);
                }
                reportobj.ItemInfo = Newtonsoft.Json.JsonConvert.SerializeObject(lineList);
                using (GSTDB db = new GSTDB())
                {
                    db.Tbl_ReportMaster.Add(reportobj);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
           
        }
        public static List<Tbl_ReportMaster> GetReportByClientID(long id)
        {
            List<Tbl_ReportMaster> list = new List<Tbl_ReportMaster>(); 
            try
            {
                using (GSTDB db=new GSTDB())
                {
                    list = db.Tbl_ReportMaster.Where(x => x.ClientID == id).ToList();
                }
            }
            catch (Exception)
            {

            }
            return list;
        }
        #endregion--------------------------------------------------------------
    }
}