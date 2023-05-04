using DataAccessLayer.Interfaces;
using Entity;
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
        public int AddReview(Review review)
        {
            using var context_ = new Context();
            context_.Add(review);
            return context_.SaveChanges();
           
        }

       

        public List<Review> GetReviewbyID(int id)
        {
            using var context_ = new Context();
           return context_.Reviews.Where(x=>x.CarID==id).ToList();  
           

        }
    }
}
