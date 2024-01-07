using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAPM_TOURDL.Models
{
    public partial class QLTOUR : DbContext
    {
        public QLTOUR()
            : base("name=QLTOUR")
        {
        }

        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<SPTOUR> SPTOURs { get; set; }
        public virtual DbSet<TOUR> TOURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
