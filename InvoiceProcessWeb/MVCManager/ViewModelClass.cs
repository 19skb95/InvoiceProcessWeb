using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceProcessWeb.MVCManager
{
    public class ViewModelClass
    {
        public class LineItem
        {
           public string[] itemname { get; set; }
            public string[] hsn { get; set; }
            public string[] uom { get; set; }
            public string[] qty { get; set; }
            public string[] rpu { get; set; }
            public string[] tvalue { get; set; }
            public string[] rate { get; set; }
            public string[] igst { get; set; }

            public string[] sgst { get; set; }
            public string[] cgst { get; set; }
            public string[] utgst { get; set; }
            public string[] cess { get; set; }
            public string[] total { get; set; }
        }
        public class LineItemListClass
        {
            public string itemname { get; set; }
            public string hsn { get; set; }
            public string uom { get; set; }
            public string qty { get; set; }
            public string rpu { get; set; }
            public string tvalue { get; set; }
            public string rate { get; set; }
            public string igst { get; set; }

            public string sgst { get; set; }
            public string cgst { get; set; }
            public string utgst { get; set; }
            public string cess { get; set; }
            public string total { get; set; }
        }
    }
}