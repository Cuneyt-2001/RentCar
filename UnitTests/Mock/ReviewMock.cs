using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Context;

namespace UnitTests.Mock
{
    public class ReviewMock : IReviewDAL
    {
        public List<Review> reviews = new List<Review>();
        public ReviewMock()
        {
            Review review1 = new Review()
            {
                ReviewID = 1,
                CarID = 1,
                UserID=1,
                Reviewcontent="Good"
                


            };

            Review review2 = new Review()
            {
                ReviewID = 2,
                CarID = 2,
                UserID = 1,
                Reviewcontent = "Bad"

            };
            reviews.Add(review1);
            reviews.Add(review2);
        }

        public int AddReview(Review review)
        {
            reviews.Add(review);
            return reviews.Count;
        }

        public List<ReviewDto> GetAllReviews_(int id)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviewbyID(int id)
        {
            List<Review> review_ = reviews.FindAll(x => x.CarID == id).ToList();
            return review_;
        }
    }
}
