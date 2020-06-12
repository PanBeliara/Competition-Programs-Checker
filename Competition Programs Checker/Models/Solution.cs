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
    
    public partial class Solution
    {
        public System.Guid id { get; set; }
        public Nullable<int> problem_id { get; set; }
        public string solver_id { get; set; }
        public string code { get; set; }
        public Nullable<int> code_language { get; set; }
        public System.DateTime submitted_time { get; set; }
        public System.DateTime checked_time { get; set; }
        public System.DateTimeOffset time_offset { get; set; }
        public Nullable<bool> is_error { get; set; }
        public string score { get; set; }
    
        public virtual Problem Problem { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
