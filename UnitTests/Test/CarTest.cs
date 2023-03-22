using BusinessLayer;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Mock;

namespace UnitTests.Test
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CarTest
    {
        [TestMethod]
        public void AddCar()
        {
            //Arrange

            CarMock carmock = new CarMock();

            CarBLL carBLL = new CarBLL(carmock);
            Car car = new Car()
            {
                CarID = 3,
                Body = "Hatchback",
                Brand = "Honda",
                Model = "Civic",
                Transmission = "Automaat",
                Year = "2017",
                Visibility = true


            };


            //Act

            carBLL.AddCar(car);
            var result = carmock.cars.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(car.CarID, carmock.cars.Last().CarID);
            Assert.AreEqual(car.Body, carmock.cars.Last().Body);
            Assert.AreEqual(car.Brand, carmock.cars.Last().Brand);
            Assert.AreEqual(car.Model, carmock.cars.Last().Model);
            Assert.AreEqual(car.Transmission, carmock.cars.Last().Transmission);
            Assert.AreEqual(car.Year, carmock.cars.Last().Year);
            Assert.AreEqual(car.Visibility, carmock.cars.Last().Visibility);






        }
        [TestMethod]
        public void GetCar()
        {
            //Arrange
            CarMock carmock = new CarMock();

            CarBLL carBLL = new CarBLL(carmock);
            var carlist = carBLL.GetCars();
            var getcar = carlist[0];
            //Act
            carBLL.GetCar(getcar.CarID);

            //Assert
            Assert.AreEqual(3, getcar.CarID);
            Assert.AreEqual(getcar.CarID, carmock.cars.First().CarID);
            Assert.AreEqual(getcar.Body, carmock.cars.First().Body);
            Assert.AreEqual(getcar.Brand, carmock.cars.First().Brand);
            Assert.AreEqual(getcar.Model, carmock.cars.First().Model);
            Assert.AreEqual(getcar.Transmission, carmock.cars.First().Transmission);
            Assert.AreEqual(getcar.Year, carmock.cars.First().Year);
            Assert.AreEqual(getcar.Visibility, carmock.cars.First().Visibility);

        }
        [TestMethod]
        public void GetCars()
        {
            //Arrange
            CarMock carmock = new CarMock();

            CarBLL carBLL = new CarBLL(carmock);



            //Act

            List<Car> cars = carBLL.GetCars();


            //Assert
            Assert.AreEqual(carmock.GetCars().Count(), cars.Count); ;
            Assert.AreEqual(2, cars.Count);
            for (int i = 0; i < cars.Count; i++)
            {
                Assert.AreEqual(cars[i].CarID, carmock.cars[i].CarID);
                Assert.AreEqual(cars[i].Model, carmock.cars[i].Model);
                Assert.AreEqual(cars[i].Year, carmock.cars[i].Year);
                Assert.AreEqual(cars[i].Transmission, carmock.cars[i].Transmission);
                Assert.AreEqual(cars[i].Brand, carmock.cars[i].Brand);
                Assert.AreEqual(cars[i].Body, carmock.cars[i].Body);
                Assert.AreEqual(cars[i].Visibility, carmock.cars[i].Visibility);
            }

        }
        [TestMethod]
        public void RemoveAuto()
        {
            //Arrange
            CarMock carmock = new CarMock();

            CarBLL carBLL = new CarBLL(carmock);

            var carlist = carBLL.GetCars();
            var getcar = carlist[0];
            //Act
            carBLL.RemoveAuto(getcar);
            //Assert
            Assert.AreEqual(1, carmock.cars.Count);
            Assert.AreEqual(2, carmock.cars.First().CarID);
            Assert.AreEqual("Mercedes", carmock.cars[0].Brand);
            Assert.AreEqual("Sedan", carmock.cars.First().Body);

        }
        [TestMethod]
        public void EditAuto()
        {
            //Arrange

            CarMock carmock = new CarMock();

            CarBLL carBLL = new CarBLL(carmock);
            Car car2 = new Car()
            {
                CarID = 3,
                Body = "Hatchback",
                Brand = "Honda",
                Model = "Civic",
                Transmission = "Automaat",
                Year = "2018",
                Visibility = true

            };


            //Act

            carBLL.EditAuto(car2);


            //Assert

            Assert.AreEqual(car2.CarID, carmock.cars[1].CarID);
            Assert.AreEqual(car2.Model, carmock.cars[1].Model);
            Assert.AreEqual(car2.Year, carmock.cars[1].Year);
            Assert.AreEqual(car2.Transmission, carmock.cars[1].Transmission);
            Assert.AreEqual(car2.Brand, carmock.cars[1].Brand);
            Assert.AreEqual(car2.Body, carmock.cars[1].Body);
            Assert.AreEqual(car2.Visibility, carmock.cars[1].Visibility);


        }

    }
}
