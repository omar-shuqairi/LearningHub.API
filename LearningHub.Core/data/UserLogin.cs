using System;
using System.Collections.Generic;

namespace LearningHub.Core.data
{
    public partial class UserLogin
    {
        public decimal Loginid { get; set; }
        public string? Username { get; set; }
        public string? Passwordd { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Student? Student { get; set; }
    }
}
