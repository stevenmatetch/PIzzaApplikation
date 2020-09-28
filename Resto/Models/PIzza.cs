using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Models
{
  public  class Pizza
    {
        
        private double _pris;
        private string _namn;
        private string _ingredienser;
        private string _bild;
        private int _id;

        public Pizza(string namn, int id, string ingredienser, double pris, string bild)
        {

            Namn = namn;
            Ingredienser = ingredienser;
            Pris = pris;
            Id = id;
            Bild = bild;
        }
        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }

        }
        public string Namn
        {
            get { return _namn; }
            set { _namn = value; }
        }

        public string Ingredienser
        {
            get { return _ingredienser; }
            set { _ingredienser = value; }

        }

        public string Bild
        {
            get { return _bild; }
            set { _bild = value; }

        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }
        public string summary
        {
            get { return _pris + "kr"; }
        }
        public bool ShouldSerializeId() { return false; }
       
        
    }
}

