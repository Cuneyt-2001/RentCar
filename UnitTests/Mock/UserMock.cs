using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mock
{
    public class UserMock : IUserDAL
    {
        public List<User> users = new List<User>();

        public UserMock()
        {
            User user1 = new User()
            {
                UserID = 1,
                Name ="Cuneyt",
                Surname ="Terkesli",
                Email ="cterk2001@gmail.com",
                Password="12345678",
                



            };

            User user2 = new User()
            {
                UserID = 2,
                Name = "John",
                Surname = "crud",
                Email = "babur0575@gmail.com",
                Password = "87654321",

            };
            users.Add(user1);
            users.Add(user2);
        }

        public bool CheckUserInformation(string email, string password)
        {
            var result = users.Where(x => x.Email == email && x.Password == password);
            if(result.Count() > 0)
            {
                return true;
            }
            return false;   
        }

        public int CreateAccount(User user)
        {
            users.Add(user);
            return users.Count;
        }

        public List<User> GetAllUsers()
        {
          return users; 
        }

        public int GetuserIdByEmail(string email)
        {
            var result = users.Where(x => x.Email == email).Select(x => x.UserID).SingleOrDefault();
            return result;
        }

        public string GetUserNameByEmail(string email)
        {
            var result = users.Where(x => x.Email == email).Select(x => x.Name).SingleOrDefault();
            return result;
        }

        public bool GetuserTypeByEmail(string email)
        {
            var result = users.Where(x => x.Email == email).Select(x => x.Role).SingleOrDefault();
            return result;
        }
    }
}
