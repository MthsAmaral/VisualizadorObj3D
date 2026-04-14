using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace ProcessamentoImagens.classes
{
    internal class PointReal
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public PointReal()
        {
            X = Y = Z = -1;
        }

        public PointReal(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
