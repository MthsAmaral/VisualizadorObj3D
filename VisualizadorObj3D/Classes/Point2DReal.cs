using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizadorObj3D.Classes
{
    internal class Point2DReal
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public Point2DReal()
        {
            X = Y = -1;
        }

        public Point2DReal(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
