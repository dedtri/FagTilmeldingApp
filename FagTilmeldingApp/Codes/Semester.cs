using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal sealed class Semester : School
    {
        public string? SemesterNavn { get; set; }

        public Semester(string semesterNavn, String schoolName) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }

    }
}
