namespace DAPM_TOURDL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            SPTOURs = new HashSet<SPTOUR>();
        }

        [Key]
        public int ID_NV { get; set; }

        public string HoTen_NV { get; set; }

        [StringLength(5)]
        public string GioiTinh_NV { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh_NV { get; set; }

        public string MatKhau { get; set; }

        public string Mail_NV { get; set; }

        public string ChucVu { get; set; }

        [StringLength(10)]
        public string SDT_NV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPTOUR> SPTOURs { get; set; }
    }
}
