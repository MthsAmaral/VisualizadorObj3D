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
        public double rMin { get; set; }
        public double gMin { get; set; }
        public double bMin { get; set; }
        public double rInc { get; set; }
        public double gInc { get; set; }
        public double bInc { get; set; }
        public double nxMin {  get; set; }
        public double nyMin { get; set; }
        public double nzMin { get; set; }
        public double nxInc { get; set; }
        public double nyInc { get; set; }
        public double nzInc { get; set; }
        public NoEdgeTable prox { get; set; } //abreviação para próximo

        public NoEdgeTable()
        {
            yMax = 0;
            xMin = 0;
            xInc = 0;
            zMin = 0;
            zInc = 0;
            rMin = 0;
            gMin = 0;
            bMin = 0;
            rInc = 0;
            gInc = 0;
            bInc = 0;
            nxMin = 0;
            nyMin = 0;
            nzMin = 0;
            nxInc = 0;
            nyInc = 0;
            nzInc = 0;
            prox = null;
        }

        public NoEdgeTable(int yMax, double xMin, double xInc, double zMin, double zInc, NoEdgeTable prox)
        {
            this.yMax = yMax;
            this.xMin = xMin;
            this.zMin = zMin;
            this.xInc = xInc;
            this.zInc = zInc;
            this.prox = prox;
        }
        public NoEdgeTable(int yMax, double xMin, double xInc, double zMin, double zInc, 
                           double rMin, double gMin, double bMin, 
                           double rInc, double gInc, double bInc, NoEdgeTable prox)
        {
            this.yMax = yMax;
            this.xMin = xMin;
            this.zMin = zMin;
            this.xInc = xInc;
            this.zInc = zInc;
            this.rMin = rMin;
            this.gMin = gMin;
            this.bMin = bMin;
            this.rInc = rInc;
            this.gInc = gInc;
            this.bInc = bInc;
            this.prox = prox;
        }
        public NoEdgeTable(int yMax, double xMin, double xInc, double zMin, double zInc,
                           double rMin, double gMin, double bMin,
                           double rInc, double gInc, double bInc, double nxMin, double nyMin, double nzMin,
                           double nxInc, double nyInc, double nzInc,NoEdgeTable prox)
        {
            this.yMax = yMax;
            this.xMin = xMin;
            this.zMin = zMin;
            this.xInc = xInc;
            this.zInc = zInc;
            this.rMin = rMin;
            this.gMin = gMin;
            this.bMin = bMin;
            this.rInc = rInc;
            this.gInc = gInc;
            this.bInc = bInc;
            this.nxMin = nxMin;
            this.nyMin = nyMin;
            this.nzMin = nzMin;
            this.nxInc = nxInc;
            this.nyInc = nyInc;
            this.nzInc = nzInc;
            this.prox = prox;
        }
        public void CalcularIncremento(Reta r)
        {
            double dx = r.GetFimX() - r.GetIniX();
            double dy = r.GetFimY() - r.GetIniY();
            double dz = r.GetFimZ() - r.GetIniZ();
            double dr = r.GetFimR() - r.GetIniR();
            double dg = r.GetFimG() - r.GetIniG();
            double db = r.GetFimB() - r.GetIniB();
            xInc = dx / dy; // assume que dy != 0
            zInc = dz / dy;
            rInc = dr / dy;
            gInc = dg / dy;
            bInc = db / dy;
        }

        public void Incrementar()
        {
            xMin += xInc;
            zMin += zInc;
            rMin += rInc;
            gMin += gInc;
            bMin += bInc;
            nxInc += nxInc;
            nyInc += nyInc;
            nzInc += nzInc;
        }
    }
}
