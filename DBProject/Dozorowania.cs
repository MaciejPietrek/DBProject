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
    
    public partial class Dozorowania
    {
        public Nullable<System.DateTime> data_rozpoczecia { get; set; }
        public Nullable<System.DateTime> data_zakonczenia { get; set; }
        public int id_dozorcy { get; set; }
        public int id_budynku { get; set; }
    
        public virtual Budynki Budynki { get; set; }
        public virtual Dozorcy Dozorcy { get; set; }
    }
}
