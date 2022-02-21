using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class Semester
    {
        string? SemesterNavn { get; set; }

        public Semester(string semesterNavn)
        {
            SemesterNavn = semesterNavn;
        }

    }
}
