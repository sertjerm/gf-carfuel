using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CarFuel.Models
{
    public class Car
    {
        public Car()
        {
            Make = "Make";
            Model = "Model";
            FillUps = new List<FillUp>();
          //  AverageConsumptionRate = null;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Make { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(10)]
        public string PlateNo { get; set; }

        [StringLength(30)]
        public string Color { get; set; }

        [StringLength(40)]
        public string Owner { get; set; }

        public virtual ICollection<FillUp> FillUps { get; set; }


        public FillUp AddFillUp(int odometer, double liters,bool forgot=false)
        {
            FillUp f1 = new FillUp();
            f1.Odometer = odometer;
            f1.Liters = liters;
            f1.ForgotPrevios = forgot;

            //if (FillUps.Count > 0)
            if (FillUps.Any())
            {
                // FillUp f0 = 
                //FillUps[FillUps.Count-1].NextFillUp = f1;
                FillUps.Last().NextFillUp = f1;
            }

            FillUps.Add(f1);
            return f1;
            // throw new NotImplementedException();
        }

        //public double? AverageConsumptionRate_bak
        //{
        //    get
        //    {
        //        if (FillUps.Count <=1)
        //        {
        //            return null;
        //        }
        //        else
        //        {
                 
        //            FillUps = FillUps.OrderBy(o => o.Odometer).ToList<FillUp>();
                   
        //            int Odometers = 0;
        //            double Liters = 0;
        //            for (int i = 1; i < FillUps.Count; i++)
        //            {                                       
        //                    Odometers += (FillUps[i].Odometer - FillUps[i - 1].Odometer);
        //                    Liters += FillUps[i].Liters;
        //            }
        //            return Math.Round(Odometers / Liters,2);
                   
                       
        //        }
               
        //    }
        //   // set { }
        //}

        public double? AverageConsumptionRate
        {
            get
            {
                if (FillUps.Count <= 1)
                {
                    return null;
                }
                else
                {

                    FillUps = FillUps.OrderBy(o => o.Odometer).ToList<FillUp>();

                    int? totalDistances = FillUps.Sum(f=>f.Distance);
                    double? totalLiters = FillUps.Sum(t => t.Liters) - FillUps.FirstOrDefault().Liters;
                    //for (int i = 1; i < FillUps.Count; i++)
                    //{
                    //    Odometers += (FillUps[i].Odometer - FillUps[i - 1].Odometer);
                    //    Liters += FillUps[i].Liters;
                    //}
                   // return totalDistances / totalLiters;
                    return Math.Round((totalDistances / totalLiters)??0.0, 2,MidpointRounding.AwayFromZero);


                }

            }
            // set { }
        }
        //public FillUp AddFillUp(int odometer, double liters, bool forgot=false)
        //{
        //    FillUp f1 = new FillUp();
        //    f1.Odometer = odometer;
        //    f1.Liters = liters;
        //    f1.ForgotPrevios = forgot;
        //    //if (FillUps.Count > 0)
        //    if (FillUps.Any<FillUp>())
        //    {
        //        // FillUp f0 = 
        //        //FillUps[FillUps.Count-1].NextFillUp = f1;
        //        FillUps.Last().NextFillUp = f1;
        //    }

        //    FillUps.Add(f1);
        //    return f1;
        //}
    }
}
