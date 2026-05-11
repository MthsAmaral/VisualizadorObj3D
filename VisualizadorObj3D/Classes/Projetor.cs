using ProcessamentoImagens.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizadorObj3D.Classes
{
    internal class Projetor
    {
        private List<Point2DReal> VerticesAtuais2D { get; set; }
       
        public Projetor()
        {

        }
        private void Projetar2D()
        {
            Point2DReal ini, fim;
            for(int i=0; i<VerticesAtuais2D.Count-1; i++)
            {
                ini = VerticesAtuais2D[i];
                fim = VerticesAtuais2D[i + 1];
                //Bresenham(origem, img.Stride, largura, altura, p1.X, p1.Y, p2.X, p2.Y, 255, 255, 255);
            }
            ini = VerticesAtuais2D[VerticesAtuais2D.Count - 1];
            fim = VerticesAtuais2D[0];

            ini = VerticesAtuais2D[i];
            fim = VerticesAtuais2D[i + 1];
            //Bresenham(origem, img.Stride, largura, altura, p1.X, p1.Y, p2.X, p2.Y, 255, 255, 255);
        }
        public void ProjecaoOrtografica(List<PointReal> verticesAtuais, char c)
        {
            for (int i = 0; i < verticesAtuais.Count; i++)
            {
                PointReal pontoReal = verticesAtuais[i];
                Point2DReal ponto = new Point2DReal();
                
                if (c == 'l') // mantem y e z
                {
                    ponto.X = pontoReal.Y;
                    ponto.Y = pontoReal.Z;
                }
                else
                if (c == 'f') // mantem x e y
                {
                    ponto.X = pontoReal.X;
                    ponto.Y = pontoReal.Y;
                }
                else
                if (c == 's') // mantem x e z
                {
                    ponto.X = pontoReal.X;
                    ponto.Y = pontoReal.Z;
                }
                
                VerticesAtuais2D.Add(ponto);
            }
        }
    }
}
