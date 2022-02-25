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
        public string? UddannelsesLinje { get; set; }
        public string? UddannelseslinjeBeskrivelse { get; set; }

        public Semester(string schoolName, string semesterNavn) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }
        public override void SetUddannelsesLinje(string uddannelseslinje)
        {
            UddannelsesLinje = uddannelseslinje;
        }
        public override void SetUddannelsesLinje(string uddannelseslinje, string uddannelsesbeskrivelse)
        {
            UddannelsesLinje = uddannelseslinje;
            UddannelseslinjeBeskrivelse = "[ " + uddannelsesbeskrivelse + " ]";
        }

    }
}
