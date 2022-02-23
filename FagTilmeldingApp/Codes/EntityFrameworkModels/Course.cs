using System;
using System.Collections.Generic;

namespace FagTilmeldingApp.Codes.EntityFrameworkModels
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<Class> Classes { get; set; }
    }
}
