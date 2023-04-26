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
    public class LoanTest
    {
        public void AddLoan()
        {
            //Arrange

            LoanMock loancontainermock = new LoanMock();

            LoanBLL loancontainer = new LoanBLL(loancontainermock);

            DateTime date1 = DateTime.Now.AddDays(5);
            DateTime date3 = DateTime.Now.AddDays(8);


            Loan loan = new Loan()
            {
                
               
                LoanDate = date1,
                LoanID = 3,
                CarID = 1,
                ReturnDate = date3,
                UserID = 3,


            };

            //Act

            loancontainer.AddLoan(loan);
            var result = loancontainermock.Loans.Count;

            //Assert

            Assert.AreEqual(3, result);
            Assert.AreEqual(loan.CarID, loancontainermock.Loans.Last().CarID);
            Assert.AreEqual(loan.UserID, loancontainermock.Loans.Last().UserID);
            Assert.AreEqual(loan.LoanDate, loancontainermock.Loans.Last().LoanDate);
            Assert.AreEqual(loan.ReturnDate, loancontainermock.Loans.Last().ReturnDate);



        }
        [TestMethod]
        public void GetAll()
        {
            //Arrange
            LoanMock loancontainermock = new LoanMock();

            LoanBLL loancontainer = new LoanBLL(loancontainermock);



            //Act

            List<Loan> loans = loancontainer.GetAll();


            //Assert
            Assert.AreEqual(loancontainermock.GetAll().Count(), loans.Count); ;
            for (int i = 0; i < loans.Count; i++)
            {
                Assert.AreEqual(loans[i].LoanDate, loancontainermock.Loans[i].LoanDate);
                Assert.AreEqual(loans[i].ReturnDate, loancontainermock.Loans[i].ReturnDate);
                Assert.AreEqual(loans[i].LoanID, loancontainermock.Loans[i].LoanID);
                Assert.AreEqual(loans[i].CarID, loancontainermock.Loans[i].CarID);

            }

        }
        [TestMethod]
        public void GetLoanbyUser()
        {
            //Arrange
            LoanMock loanmock = new LoanMock();

            LoanBLL loan = new LoanBLL(loanmock);
            int userid = 2;
            //Act
            var getloansbyuser = loan.GetLoanbyUser(userid);

            //Assert
            Assert.AreEqual(1, getloansbyuser.Count());

        }
       
        [TestMethod]
        public void BarrowdayBiggerThanReturnDate()
        {
            //Arrange
            LoanMock loanmock = new LoanMock();
            LoanBLL loan = new LoanBLL(loanmock);

            DateTime date7 = DateTime.Today.AddDays(30);
            DateTime date8 = DateTime.Today.AddDays(5);
            Loan loan3 = new Loan()
            {
                LoanDate = date7,
                ReturnDate = date8,
                CarID = 2,
                UserID = 3,

            };
            //Act
            var barrowdaybiggerthanreturn = loan.CheckAvailibilityofCar(loan3);

            //Assert
            Assert.IsFalse(barrowdaybiggerthanreturn);
        }








    }
}
