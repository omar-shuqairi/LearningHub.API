using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTOs
{
    public class Search
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Coursename { get; set; }
        public decimal? Markofstd { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}
