using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class FeelingDAL:IFeelingDAL
    {
        public List<Feeling> GetAll()
        {
            using var context_ = new Context();
            return context_.Feeling.ToList();
        }
    }
}
