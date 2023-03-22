using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Car
    {
        [Key]
        public int CarID { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Transmission { get; set; }
        public string Body { get; set; }
        public bool Visibility { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Review>Reviews { get; set; }


        







    }
}
