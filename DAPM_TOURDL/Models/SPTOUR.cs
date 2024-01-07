namespace DAPM_TOURDL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SPTOUR")]
    public partial class SPTOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPTOUR()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(5)]
        public string ID_SPTour { get; set; }

        public string TenSPTour { get; set; }

        public int? GiaNguoiLon { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayKhoiHanh { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayKetThuc { get; set; }

        public string MoTa { get; set; }

        public string DiemTapTrung { get; set; }

        public string DiemDen { get; set; }

        public int? SoNguoi { get; set; }

        public string HinhAnh { get; set; }

        public int? GiaTreEm { get; set; }

        public int? ID_NV { get; set; }

        [StringLength(5)]
        public string ID_TOUR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual TOUR TOUR { get; set; }
    }
}
