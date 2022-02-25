using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class Box : IComparable<Box>
    {
        private double Højde { get; set; }
        private double Bredde { get; set; }
        private double Længde { get; set; }

        public double Volume { get; set; }

        private BoxType Type { get; set; }

        public Box()
        { }
        public Box(double H, double B, double L)
        {
            Højde = H;
            Bredde = B;
            Længde = L;
            GetVolume();
            SetBoxType();
        }

        private void GetVolume()
        {
            Volume = Højde * Længde * Bredde;
        }

        public override string ToString()
        {
          return "Volume: " + Volume + ", Type: " + Type.ToString();
        }

        public static Box operator +(Box a, Box b)
        {
            Box box = new Box();

            //box.Længde = b.Længde + a.Længde;
            //box.Højde = b.Højde + a.Højde;
            //box.Bredde = b.Bredde + a.Bredde;
            //box.Volume = box.Bredde * box.Højde * box.Længde;

            box.Volume = a.Volume + b.Volume;

            //regel Lillebox + lillebox giver mellembox, resten er storBox.
            if (a.Type == BoxType.lilleBox && b.Type == BoxType.lilleBox)
            {
                box.Type = BoxType.mellemBox;
            }
            else
            {
                box.Type = BoxType.storBox;
            }

            return box;
        }

        private void SetBoxType()
        {

            if(Volume <= 125)
            {
                Type = BoxType.lilleBox;
            }
            else if(Volume >= 126 && Volume <= 1500)
            {
                Type = BoxType.mellemBox;
            }
            else
            {
                Type = BoxType.storBox;
            }


            //? = If
            //: = Else/Else if
            //Type = (Volume <= 125) ? BoxType.lilleBox : (Volume >= 126 && Volume <= 1500) ? BoxType.mellemBox : BoxType.storBox;
        }

        public int CompareTo(Box next)
        {
            return this.Volume.CompareTo(next.Volume);
        }

        //public int CompareTo(Box next)
        //{

        //}

    }
}
