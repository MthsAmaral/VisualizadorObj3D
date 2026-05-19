using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.classes
{
    internal class NoEdgeTable
    {
        public int yMax { get; set; }
        public double xMin { get; set; }
        public double xInc { get; set; }
        public double zMin { get; set; }
        public double zInc { get; set; }
        public NoEdgeTable prox { get; set; } //abreviação para próximo

        public NoEdgeTable()
        {
            yMax = 0;
            xMin = 0;
            xInc = 0;
            zMin = 0;
            zInc = 0;
            prox = null;
        }

        public NoEdgeTable(int yMaximo, double xMinimo, double xIncremento, double zMinimo, double zIncremento, NoEdgeTable no)
        {
            yMax = yMaximo;
            xMin = xMinimo;
            zMin = zMinimo;
            xInc = xIncremento;
            zInc = zIncremento;
            prox = no;
        }

        public void CalcularIncremento(Reta r)
        {
            double dx = r.GetFimX() - r.GetIniX();
            double dy = r.GetFimY() - r.GetIniY();

            double dz = r.GetFimZ() - r.GetIniZ();
            xInc = dx / dy; // assume que dy != 0
            zInc = dz / dy;
        }

        public void Incrementar()
        {
            xMin += xInc;
            zMin += zInc;
        }
    }
}
