using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IFeelingDAL
    {
        /// <summary>
        /// Geeft de lijst van alle feelings
        /// </summary>
        /// <returns>lijst van de feelings</returns>
        List<Feeling> GetAll();



    }
}
