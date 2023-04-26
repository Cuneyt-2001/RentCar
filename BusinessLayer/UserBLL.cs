using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBLL
    {
        private IUserDAL _IUserDAL;

        public UserBLL(IUserDAL iUserDAL)
        {
            _IUserDAL = iUserDAL;
        }
        public int CreateAccount(User user)
        {
            return _IUserDAL.CreateAccount(user);
        }
        public User CheckUserInformation(User user)
        {
            if (user.Email == null || user.Password == null)
            {
                return null;
            }
            return _IUserDAL.CheckUserInformation(user);
        }

        public int GetuserIdByEmail(string email)
        {
            return _IUserDAL.GetuserIdByEmail(email);
        }
        public bool GetuserTypeByEmail(string email)
        {
            return _IUserDAL.GetuserTypeByEmail(email);
        }
        public string GetUserNameByEmail(string email)
        {
            return _IUserDAL.GetUserNameByEmail(email);
        }
        public List<User> GetAllUsers()
        {
            return _IUserDAL.GetAllUsers();
        }
    }
}
