using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mock
{
    public class LoanMock : ILoanDAL
    {
        public List<Loan> Loans = new List<Loan>();
        public LoanMock()
        {
            Loan loan1 = new Loan()
            {
                CarID = 1,
                UserID = 1,
                LoanID = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(12)
               

            };

            Loan loan2 = new Loan()
            {
                CarID = 2,
                UserID = 2,
                LoanID = 2,
                LoanDate = DateTime.Now.AddDays(2),
                ReturnDate = DateTime.Now.AddDays(12)

            };
            Loans.Add(loan1);
            Loans.Add(loan2);

        }

        public int AddLoan(Loan loan)
        {
            Loans.Add(loan);
            return Loans.Count;
        }

        public List<Loan> GetAll()
        {
           return Loans;
        }

        public List<Context.ReviewDto> GetAllReviews_(int id)
        {
            throw new NotImplementedException();
        }

        public List<Context.Table1AndTable2AndTable3> GetAll_()
        {
            throw new NotImplementedException();
        }

        public List<Loan> GetLoanbyUser(int id)
        {
            List<Loan> loan_ = Loans.FindAll(x => x.UserID == id).ToList();
            return loan_;
        }

        public List<Context.Table1AndTable2> GetLoanbyUser_(int id)
        {
            throw new NotImplementedException();
        }
    }
}
