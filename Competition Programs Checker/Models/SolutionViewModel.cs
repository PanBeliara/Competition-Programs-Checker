using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Competition_Programs_Checker.Models
{
    public class SolutionViewModel
    {
        public string problemName { get; set; }
        public string userName { get; set; }
        public string code { get; set; }
        public string codeLanguage { get; set; }
        public string submittedTime { get; set; }
        public string execTime { get; set; }
        public string is_error { get; set; }
        public string score { get; set; }
    }
}