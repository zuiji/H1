using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometry
{
    public class Square
    {
        
        //this is my prop
        private double Sides { get; set; }

        //ths is an ementy constructor
        public Square() { }

        //This is my Constructor who sets the sides.
        public Square(double sides)
        {
            this.Sides = sides;
        }

        //This method do calculate the Area 
        public double Area()
        {
            return Sides * Sides;
        }

        //This method do calculate the Circumference
        public double Circumference()
        {
            return Sides * 4;
        }
    }
}
