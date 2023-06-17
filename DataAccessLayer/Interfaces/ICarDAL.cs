using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICarDAL
    {   /// <summary>
        /// Via deze functie voeg ik een nieuwe auto toe.
        /// </summary>
        /// <param name="car"></param>
        /// <returns>geeft 1 als de auto toegevoegd is</returns>
        int AddCar(Car car);
        /// <summary>
        /// Via deze functie noem ik een auto op basis van zijn id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>geeft de auto ob basis van zijn id</returns>
        Car GetCar(int id);
        /// <summary>
        /// Geeft de lijst van de auto's
        /// </summary>
        /// <returns>lijst van de auto's</returns>
        List<Car> GetCars();
        /// <summary>
        /// wordt de auto verwijderd
        /// </summary>
        /// <param name="car"></param>
        /// <returns> true als de auto verwijderd is</returns>
        bool RemoveAuto(Car car);
        /// <summary>
        /// om gegevens van de auto te updaten
        /// </summary>
        /// <param name="car"></param>
        /// <returns>geef true als de auto succesvol geupdated is</returns>
        bool EditAuto(Car car);


    }
}
