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
    public class LoanDAL : ILoanDAL
    {
        public int AddLoan(Loan loan)
        {
            using var context_ = new Context();
            context_.Add(loan);
            return context_.SaveChanges();
        }

        public List<Loan> GetAll()
        {
            using var context_ = new Context();
            return context_.Loans.ToList();
        }


        public List<Table1AndTable2> GetLoanbyUser_(int id)
        {
            using var context_ = new Context();
            //Anotehr Way

            //var loanViewModel = context_.Loans.Where(x => x.UserID == id).Include(a => a.car)
            //    .Select(a => new Table1AndTable2 { Car = a.car.Brand, LoanDate = a.LoanDate, ReturnDate = a.ReturnDate }).ToList();


            //  var result =context_.Loans.Where(x => x.UserID == id).ToList();
            var newresult = from t1 in context_.Loans.Where(x => x.UserID == id)
                            join t2 in context_.Cars
                             on t1.CarID equals t2.CarID
                            select new Table1AndTable2 { LoanDate = t1.LoanDate, ReturnDate = t1.ReturnDate, Car = t2.Brand };
            return newresult.ToList();

        }

        public List<ReviewDto> GetAllReviews_(int id)
        {
            using var context_ = new Context();

            var reviewViewModel = context_.Reviews.Include(a => a.car).Include(a => a.user)
                .Where(x => x.CarID == id).Select(a => new ReviewDto { ReviewContent = a.Reviewcontent, user = a.user.Name, Car = a.car.Brand }).ToList();

            //Anotehr Way
            //var newresult = from t1 in context_.reviews
            //                join t2 in context_.cars.where (x => x.carid == id)
            //                 on t1.carid equals t2.carid
            //                join t3 in context_.users
            //                on t1.userid equals t3.userid
            //                select new table { reviewcontent = t1.reviewcontent, user = t3.name, car = t2.brand };

            return reviewViewModel;
        }



        List<Table1AndTable2AndTable3> ILoanDAL.GetAll_()
        {
            using var context_ = new Context();
            var newresult = from t1 in context_.Loans.Where(x => x.ReturnDate >= DateTime.Now.Date)
                            join t2 in context_.Cars
                             on t1.CarID equals t2.CarID
                            join t3 in context_.Users
                            on t1.UserID equals t3.UserID
                            select new Table1AndTable2AndTable3 { LoanDate = t1.LoanDate, ReturnDate = t1.ReturnDate, Car = t2.Brand, user = t3.Name };
            return newresult.ToList();
        }

        List<Loan> ILoanDAL.GetLoanbyUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
