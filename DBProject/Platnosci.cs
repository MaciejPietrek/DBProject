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
    
    public partial class Platnosci
    {
        public int id_platnosci { get; set; }
        public Nullable<int> id_wynajmu { get; set; }
        public Nullable<System.DateTime> data_platnosci { get; set; }
        public float cena { get; set; }
        public string tytul { get; set; }
    
        public virtual Wynajmy Wynajmy { get; set; }
    }
}
