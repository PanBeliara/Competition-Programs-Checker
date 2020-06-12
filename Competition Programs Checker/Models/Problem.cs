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
    
    public partial class Problem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Problem()
        {
            this.Solutions = new HashSet<Solution>();
            this.SolutionsQueues = new HashSet<SolutionsQueue>();
            this.TestRuns = new HashSet<TestRun>();
        }
    
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public byte[] assignment { get; set; }
        public bool is_active { get; set; }
        public string best_scores_cache { get; set; }
        public string worst_best_score { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solution> Solutions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolutionsQueue> SolutionsQueues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestRun> TestRuns { get; set; }
    }
}
