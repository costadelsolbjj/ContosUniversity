using ContosoUniversity.Models;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Course:BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
