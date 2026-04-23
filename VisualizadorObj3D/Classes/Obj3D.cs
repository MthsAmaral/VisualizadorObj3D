using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
                        }
                        Faces.Add(face);
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
                        if(f.IndicesVerticesTextura.Count > 0)
                            Console.WriteLine($"Vértice: {f.IndicesVertices[i]}, Textura: {f.IndicesVerticesTextura[i]}, Normal: {f.IndicesVerticesNormais[i]}");
                        else
                            Console.WriteLine($"Vértice: {f.IndicesVertices[i]}, Normal: {f.IndicesVerticesNormais[i]}");
                    }
                }
            }
        }




        //desenhar o objeto com base nos vértices e faces recuperados do arquivo .obj
        public Point Projetar(PointReal p, int largura, int altura)
        {
            int escala = 1; // pode ajustar depois

            int x = (int)(p.X * escala) + largura / 2;
            int y = (int)(-p.Y * escala) + altura / 2;

            return new Point(x, y);
        }
        public Bitmap Desenhar(int largura, int altura)
        {
            Bitmap bmp = new Bitmap(largura, altura);

            foreach (Face face in Faces)
            {
                //exemplo:
                //f 1 2 3
                // .obj começa em 1 mas a lista começa em 0
                for (int i = 0; i < face.IndicesVertices.Count; i++)
                {
                    int atualIndex = face.IndicesVertices[i] - 1;

                    int proximoIndex;
                    if (i == face.IndicesVertices.Count - 1)
                        proximoIndex = face.IndicesVertices[0] - 1; // volta pro início
                    else
                        proximoIndex = face.IndicesVertices[i + 1] - 1;

                    PointReal v1 = AplicarMatriz(VerticesOriginais[atualIndex]);
                    PointReal v2 = AplicarMatriz(VerticesOriginais[proximoIndex]);

                    Point p1 = Projetar(v1, largura, altura);
                    Point p2 = Projetar(v2, largura, altura);

                    Bresenham(bmp, p1.X, p1.Y, p2.X, p2.Y, 255, 255, 255);
                }
            }

            return bmp;
        }



        //aplica matriz acumulada para transformar os vértices originais do objeto, retornando os vértices transformados
        public PointReal AplicarMatriz(PointReal p)
        {
            double x = p.X * MatrizAcumulada[0, 0] + p.Y * MatrizAcumulada[0, 1] + p.Z * MatrizAcumulada[0, 2] + MatrizAcumulada[0, 3];
            double y = p.X * MatrizAcumulada[1, 0] + p.Y * MatrizAcumulada[1, 1] + p.Z * MatrizAcumulada[1, 2] + MatrizAcumulada[1, 3];
            double z = p.X * MatrizAcumulada[2, 0] + p.Y * MatrizAcumulada[2, 1] + p.Z * MatrizAcumulada[2, 2] + MatrizAcumulada[2, 3];

            return new PointReal(x, y, z);
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


        //multiplicação de matrizes para acumular as transformações, só alterar a matriz acumulada
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




        //algoritmo de Bresenham para desenhar as linhas entre os vértices projetados
        public static void Bresenham(Bitmap imgBitmap, int x1, int y1, int x2, int y2, int R, int G, int B)
        {
            int width = imgBitmap.Width;
            int height = imgBitmap.Height;
            int pixelSize = 3;

            // Verifica se a reta é muito inclinada
            // Se |dy| > |dx| significa que ela é mais vertical que horizontal
            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            // Se for muito inclinada, trocamos x por y, faz o algoritmo funcionar para todos os octantes
            if (steep)
            {
                int aux;

                aux = x1;
                x1 = y1;
                y1 = aux;

                aux = x2;
                x2 = y2;
                y2 = aux;
            }
            //desenho será sempre da esquerda para direita
            if (x1 > x2)
            {
                int aux;

                aux = x1;
                x1 = x2;
                x2 = aux;

                aux = y1;
                y1 = y2;
                y2 = aux;
            }

            // Calcula as diferenças entre os pontos
            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1);

            // Define se a reta sobe ou desce
            // se y2 >= y1 → sobe (1) 
            // se y2 < y1 → desce (-1)
            int declive = (y1 < y2) ? 1 : -1;

            // Variável de decisão do Bresenham
            int erro = dx / 2;

            int y = y1;

            BitmapData img = imgBitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* origem = (byte*)img.Scan0.ToPointer();

                // Percorre todos os valores de x
                for (int x = x1; x <= x2; x++)
                {
                    int px, py;

                    // Se os eixos foram trocados anteriormente inverte novamente para desenhar o pixel correto
                    if (steep)
                    {
                        px = y;
                        py = x;
                    }
                    else
                    {
                        px = x;
                        py = y;
                    }

                    // Se o pixel está dentro da imagem
                    if (px >= 0 && px < width && py >= 0 && py < height)
                    {
                        byte* pixel = origem + py * img.Stride + px * pixelSize;

                        // Define o pixel com a cor recebida por parâmetro
                        pixel[0] = (byte)B;
                        pixel[1] = (byte)G;
                        pixel[2] = (byte)R;
                    }

                    // Atualiza o erro
                    erro -= dy;

                    if (erro < 0)
                    {
                        y += declive;
                        erro += dx;
                    }
                }
            }

            // Libera o acesso à memória da imagem
            imgBitmap.UnlockBits(img);
        }
    }
}
