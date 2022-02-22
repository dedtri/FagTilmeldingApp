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
        public string? Uddannelseslinje { get; set; }  

        public Semester(string schoolName, string semesterNavn) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }
        public override void SetUddannelsesLinje(string uddannelseslinje)
        {
            Uddannelseslinje = uddannelseslinje;
        }

    }
}
