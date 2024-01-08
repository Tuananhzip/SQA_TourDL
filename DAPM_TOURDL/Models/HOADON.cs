namespace DAPM_TOURDL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int ID_HoaDon { get; set; }

        public int? SLTreEm { get; set; }

        public int? TongTienTour { get; set; }

        public DateTime NgayDat { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? SLNguoiLon { get; set; }

        public int? TienKhuyenMai { get; set; }

        public int? TienPhaiTra { get; set; }

        [StringLength(5)]
        public string ID_SPTour { get; set; }

        public int? ID_KH { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual SPTOUR SPTOUR { get; set; }
    }
}
