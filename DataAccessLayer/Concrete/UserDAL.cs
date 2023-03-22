using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UserDAL : IUserDAL
    {
        public bool CheckUserInformation(string email, string password)
        {
            using var context_ = new Context();
            var result = context_.Users.Where(x => x.Email == email && x.Password == password);
            if (result.Any())
            {
                return true;
            }
            return false;
        }

        public int CreateAccount(User user)
        {
            using var context_ = new Context();
            context_.Add(user);
            return context_.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            using var context_ = new Context();
            return context_.Users.ToList();
        }

        public int GetuserIdByEmail(string email)
        {
            using var context_ = new Context();
            var result = context_.Users.Where(x => x.Email == email).Select(x => x.UserID).SingleOrDefault();
            return result;

        }

        public string GetUserNameByEmail(string email)
        {
            using var context_ = new Context();
            var result = context_.Users.Where(x => x.Email == email).Select(x => x.Name).SingleOrDefault();
            return result;
        }

        public bool GetuserTypeByEmail(string email)
        {
            using var context_ = new Context();
            var result = context_.Users.Where(x => x.Email == email).Select(x => x.Role).SingleOrDefault();
            return result;
        }
    }
}
