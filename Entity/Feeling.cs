using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Feeling
    {
        public int FeelingID { get; set; }
        public string Feel { get; set; }
        public List<Review> Allreviews{get;set;}
    }
}
