using CarFuel.Models;
using CarFuel.Service;
using CarFuel.Services.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace CarFeul.Services.Facts
{
    public class CarServiceFact
    {
        [Fact]
        public void PlateNoMustBeUniqued()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(m => m.IsLoggedIn()).Returns(true);
            mock.Setup(m => m.CurrentUserId()).Returns(Guid.NewGuid().ToString());

            var repo = new FakeRepository<Car>();
            var s = new CarService(repo,mock.Object);
            var c1 = new Car { PlateNo = DateTime.Now.Millisecond.ToString() };
            var c2 = new Car { PlateNo = DateTime.Now.Millisecond.ToString() };

            s.Add(c1);
          //  s.Add(c2);

            //  Assert.Throws<Exception>("notb")
            Assert.Throws<Exception>(() =>
            {
                s.Add(c2);
            });
           // Assert.Equal("duplicated", c2.PlateNo);


        }

        [Fact]
        public void UserCanAddNotMoreThanTwoCars()
        {
           // IUserService userService;
            var mock = new Mock<IUserService>();
            mock.Setup(m => m.IsLoggedIn()).Returns(true);
            mock.Setup(m => m.CurrentUserId()).Returns(Guid.NewGuid().ToString());

            var repo = new FakeRepository<Car>();
            var s = new CarService(repo, mock.Object);
            var c1 = new Car { PlateNo = "123" };
            var c2 = new Car { PlateNo = "124" };
            var c3 = new Car { PlateNo = "125" };

            s.Add(c1);
            s.Add(c2);

            Assert.Throws<Exception>(() =>
            {
                s.Add(c3);
            });
        }
    }
}
