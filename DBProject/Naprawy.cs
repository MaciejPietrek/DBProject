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
    
    public partial class Naprawy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Naprawy()
        {
            this.FakturyNapraw = new HashSet<FakturyNapraw>();
        }
    
        public int id_naprawy { get; set; }
        public Nullable<int> id_usterki { get; set; }
        public Nullable<int> id_firmy { get; set; }
        public string nr_telefonu { get; set; }
        public string stan { get; set; }
        public Nullable<System.DateTime> data_zlecenia { get; set; }
        public Nullable<System.DateTime> data_rozpoczecia { get; set; }
        public Nullable<System.DateTime> data_ukonczenia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakturyNapraw> FakturyNapraw { get; set; }
        public virtual Firmy Firmy { get; set; }
        public virtual Usterki Usterki { get; set; }
        public virtual StanyNapraw StanyNapraw { get; set; }
    }
}