using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal abstract class School
    {
        public string? SchoolName { get; set; }

        public abstract string? UddannelsesLinje { get; set; }   
        public abstract string? UddannelseslinjeBeskrivelse { get; set; }    

        public School(string schoolName)
        {
            SchoolName = schoolName;
        }
        public abstract void SetUddannelsesLinje(string? UddannelsesLinje);

        public abstract void SetUddannelsesLinje(string? UddannelsesLinje, string? UddannelsesBeskrivelse);

    }
}
