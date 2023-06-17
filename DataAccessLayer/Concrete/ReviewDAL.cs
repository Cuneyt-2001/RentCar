using DataAccessLayer.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Context;

namespace DataAccessLayer.Concrete
{
    public class ReviewDAL : IReviewDAL
    {
        public int AddReview(Review review, int[] feelings)
        {
            using (var context_ = new Context())
            {
                context_.Add(review);
                context_.SaveChanges();

                foreach (var item in feelings)
                {
                    string sqlQuery = "INSERT INTO FeelingReview (AllreviewsReviewID, FeelingsFeelingID) VALUES ({0}, {1})";
                    int rowsAffected = context_.Database.ExecuteSqlRaw(sqlQuery, review.ReviewID, item);
                }
                return 1;
            }          
        }


        public List<Review> GetReviewbyID(int id)
        {
            using var context_ = new Context();
           return context_.Reviews.Where(x=>x.CarID==id).ToList();  
           

        }
    }
}
