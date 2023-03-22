using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CarID { get; set; }
        public int UserID { get; set; }
        public Car car { get; set; }
        public User user { get; set; }
    }
}
