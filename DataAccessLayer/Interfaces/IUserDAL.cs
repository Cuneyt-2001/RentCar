using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {
        int CreateAccount(User user);
        User CheckUserInformation(User user);
        int GetuserIdByEmail(string email);
        bool GetuserTypeByEmail(string email);
        string GetUserNameByEmail(string email);
        List<User> GetAllUsers();   
    }
}
