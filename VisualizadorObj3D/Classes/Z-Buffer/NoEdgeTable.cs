using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.classes.EdgeTable
{
    internal class NoEdgeTable
    {
        public int yMax { get; set; } //abreviação para "y Máximo"
        public double xMin { get; set; } //abreviação para "x Mínimo"
        public double inc { get; set; } //abreviação para "incremento"

        public NoEdgeTable prox { get; set; } //abreviação para próximo

        public NoEdgeTable()
        {
            yMax = 0;
            xMin = 0;
            inc = 0;
            prox = null;
        }

        public NoEdgeTable(int yMaximo, double xMinimo, double incremento, NoEdgeTable no)
        {
            yMax = yMaximo;
            xMin = xMinimo;
            inc = incremento;
            prox = no;
        }

        public void CalcularIncremento(Reta r)
        {
            double dx = r.GetFimX() - r.GetIniX();
            double dy = r.GetFimY() - r.GetIniY();

            inc = dx / dy; // assume que dy != 0
        }

        public void Incrementar()
        {
            xMin += inc;
        }
    }
}
