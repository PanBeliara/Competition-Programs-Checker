//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Competition_Programs_Checker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestRun
    {
        public int id { get; set; }
        public Nullable<int> problem_id { get; set; }
        public int order_position { get; set; }
        public string input { get; set; }
        public string output { get; set; }
    
        public virtual Problem Problem { get; set; }
    }
}
