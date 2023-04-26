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
    public class UserTest
    {

        [TestMethod]

        public void AddUserAccount()
        {
            //Arrange

            UserMock userMock = new UserMock();

            UserBLL userbll = new(userMock);
            User user = new User()
            {


                UserID = 3,
                Email = "admin@gmail.com",
                Name = "admin",
                Password = "1234567800",
                Role = true,
                Surname = "administrator"

            };


            //Act

            userbll.CreateAccount(user);
            var result = userMock.users.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(user.UserID, userMock.users.Last().UserID);
            Assert.AreEqual(user.Email, userMock.users.Last().Email);
            Assert.AreEqual(user.Name, userMock.users.Last().Name);
            Assert.AreEqual(user.Password, userMock.users.Last().Password);
            Assert.AreEqual(user.Surname, userMock.users.Last().Surname);



        }
        public void GetUsers()
        {
            //Arrange

            UserMock userMock = new UserMock();

            UserBLL userbll = new(userMock);



            //Act

            var users = userbll.GetAllUsers();

            //Assert
            Assert.AreEqual(userMock.users.Count, users.Count); ;

            for (int i = 0; i < users.Count; i++)
            {
                Assert.AreEqual(users[i].UserID, userMock.users[i].UserID);
                Assert.AreEqual(users[i].Name, userMock.users[i].Name);
                Assert.AreEqual(users[i].Email, userMock.users[i].Email);
                Assert.AreEqual(users[i].Role, userMock.users[i].Role);

            }




        }
        [TestMethod]
        public void GetUserType()
        {

            //Arrange
            UserMock userMock = new UserMock();

            UserBLL userbll = new(userMock);


            //Act
            var result = userbll.GetuserTypeByEmail("Tim@gmail.com");
            var result2 = userbll.GetuserTypeByEmail("cuneyt@gmail.com");




            //Assert
            Assert.AreEqual(result, userMock.users[1].Role);
            Assert.IsFalse(result);
         
        }

        [TestMethod]
        public void Getusersbyemail()
        {
            //Arrange

            UserMock userMock = new UserMock();

            UserBLL userbll = new(userMock);



            //Act
            var result = userbll.GetuserIdByEmail("cterk2001@gmail.com");
            var result2 = userbll.GetuserIdByEmail("babur0575@gmail.com");



            //Assert
            Assert.AreEqual(result2, userMock.users[1].UserID);
            Assert.AreEqual(result, userMock.users[0].UserID);
        }
        [TestMethod]
        public void GetuserNamebyemail()
        {
            //Arrange

            UserMock userMock = new UserMock();

            UserBLL userbll = new(userMock);



            //Act
            var result = userbll.GetUserNameByEmail("cterk2001@gmail.com");
            var result2 = userbll.GetUserNameByEmail("babur0575@gmail.com");



            //Assert
            Assert.AreEqual(result2, userMock.users[1].Name);
            Assert.AreEqual(result, userMock.users[0].Name);
        }
        //[TestMethod]
        //public void Check_User_Information()
        //{
        //    //Arrange

        //    UserMock userMock = new UserMock();
        //    UserBLL userbll = new(userMock);

        //    User user = new User()
        //    {
        //        Email = "Tim@gmail.com",
        //        Password = "1234567890"
        //    };


        //    //Act
        //    var result = userbll.CheckUserInformation(user.Email, user.Password);


        //    // Assert
        //    Assert.IsTrue(result);
        //    Assert.AreEqual(user.Email, userMock.users[1].Email);
        //    Assert.AreEqual(user.Password, userMock.users[1].Password);


        //}

        [TestMethod]
        public void GetAllUsers()
        {
            //Arrange

            UserMock userMock = new UserMock();

            UserBLL userbll = new(userMock);



            //Act

            var users = userbll.GetAllUsers();

            //Assert
            Assert.AreEqual(userMock.users.Count, users.Count); ;
            for (int i = 0; i < users.Count; i++)
            {
                Assert.AreEqual(users[i].UserID, userMock.users[i].UserID);
                Assert.AreEqual(users[i].Name, userMock.users[i].Name);
                Assert.AreEqual(users[i].Email, userMock.users[i].Email);
                Assert.AreEqual(users[i].Role, userMock.users[i].Role);

            }



        }
    }
}

