using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Models
{
   public class PizzaMenu
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Ingredienser { get; set; }
        public int Pris { get; set; }
        public string Bild { get; set; }
    }
}
