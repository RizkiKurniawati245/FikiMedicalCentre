//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FikiMedicalCentre.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class trkonsultasi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trkonsultasi()
        {
            this.dtkonsultasis = new HashSet<dtkonsultasi>();
            this.trpembayarans = new HashSet<trpembayaran>();
        }
    
        public int id_konsultasi { get; set; }
        public System.DateTime tgl_konsultasi { get; set; }
        public int id_daftar_konsultasi { get; set; }
        public string saran_dokter { get; set; }
        public long biaya_konsultasi { get; set; }
        public int status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dtkonsultasi> dtkonsultasis { get; set; }
        public virtual trpendaftaran_konsultasi trpendaftaran_konsultasi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trpembayaran> trpembayarans { get; set; }
    }
}