using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal abstract class Motorkøretøj
    {
        public double MotorStørrelse { get; set; }

        public Motorkøretøj(double motorStørrelse)
        {
            MotorStørrelse = motorStørrelse;
        }

        public abstract void SetServiceInterval();
    }

}
