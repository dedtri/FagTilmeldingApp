using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class Teacher
    {
        public int LærerId { get; set; }
        public string? ForNavn { get; set; }
        public string? EfterNavn { get; set; }
    }
    internal class Student
    {
        public int ElevId { get; set; }
        public string? ForNavn { get; set; }
        public string? EfterNavn { get; set; }
    }
    internal class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int TeacherId { get; set; }
    }
    internal class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int? ElevId { get; set; }
        public int? CourseId { get; set; }
    }
}
