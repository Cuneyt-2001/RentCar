using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class Review
    {
        public Review()
        {
            //user = new User();
            //car = new Car();
        }

        [Key]
        public int ReviewID { get; set; }
        public string Reviewcontent { get; set; }
        public int? UserID { get; set; }
        public int? CarID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Car? car { get; set; } 
        [JsonIgnore]
        [IgnoreDataMember]
        public User? user { get; set; } 

    }
}
