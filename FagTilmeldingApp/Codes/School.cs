using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class School : Semester
    {
        string? SchoolName { get; set; }

        public School(string schoolName, string semesterNavn) : base(string semesterNavn)
        {

        }
    }
}
