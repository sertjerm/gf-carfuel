using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarFuel.Models
{
    public class FillUp
    {
       // private bool _isFull = true;
       // private double? _ConsumptionRate = null;
        public FillUp()
        {
           IsFull=true;
           ForgotPrevios = false;

         // _ConsumptionRate= (Odometer - NextFillUp.Odometer) / NextFillUp.Liters;

        }

        public int Id { get; set; }
        public int Odometer { get; set; }

        public double Liters { get; set; }

        public bool IsFull { get; set; }

        public bool ForgotPrevios { get; set; }

        public int? Distance
        {
            get
            {
                if (NextFillUp == null) return null;
                return NextFillUp.Odometer - Odometer;
            }
        }
      
        public double? ConsumptionRate
        {
            get
            {
                if (NextFillUp != null)
                {
                    return ( NextFillUp.Odometer-Odometer) / NextFillUp.Liters;
                }
                return null;
            }
            //set { }

        }

        public FillUp NextFillUp { get; set; }
    }
}
