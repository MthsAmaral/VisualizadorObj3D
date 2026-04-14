using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ProcessamentoImagens.classes
{
    internal class Obj3D
    {
        private List<PointReal> VerticesOriginais { get; set; }
        private List<PointReal> VerticesNormais { get; set; }
        private List<Point> VerticesAtuais { get; set; } //tratar depois
        private List<Poligono> Faces { get; set; } //tratar depois
        private double[,] MatrizAcumulada { get; set; } //tratar depois

        public Obj3D()
        {
            VerticesOriginais = new List<PointReal>();
            VerticesNormais = new List<PointReal>();
            VerticesAtuais = new List<Point>();
            Faces = new List<Poligono>();
            MatrizAcumulada = new double[4, 4];

            GerarMatrizIdentidade(); // para a matriz acumulada 4x4
        }
        public Obj3D(string filePath) : this()
        {
            CarregarObj(filePath);
        }

        private void GerarMatrizIdentidade()
        {
            /*  1 0 0 0 
                0 1 0 0 
                0 0 1 0 
                0 0 0 1  */
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i == j)
                        MatrizAcumulada[i, j] = 1;
                    else
                        MatrizAcumulada[i, j] = 0; 
        }

        public void CarregarObj(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.StartsWith("v")) // Vértice
                    {
                        string[] valores = line.Split(' ');
                        // Vértice
                        if (line.StartsWith("v "))
                        {
                            PointReal vertice = new PointReal(Double.Parse(valores[1]) , Double.Parse(valores[2]), Double.Parse(valores[3]));
                            VerticesOriginais.Add(vertice);
                        }
                        else if(line.StartsWith("vn "))
                        {
                            PointReal vertice = new PointReal(Double.Parse(valores[1]), Double.Parse(valores[2]), Double.Parse(valores[3]));
                            VerticesNormais.Add(vertice);
                        }
                    }
                    else if (line.StartsWith("f ")) // Face
                    {
                        // Processar face
                    }
                }
                foreach(PointReal v in VerticesOriginais)
                    Console.WriteLine(v);
                foreach(PointReal v in VerticesNormais)
                    Console.WriteLine(v);
            }
        }
    }
}
