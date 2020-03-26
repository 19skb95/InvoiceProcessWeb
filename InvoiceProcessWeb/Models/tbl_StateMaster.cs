namespace InvoiceProcessWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_StateMaster
    {
        [Key]
        public int StateID { get; set; }

        [StringLength(100)]
        public string StateName { get; set; }

        public int? Tin { get; set; }

        [StringLength(10)]
        public string StateCode { get; set; }

        public bool? UT { get; set; }
    }
}
