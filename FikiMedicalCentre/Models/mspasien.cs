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
    
    public partial class mspasien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mspasien()
        {
            this.trpendaftaran_konsultasi = new HashSet<trpendaftaran_konsultasi>();
        }
    
        public int id_pasien { get; set; }
        public string nama { get; set; }
        public string tempat_lahir { get; set; }
        public System.DateTime tgl_lahir { get; set; }
        public string jenis_kelamin { get; set; }
        public string alamat { get; set; }
        public string no_telp { get; set; }
        public string email { get; set; }
        public int id_role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
    
        public virtual msrole msrole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trpendaftaran_konsultasi> trpendaftaran_konsultasi { get; set; }
    }
}
