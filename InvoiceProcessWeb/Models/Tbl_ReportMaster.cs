namespace InvoiceProcessWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ReportMaster
    {
        [Key]
        public long ReportID { get; set; }


        public long? ClientID { get; set; }

        public string ClientName { get; set; }

        [StringLength(10)]
        public string PanNo { get; set; }

        public string GSTNO { get; set; }

        [StringLength(15)]
        public string ReportType { get; set; }

        public string PartyName { get; set; }

        public string PartyGstNumber { get; set; }

        [StringLength(50)]
        public string PlaceOfSupply { get; set; }
        [StringLength(20)]
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string EwayBill { get; set; }
        public string Address { get; set; }
        public DateTime? EwayBillDate { get; set; }
        public string ModeOfTransport { get; set; }
        public string VehicleNo { get; set; }      
        public string TotalAmount { get; set; }
        public string ItemInfo { get; set; }
        public string TotalTval { get; set; }
        public string TotalIgst { get; set; }
        public string TotalSgst { get; set; }
        public string TotalCgst { get; set; }
        public string TotalUtgst { get; set; }
        public string TotalCess { get; set; }

    }
}
