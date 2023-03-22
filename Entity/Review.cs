using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string Reviewcontent { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public Car car { get; set; }
        public User user { get; set; }

    }
}
