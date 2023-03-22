using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICarDAL
    {
        int AddCar(Car car);
        Car GetCar(int id);
        List< Car> GetCars();
        bool RemoveAuto(Car car);    
        bool EditAuto(Car car);


    }
}
