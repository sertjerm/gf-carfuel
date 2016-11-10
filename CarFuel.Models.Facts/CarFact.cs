using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarFuel.Models;

namespace CarFuel.Models.Facts
{
    public class CarFact
    {
        public class GeneralUsage
        {
            [Fact]
            public void NewCar()
            {
                Car c = new Car();
                //c.Make = "Nissan";
                //c.Model = "Sunny";
                // c.
                Assert.Equal("Make", c.Make);
                Assert.Equal("Model", c.Model);
                Assert.NotNull(c.FillUps);
                Assert.Empty(c.FillUps);

            }
        }
        public class AddFillUpMethod
        {
            [Fact]
            public void AddFirstFillUp()
            {
                Car c = new Car();
                //FillUp f1 = new FillUp();
                // f1.Odometer = 1000;
                // f1.Liters = 40;
                // c.FillUps.Add(f1);
                FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);


                Assert.Equal(1, c.FillUps.Count());
                Assert.Equal(1000, f1.Odometer);
                Assert.Equal(40.0, f1.Liters);



            }
            [Fact]
            public void AddTwoFillUp()
            {
                Car c = new Car();
                //FillUp f1 = new FillUp();
                // f1.Odometer = 1000;
                // f1.Liters = 40;
                // c.FillUps.Add(f1);
                FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);
                FillUp f2 = c.AddFillUp(odometer: 1600, liters: 50.0);

                Assert.Same(f2, f1.NextFillUp);
                Assert.Equal(2, c.FillUps.Count());
                //Assert.Equal(1000, f1.Odometer);
                //Assert.Equal(40.0, f1.Liters);



            }
        }
        public class AverageConsumptionRateProperty
        {
            [Fact]
            public void CarAverageConsumption()
            {
                Car c = new Car();

                Assert.Null(c.AverageConsumptionRate);

                FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);
                Assert.Null(c.AverageConsumptionRate);

                FillUp f2 = c.AddFillUp(odometer: 1600, liters: 50.0);
                Assert.Equal(12.0, c.AverageConsumptionRate);

                FillUp f3 = c.AddFillUp(odometer: 2200, liters: 60.0);
                Assert.Equal(10.91, c.AverageConsumptionRate);

                //FillUp f4 = c.AddFillUp(odometer: 4000, liters: 80.0);
                //Assert.Equal(15.79, c.AverageConsumptionRate);

                //FillUp f5 = c.AddFillUp(odometer: 100000, liters: 500.0);
                //Assert.Equal(143.48, c.AverageConsumptionRate);


                FillUp f5 = c.AddFillUp(odometer: 100000, liters: 500.0);
                Assert.Equal(162.3, c.AverageConsumptionRate);

               // FillUp f4 = c.AddFillUp(odometer: 4000, liters: 80.0);
              //  Assert.Equal(143.48, c.AverageConsumptionRate);


            }
            [Fact]
            public void ForgotPrevios_ReturnNull()
            {
                Car c = new Car();

                Assert.Null(c.AverageConsumptionRate);

                FillUp f = c.AddFillUp(2000, 45.0, false);

                Assert.False(f.ForgotPrevios);
                Assert.Null(c.AverageConsumptionRate);



                //FillUp f2 = c.AddFillUp(5000, 60.0, true);
                //Assert.Null(c.AverageConsumptionRate);
                //Assert.True(f2.ForgotPrevios);
            }
        }
    }
}
