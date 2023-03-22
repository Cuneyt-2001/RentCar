using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mock
{
    public class CarMock : ICarDAL
    {
        public List<Car> cars = new List<Car>();



        public CarMock()
        {
            Car car1 = new Car()
            {
                CarID = 1,
                Body = "Sedan",
                Brand = "Bmw",
                Model = "525",
                Transmission = "Automat",
                Year = "2015",
                Visibility = true

            };

            Car car2 = new Car()
            {
                CarID = 2,
                Body = "Cabrio",
                Brand = "Mercedes",
                Model = "Clk",
                Transmission = "manual",
                Year = "2016",
                Visibility = true

            };
            cars.Add(car1);
            cars.Add(car2);
        }

        public int AddCar(Car car)
        {
            cars.Add(car);
            return cars.Count;
        }

        public bool EditAuto(Car car)
        {
            Car car_ = cars.First(x => x.CarID == car.CarID);
            cars.Remove(car_);
            cars.Add(car);
            return true;
        }

        public Car GetCar(int id)
        {

            Car car_ = cars.Find(x => x.CarID == id);
            return car_;
        }

        public List<Car> GetCars()
        {
           return cars;
        }

        public bool RemoveAuto(Car car)
        {
            Car _car = cars.Find(x => x.CarID == car.CarID);
            cars.Remove(_car);
            return true;
        }
    }
}
