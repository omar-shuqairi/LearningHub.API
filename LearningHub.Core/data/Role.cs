using System;
using System.Collections.Generic;

namespace LearningHub.Core.data
{
    public partial class Role
    {
        public Role()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
