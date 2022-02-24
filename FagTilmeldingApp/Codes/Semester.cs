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
        public override string? UddannelsesLinje { get; set; }
        public override string? UddannelseslinjeBeskrivelse { get; set; }

        public Semester(string schoolName, string semesterNavn) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }
        public override void SetUddannelsesLinje(string uddannelsesLinje)
        {
            UddannelsesLinje = uddannelsesLinje;
        }
        public override void SetUddannelsesLinje(string uddannelsesLinje, string uddannelseslinjeBeskrivelse)
        {
            UddannelsesLinje = uddannelsesLinje;
            UddannelseslinjeBeskrivelse = "[ " + uddannelseslinjeBeskrivelse + " ]";
        }

    }
}
