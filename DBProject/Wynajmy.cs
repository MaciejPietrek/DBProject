//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wynajmy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wynajmy()
        {
            this.FakturyWynajem = new HashSet<FakturyWynajem>();
            this.Platnosci = new HashSet<Platnosci>();
        }
    
        public int id_wynajmu { get; set; }
        public Nullable<int> id_mieszkania { get; set; }
        public Nullable<System.DateTime> data_rozpoczecia { get; set; }
        public Nullable<System.DateTime> data_zakonczenia { get; set; }
        public Nullable<int> id_najemcy { get; set; }
        public Nullable<float> cena_miesieczna { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakturyWynajem> FakturyWynajem { get; set; }
        public virtual Mieszkania Mieszkania { get; set; }
        public virtual Najemcy Najemcy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Platnosci> Platnosci { get; set; }
    }
}