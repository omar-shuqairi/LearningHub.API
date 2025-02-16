using System;
using System.Collections.Generic;

namespace LearningHub.Core.data
{
    public partial class Student
    {
        public Student()
        {
            Stdcourses = new HashSet<Stdcourse>();
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal Studentid { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? Dateofbirth { get; set; }

        public virtual ICollection<Stdcourse> Stdcourses { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
