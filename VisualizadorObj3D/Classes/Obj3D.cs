using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ProcessamentoImagens.classes
{
    internal class Obj3D
    {
        private List<PointReal> VerticesOriginais { get; set; }
        private List<PointReal> VerticesNormais { get; set; }
        private List<PointReal> VerticesTextura { get; set; } //tratar depois
        private List<Point> VerticesAtuais { get; set; } //tratar depois
        private List<Face> Faces { get; set; } //tratar depois
        private double[,] MatrizAcumulada { get; set; } //tratar depois

        public Obj3D()
        {
            VerticesOriginais = new List<PointReal>();
            VerticesNormais = new List<PointReal>();
            VerticesAtuais = new List<Point>();
            Faces = new List<Face>();
            MatrizAcumulada = new double[4, 4];

            GerarMatrizIdentidade(); // para a matriz acumulada 4x4
        }

        public Obj3D(string filePath) : this()
        {
            CarregarObj(filePath);
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
                        string x = valores[1].Replace(".", ",");
                        string y = valores[2].Replace(".", ",");
                        string z = valores[3].Replace(".", ",");
                        // Vértice
                        if (line.StartsWith("v ")) //vértices
                        {
                            PointReal vertice = new PointReal(Double.Parse(x), Double.Parse(y), Double.Parse(z));
                            VerticesOriginais.Add(vertice);
                        }
                        else if (line.StartsWith("vn ")) //vértices normais
                        {
                            PointReal vertice = new PointReal(Double.Parse(x), Double.Parse(y), Double.Parse(z));
                            VerticesNormais.Add(vertice);
                        }
                        else if (line.StartsWith("vt ")) //vértices de textura
                        {
                            PointReal vertice = new PointReal(Double.Parse(x), Double.Parse(y), Double.Parse(z));
                            VerticesTextura.Add(vertice);
                        }
                    }
                    else if (line.StartsWith("f ")) // Face
                    {
                        // Processar face
                        string[] valores = line.Split(' ');
                        int qtdeVertices = valores.Length - 1; //pois o primeiro é o "f"
                        Face face = new Face();
                        for (int i = 1; i <= qtdeVertices; i++)
                        {
                            string[] indices = valores[i].Split('/'); //v/vt/vn --> 0: vértice, 1:textura, 2:normal
                            indices = LimparStringVazia(indices);
                            if (indices.Length == 3)
                            {
                                face.IndicesVertices.Add(int.Parse(indices[0]));
                                face.IndicesVerticesTextura.Add(int.Parse(indices[1]));
                                face.IndicesVerticesNormais.Add(int.Parse(indices[2]));
                            }
                            else if (indices.Length == 2)
                            {
                                face.IndicesVertices.Add(int.Parse(indices[0]));
                                face.IndicesVerticesNormais.Add(int.Parse(indices[1]));
                            }
                            Faces.Add(face);
                        }
                    }
                }

                // exibir os valores recuperados do arquivo
                foreach (PointReal v in VerticesOriginais)
                    Console.WriteLine($"X: {v.X}, Y: {v.Y}, Z: {v.Z}");
                foreach (PointReal v in VerticesNormais)
                    Console.WriteLine($"X: {v.X}, Y: {v.Y}, Z: {v.Z}");

                foreach (Face f in Faces)
                {
                    Console.WriteLine("Face:");
                    for (int i = 0; i < f.IndicesVertices.Count; i++)
                    {
                        Console.WriteLine($"Vértice: {f.IndicesVertices[i]}, Textura: {f.IndicesVerticesTextura[i]}, Normal: {f.IndicesVerticesNormais[i]}");
                    }
                }
            }
        }

        public string[] LimparStringVazia(string[] array)
        {
            return array
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();
        }

        // ==========================================================================================
        // OPERAÇÕES COM MATRIZES
        // ==========================================================================================
        private void GerarMatrizIdentidade()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i == j)
                        MatrizAcumulada[i, j] = 1;
                    else
                        MatrizAcumulada[i, j] = 0;
        }

        public void SetMatrizXY(int x, int y, double valor)
        {
            if (x > -1 && x < 4 && y > -1 && y < 4)
                MatrizAcumulada[x, y] = valor;
        }

        private void MultiplicaMatrizAcumulada(double[,] matriz, double[,] resultado)
        {
            for (int l = 0; l < 4; l++)
            {
                for (int c = 0; c < 4; c++)
                {
                    double valor = 0;
                    for (int i = 0; i < 4; i++)
                        valor += MatrizAcumulada[l, i] * matriz[i, c];

                    //setar na matriz de resultado
                    resultado[l, c] = valor;
                }
            }
        }

        private void SetarTodaMatrizAcumulada(double[,] resultado)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    SetMatrizXY(i, j, resultado[i, j]);
        }

        //multiplicação de matrizes para acumular as transformações
        public void MultiplicaMatrizTranslacao(double dx, double dy, double dz)
        {
            double[,] matrizTranslacao = new double[4, 4] {
                { 1, 0, 0, dx },
                { 0, 1, 0, dy },
                { 0, 0, 1, dz },
                { 0, 0, 0, 1 }
            };
            double[,] resultado = new double[4, 4];

            MultiplicaMatrizAcumulada(matrizTranslacao, resultado);
            SetarTodaMatrizAcumulada(resultado);
        }

        public void MultiplicaMatrizEscala(double escalaX, double escalaY, double escalaZ)
        {
            double[,] matrizEscala = new double[4, 4] {
                { escalaX, 0, 0, 0 },
                { 0, escalaY, 0, 0 },
                { 0, 0, escalaZ, 0 },
                { 0, 0, 0, 1}
            };
            double[,] resultado = new double[4, 4];

            MultiplicaMatrizAcumulada(matrizEscala, resultado);
            SetarTodaMatrizAcumulada(resultado);
        }

        public void MultiplicaMatrizRotacao(int grau, char eixo)
        {
            double cosseno = Math.Cos(grau * Math.PI / 180); //quando passado em radianos, funciona normalmente
            double seno = Math.Sin(grau * Math.PI / 180);    //quando passado em radianos, funciona normalmente
            double[,] resultado = new double[4, 4];
            double[,] matrizRotacao = new double[4, 4];
            if (grau == 'x')
            {
                matrizRotacao = new double[4, 4] {
                    { 1, 0, 0, 0 },
                    { 0, cosseno, -seno, 0 },
                    { 0, seno, cosseno, 0 },
                    { 0, 0, 0, 1 }
                };
            }
            else if (grau == 'y')
            {
                matrizRotacao = new double[4, 4] {
                    { cosseno, 0, seno, 0 },
                    { 0, 1, 0, 0 },
                    { -seno, 0, cosseno, 0 },
                    { 0, 0, 0, 1 }
                };
            }
            else
            {
                matrizRotacao = new double[4, 4] {
                    { cosseno, -seno, 0, 0 },
                    { seno, cosseno, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
            }

            //Aplicar a transformação em questão -> rotação
            MultiplicaMatrizAcumulada(matrizRotacao, resultado);
            SetarTodaMatrizAcumulada(resultado);
        }
    }
}
