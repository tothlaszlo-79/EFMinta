//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFMinta
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableWithForigenKey
    {
        public int nid { get; set; }
        public string SajatAdat1 { get; set; }
        public Nullable<System.DateTime> SajatAdat2 { get; set; }
        public Nullable<int> SajatAdat3 { get; set; }
        public Nullable<int> ForigenKeyTable_id { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual ForigenKeyTable ForigenKeyTable { get; set; }
    }
}
