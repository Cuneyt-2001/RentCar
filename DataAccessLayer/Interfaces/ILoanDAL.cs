using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILoanDAL
    {
        int AddLoan(Loan loan);
        List<Loan> GetAll();
        List<Loan> GetLoanbyUser(int id);
       
    }
}
