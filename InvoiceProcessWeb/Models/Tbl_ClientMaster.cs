namespace InvoiceProcessWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ClientMaster
    {
        [Key]
        public long ClientID { get; set; }

        public string Name { get; set; }

        public DateTime? DOJ { get; set; }

        public string AddressL1 { get; set; }

        public string AddressL2 { get; set; }

        [StringLength(100)]
        public string District { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public string Country { get; set; }

        [StringLength(6)]
        public string Pin { get; set; }

        [StringLength(10)]
        public string PAN { get; set; }

        [StringLength(13)]
        public string Adhar { get; set; }

        [StringLength(20)]
        public string GST { get; set; }

        public string OwnerName1 { get; set; }

        public string OwnerName2 { get; set; }

        public string OwnerName3 { get; set; }

        public string Mail1 { get; set; }

        public string Mail2 { get; set; }

        [StringLength(50)]
        public string LandLine { get; set; }

        [StringLength(50)]
        public string Mob1 { get; set; }

        [StringLength(50)]
        public string Mob2 { get; set; }
    }
}
