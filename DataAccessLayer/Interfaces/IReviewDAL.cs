using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Context;

namespace DataAccessLayer.Interfaces
{
    public interface IReviewDAL
    {
        /// <summary>
        /// Het toevoegen van een review
        /// </summary>
        /// <param name="review"></param>
        /// <param name="feelings"></param>
        /// <returns> geeft 1 als de review succesvol opgeslagen is</returns>
        int AddReview(Review review, int[] feelings);
        /// <summary>
        /// Geeft de lijst van reviews op basis van gebruiker
        /// </summary>
        /// <param name="id"></param>
        /// <returns>geeft de lijst</returns>
        List<Review> GetReviewbyID(int id);
      
    }
}
