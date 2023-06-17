using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public User()
        {
            
            Loans = new List<Loan>();
            Reviews = new List<Review>();
         
        }

        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }
        public string Password { get; set; }
        public   List<Loan> Loans { get; set; } 
        public   List<Review> Reviews { get; set; } 
    }
}
