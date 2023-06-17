using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Context;

namespace BusinessLayer
{
    public class LoanBLL
    {
        private ILoanDAL _IloanDAL;

        public LoanBLL(ILoanDAL iloanDAL)
        {
            _IloanDAL = iloanDAL;
        }
        public int AddLoan(Loan loan)
        {
            if (CheckAvailibilityofCar(loan) == true)
            {
                return _IloanDAL.AddLoan(loan);
            }
            return 0;
        }
        public List<Loan> GetAll()
        {
            return _IloanDAL.GetAll();
        }
        public List<Loan> GetLoanbyUser(int id)
        {
           return _IloanDAL.GetLoanbyUser(id);
            
        }
        public bool CheckAvailibilityofCar(Loan loan)
        {
            TimeSpan timeSpan = loan.ReturnDate - loan.LoanDate;
            if (!(loan.LoanDate >= DateTime.Now.Date && loan.ReturnDate >= DateTime.Now.Date && loan.LoanDate.Date <= loan.ReturnDate && timeSpan.Days <= 20))
            {

                return false;
            }

            var allLoans = _IloanDAL.GetAll();
            if (allLoans.Any(a => a.CarID == loan.CarID && ((loan.LoanDate >= a.LoanDate && loan.LoanDate <= a.ReturnDate) || (loan.ReturnDate >= a.LoanDate && loan.ReturnDate <= a.ReturnDate))))
            {
                return false;
            }
            return true;
        }
        public List<Table1AndTable2> GetLoanbyUser_(int id)
        {
            return _IloanDAL.GetLoanbyUser_(id);



        }
       public List<Table1AndTable2AndTable3> GetAll_()
        {
            return _IloanDAL.GetAll_(); 
        }
        public List<ReviewDto> GetAllReviews_(int id)
        {
            return _IloanDAL.GetAllReviews_(id);

        }

    }
}
