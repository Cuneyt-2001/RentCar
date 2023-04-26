using BusinessLayer;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Mock;


namespace UnitTests.Test
{
  [TestClass]
    public class ReviewTest
    {
      [TestMethod]

        public void AddReview()
        {
            //Arrange

            ReviewMock reviewmock_ = new ReviewMock();

            ReviewBLL  reviewbll = new ReviewBLL(reviewmock_);
            Review review = new Review()
            {
                ReviewID = 3,
                CarID = 1,
                UserID = 2,
                Reviewcontent = "super"
            };


            //Act

            reviewbll.AddReview(review);
            var result = reviewmock_.reviews.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(review.ReviewID, reviewmock_.reviews.Last().ReviewID);
            Assert.AreEqual(review.CarID, reviewmock_.reviews.Last().CarID);
            Assert.AreEqual(review.UserID, reviewmock_.reviews.Last().UserID);
            Assert.AreEqual(review.Reviewcontent, reviewmock_.reviews.Last().Reviewcontent);
          



        }
        [TestMethod]
        public void GetReviewbyID()
        {
            //Arrange
            ReviewMock reviewmock_ = new ReviewMock();
            ReviewBLL reviewbll = new ReviewBLL(reviewmock_);

            //Act

            var result = reviewbll.GetReviewbyID(1);

            //Assert


            Assert.AreEqual(result.Count, reviewmock_.reviews.FindAll(b => b.CarID == 1).Count());
            Assert.AreEqual(result.First().CarID, reviewmock_.reviews.First().CarID);
            Assert.AreEqual(result.First().Reviewcontent, reviewmock_.reviews.First().Reviewcontent);


        }

    }
}
