using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Models
{
  public  class Order
    {
        public int _id;

        public DateTime _date;

        public bool ShouldSerializeId() { return false; }
   

        public Order(DateTime date)
        {
            Date = date;    
     
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value; ;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value; 
            }
        }
    }
}
