using VisualizadorObj3D.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizadorObj3D.Classes
{
    internal static class OperacaoMatriz
    {

        public static double[,] GerarMatrizIdentidade()
        {
            return new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
        }

        
        public static PointReal AplicarMatriz(PointReal p, double[,]matriz)
        {
            double x = p.X * matriz[0, 0] + p.Y * matriz[0, 1] + p.Z * matriz[0, 2] + matriz[0, 3];
            double y = p.X * matriz[1, 0] + p.Y * matriz[1, 1] + p.Z * matriz[1, 2] + matriz[1, 3];
            double z = p.X * matriz[2, 0] + p.Y * matriz[2, 1] + p.Z * matriz[2, 2] + matriz[2, 3];

            return new PointReal(x, y, z);
        }


        public static double[,] Multiplicar(double[,] matA,  double[,] matB)
        {
            double[,] resultado = new double[4, 4];
            for (int l = 0; l < 4; l++)
            {
                for (int c = 0; c < 4; c++)
                {
                    double valor = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        valor += matA[l, i] * matB[i, c];
                    }
                    resultado[l, c] = valor;
                }
            }
            return resultado;
        }



        public static double[,] CriarTranslacao(double dx, double dy, double dz)
        {
            return new double[4, 4]
            {
                { 1, 0, 0, dx },
                { 0, 1, 0, dy },
                { 0, 0, 1, dz },
                { 0, 0, 0, 1 }
            };
        }

        public static double[,] CriarEscala(double sx, double sy, double sz)
        {
            return new double[4, 4]
            {
                { sx, 0, 0, 0 },
                { 0, sy, 0, 0 },
                { 0, 0, sz, 0 },
                { 0, 0, 0, 1 }
            };
        }

        public static double[,] CriarRotacao(int grau, char eixo)
        {
            double radiano = grau * Math.PI / 180; //conversão de graus para radianos
            double cosseno = Math.Cos(radiano); 
            double seno = Math.Sin(radiano);    
          
            double[,] matrizRotacao = new double[4, 4];
            if (eixo == 'x')
            {
                matrizRotacao = new double[4, 4] {
                    { 1, 0, 0, 0 },
                    { 0, cosseno, -seno, 0 },
                    { 0, seno, cosseno, 0 },
                    { 0, 0, 0, 1 }
                };
            }
            else if (eixo == 'y')
            {
                matrizRotacao = new double[4, 4] {
                    { cosseno, 0, seno, 0 },
                    { 0, 1, 0, 0 },
                    { -seno, 0, cosseno, 0 },
                    { 0, 0, 0, 1 }
                };
            }
            else if (eixo == 'z')
            {
                matrizRotacao = new double[4, 4] {
                    { cosseno, -seno, 0, 0 },
                    { seno, cosseno, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
            }

            return matrizRotacao;
        }



    }
}
