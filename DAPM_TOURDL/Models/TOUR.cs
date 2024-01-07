namespace DAPM_TOURDL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOUR")]
    public partial class TOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOUR()
        {
            SPTOURs = new HashSet<SPTOUR>();
        }

        [Key]
        [StringLength(5)]
        public string ID_TOUR { get; set; }

        public string TenTour { get; set; }

        public int? GiaTour { get; set; }

        public string MoTa { get; set; }

        public string HinhTour { get; set; }

        public string TinhThanh { get; set; }

        public string LoaiTour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPTOUR> SPTOURs { get; set; }
    }
}
