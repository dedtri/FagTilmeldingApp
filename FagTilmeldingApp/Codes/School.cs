using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class School
    {
        public string? SchoolName { get; set; }

        public int FagIAlt { get; set; }   

        public School(string schoolName)
        {
            SchoolName = schoolName;
        }

        public virtual void SetCourseCount(List<Course> a)
        {
            FagIAlt = a.Count();
        }
    }
}
