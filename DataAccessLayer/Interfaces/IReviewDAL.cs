using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReviewDAL
    {
        int AddReview(Review review);
        List<Review> GetReviewbyID(int id);
    }
}
