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
    
    public partial class Usterki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usterki()
        {
            this.Naprawy = new HashSet<Naprawy>();
        }
    
        public int id_usterki { get; set; }
        public Nullable<int> id_mieszkania { get; set; }
        public string opis { get; set; }
        public string stan { get; set; }
    
        public virtual Mieszkania Mieszkania { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Naprawy> Naprawy { get; set; }
        public virtual StanyUsterek StanyUsterek { get; set; }
    }
}
