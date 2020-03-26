namespace InvoiceProcessWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GSTDB : DbContext
    {
        public GSTDB()
            : base("name=GSTDB")
        {
        }

        public virtual DbSet<Tbl_ClientMaster> Tbl_ClientMaster { get; set; }
        public virtual DbSet<Tbl_LoginMaster> Tbl_LoginMaster { get; set; }
        public virtual DbSet<Tbl_ReportMaster> Tbl_ReportMaster { get; set; }
        public virtual DbSet<tbl_StateMaster> tbl_StateMaster { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_StateMaster>()
                .Property(e => e.StateCode)
                .IsUnicode(false);
        }
    }
}
