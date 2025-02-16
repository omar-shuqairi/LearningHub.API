﻿using System;
using System.Collections.Generic;

namespace LearningHub.Core.data
{
    public partial class Stdcourse
    {
        public decimal Id { get; set; }
        public decimal? Markofstd { get; set; }
        public DateTime? Dateofregister { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
