using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class Bil : Motorkøretøj
    {
        public bool ErFirHjulTræk { get; set; }

        public Bil(bool erFirHjulTræk, double motorStørrelse) : base(motorStørrelse)
        {
            ErFirHjulTræk = erFirHjulTræk;
        }

        public override void SetServiceInterval()
        {
        }

        public string Test()
        {
            return "";
        }

        public void Test(string s)
        {
        }
    }

}
