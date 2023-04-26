using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CarDAL : ICarDAL
    {
        public int AddCar(Car car)
        {
            using var context_ = new Context();
            context_.Add(car);
            return context_.SaveChanges();
        }

        public bool EditAuto(Car car)
        {
            using var context_ = new Context();
            var findcar = GetCar(car.CarID);
            findcar.CarID = car.CarID;
            findcar.Brand = car.Brand;
            findcar.Model=car.Model;
            findcar.Body = car.Body;
            findcar.Year = car.Year;
            findcar.Transmission = car.Transmission;
            context_.Update(car);
            context_.SaveChanges();
            return true;



            //using var context_ = new Context();
            //context_.Update(car);
            //context_.SaveChanges();
            //return true;
        }

        public Car GetCar(int id)
        {
            using var context_ = new Context();
            return context_.Cars.ToList().Where(x => x.CarID == id).First();
            // return context_.Set<Car>().Find(id);
        }

        public List<Car> GetCars()
        {
            using var context_ = new Context();
            return context_.Cars.ToList();


        }

        public bool RemoveAuto(Car car)
        {
            using var context_ = new Context();
            context_.Remove(car);
            context_.SaveChanges();
            return true;
        }
    }
}
