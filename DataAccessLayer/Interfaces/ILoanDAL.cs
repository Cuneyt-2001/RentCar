using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Context;

namespace DataAccessLayer.Interfaces
{
    public interface ILoanDAL
    {
        int AddLoan(Loan loan);
        List<Loan> GetAll();
        List<Loan> GetLoanbyUser(int id);
        List<Table1AndTable2> GetLoanbyUser_(int id);
        List<Table1AndTable2AndTable3> GetAll_();
        List<ReviewDto> GetAllReviews_(int id);

    }
}
