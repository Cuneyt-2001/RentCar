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
        /// <summary>
        /// Om nieuwe lening toe te voegen
        /// </summary>
        /// <param name="loan"></param>
        /// <returns> geeft 1 als de  lening succesvol toegevoegd is</returns>
        int AddLoan(Loan loan);
        /// <summary>
        /// Geeft de lijst van alle leningen
        /// </summary>
        /// <returns>
        /// lijst van de leningen</returns>
        List<Loan> GetAll();
        /// <summary>
        /// geeft de de lijst van alle leningen op basis van gebruiker
        /// </summary>
        /// <param name="id"></param>
        /// <returns> de lijst</returns>
        List<Loan> GetLoanbyUser(int id);
        /// <summary>
        /// geeft de de lijst van alle leningen op basis van gebruiker
        /// </summary>
        /// <param name="id"></param>
        /// <returns> de lijst</returns>
        List<Table1AndTable2> GetLoanbyUser_(int id);
        /// <summary>
        /// geeft de de lijst van alle leningen 
        /// </summary>
        
        /// <returns> de lijst</returns>
        List<Table1AndTable2AndTable3> GetAll_();
        /// <summary>
        /// geeft de lijst van alle review op basis van gebruiekr
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ReviewDto> GetAllReviews_(int id);

    }
}
