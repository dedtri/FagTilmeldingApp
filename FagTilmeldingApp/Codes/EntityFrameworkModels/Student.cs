using System;
using System.Collections.Generic;

namespace FagTilmeldingApp.Codes.EntityFrameworkModels
{
    public partial class Student
    {
        public Student()
        {
            Classes = new HashSet<Class>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Class> Classes { get; set; }
    }
}
