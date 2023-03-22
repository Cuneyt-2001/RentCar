using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CarBLL
    {
        private ICarDAL _ICar;

        public CarBLL(ICarDAL iCar)
        {
            _ICar = iCar;
        }
        public int AddCar(Car car)
        {
           return _ICar.AddCar(car);
        }
        public Car GetCar(int id)
        {
            return _ICar.GetCar(id);
        }
        public List<Car> GetCars()
        {
            return _ICar.GetCars();
        }
        public bool RemoveAuto(Car car)
        {
            return _ICar.RemoveAuto(car);
        }
        public bool EditAuto(Car car)
        {
            return _ICar.EditAuto(car);   
        }
    }
}
