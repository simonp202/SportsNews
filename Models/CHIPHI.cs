//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TuVanDuHoc_v2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHIPHI
    {
        public string MQCP { get; set; }
        public Nullable<int> HOCPHI { get; set; }
        public Nullable<int> SINHHOAT { get; set; }
        public Nullable<int> NHA { get; set; }
        public Nullable<int> DILAI { get; set; }
        public string MAQG { get; set; }
    
        public virtual QUOCGIA QUOCGIA { get; set; }
    }
}
