using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {/// <summary>
    /// Om account toe te voegen
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
        int CreateAccount(User user);
        /// <summary>
        /// Controleert de gberuiker gegevens voor het inloggen
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User CheckUserInformation(User user);
        /// <summary>
        /// Geeft gebruiker id op basis van email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        int GetuserIdByEmail(string email);
        /// <summary>
        /// geeft gebruikertyep op basis van zijn email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool GetuserTypeByEmail(string email);
        /// <summary>
        /// geeft gebruikernaam op basis van email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        string GetUserNameByEmail(string email);
        /// <summary>
        /// geeft de lijst van all gebruikers
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();   
    }
}
