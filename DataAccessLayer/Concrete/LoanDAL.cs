using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Loan> GetLoanbyUser(int id)
        {
            using var context_ = new Context();
            return context_.Loans.Where(x => x.UserID == id).ToList();
        }
    }
}
