using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometry
{
    public class Square
    {
        private double Sides { get; set; }
        
        public Square() { }

        public Square(double sides)
        {
            this.Sides = sides;
        }
        public double Area()
        {
            double area = Sides * Sides;
            return area;
        }

        public double Circumference()
        {
            double circumference = Sides * 4;
            return circumference;

        }
    }
}
