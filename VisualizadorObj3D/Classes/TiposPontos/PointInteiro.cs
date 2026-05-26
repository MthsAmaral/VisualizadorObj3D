using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.Classes
{
    public class PointInteiro
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int DX { get; set; }
        public int DY { get; set; }
        public int DZ { get; set; }
        public PointInteiro()
        {
            X = Y = Z = R = G = B = -1;
        }
        public PointInteiro(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public PointInteiro(int x, int y, int z, int r, int g, int b)
        {
            X = x;
            Y = y;
            Z = z;
            R = r;
            G = g;
            B = b;
        }
    }
}
