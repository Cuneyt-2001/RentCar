using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReviewBLL
    {
        private IReviewDAL _IReviewDAL;

        public ReviewBLL(IReviewDAL iReviewDAL)
        {
            _IReviewDAL = iReviewDAL;
        }
        public int AddReview(Review review)
        {
            return _IReviewDAL.AddReview(review);

        }
        public List<Review> GetReviewbyID(int id)
        {
            return _IReviewDAL.GetReviewbyID(id);

        }
    }
}
