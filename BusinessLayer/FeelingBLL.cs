using DataAccessLayer.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FeelingBLL
    {
        private IFeelingDAL _ifeelingdal;

        public FeelingBLL(IFeelingDAL ifeelingdal)
        {
            _ifeelingdal = ifeelingdal;
        }

        public List<Feeling> GetFeelings()
        {
         return  _ifeelingdal.GetAll();
        }
    }
}
