using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.Classes
{
    internal class PointInteiro
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public PointInteiro()
        {
            X = Y = Z = -1;
        }

        public PointInteiro(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
