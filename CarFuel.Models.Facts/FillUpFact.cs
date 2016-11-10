using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarFuel.Models;

namespace CarFuel.Models.Facts
{
    public class FillUpFact
    {
        public class GeneralUsage
        {
            [Fact]
            public void NewFillUp()
            {
                FillUp f;
                f = new FillUp();
                Assert.Equal(0, f.Odometer);
                Assert.Equal(0.0, f.Liters);
                Assert.True(f.IsFull);
            }
       [Fact]
            public void TwoFullFillUps()
            {
                var f1 = new FillUp();
                f1.Odometer = 1000; f1.Liters = 40.0;
                var f2 = new FillUp();
                f2.Odometer = 1600; f2.Liters = 50.0;

                f1.NextFillUp = f2;

                double? result1 = f1.ConsumptionRate;
               // double? result2 = f2.ConsumptionRate;

                Assert.Equal(12.0, result1);
              //  Assert.Null(result2);
            }

       [Theory]
       [InlineData(1000, 40.0,1600,50.0, 12.0)]
       [InlineData(1600, 50.0, 2200, 60.0, 10.0)]
       public void TwoFullFillUps2(int odo1,double ltr1,int odo2,double ltr2,double res)
       {
           var f1 = new FillUp();
           f1.Odometer = odo1;
           f1.Liters = ltr1;
           var f2 = new FillUp();
           f2.Odometer = odo2; 
           f2.Liters = ltr2;

           f1.NextFillUp = f2;

           double? result1 = f1.ConsumptionRate;
           // double? result2 = f2.ConsumptionRate;

           Assert.Equal(res, result1);
           //  Assert.Null(result2);
       }

        }
         public class ConsumptionRateFact
            {
            [Fact]
             public void FirstFillUp_ReturnNull(){

                 var f = new FillUp();
                 f.Odometer = 1000;
                 f.Liters = 40;
                 double? result = f.ConsumptionRate;
                 Assert.Null(result);
                
            }
          

         }

       // public class FilUp
    }
}
