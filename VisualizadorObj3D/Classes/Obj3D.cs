using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ProcessamentoImagens.classes
{
    internal class Obj3D
    {
        private List<PointReal> VerticesOriginais { get; set; }
        private List<PointReal> VerticesNormais { get; set; }
        private List<PointReal> VerticesTextura { get; set; } //tratar depois
        private List<PointReal> VerticesAtuais { get; set; } //tratar depois
        private List<Face> Faces { get; set; }
        private double[,] MatrizAcumulada { get; set; } //tratar depois


        private Bitmap bitmap;

        public Obj3D()
        {
            VerticesOriginais = new List<PointReal>();
            VerticesNormais = new List<PointReal>();
            VerticesTextura = new List<PointReal>();
            VerticesAtuais = new List<PointReal>();
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
                    string trimmedLine = line.Trim(); // Remove espaços/caracteres extras
                    string[] valores = trimmedLine.Split(
                        new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    if (trimmedLine.StartsWith("v ")) // Vértice de posição
                    {
                        Console.WriteLine(trimmedLine);
                        string x = valores[1].Replace(".", ",");
                        string y = valores[2].Replace(".", ",");
                        string z = valores[3].Replace(".", ",");

                        PointReal vertice = new PointReal(double.Parse(valores[1], CultureInfo.InvariantCulture), double.Parse(valores[2], CultureInfo.InvariantCulture), double.Parse(valores[3], CultureInfo.InvariantCulture));
                        VerticesOriginais.Add(vertice);
                    }
                    else if (trimmedLine.StartsWith("vn ")) // Vértice normal
                    {
                        Console.WriteLine(trimmedLine);
                        
                        string x = valores[1].Replace(".", ",");
                        string y = valores[2].Replace(".", ",");
                        string z = valores[3].Replace(".", ",");

                        PointReal vertice = new PointReal(double.Parse(valores[1], CultureInfo.InvariantCulture), double.Parse(valores[2], CultureInfo.InvariantCulture), double.Parse(valores[3], CultureInfo.InvariantCulture));
                        VerticesNormais.Add(vertice);
                    }
                    else if (trimmedLine.StartsWith("vt ")) // Vértice de textura
                    {
                        Console.WriteLine(trimmedLine);
                        string x = valores[1].Replace(".", ",");
                        string y = valores[2].Replace(".", ",");

                        PointReal vertice = new PointReal(double.Parse(valores[1], CultureInfo.InvariantCulture), double.Parse(valores[2], CultureInfo.InvariantCulture), 0);
                        VerticesTextura.Add(vertice);
                    }
                    else if (trimmedLine.StartsWith("f ")) // Face
                    {
                        int qtdeVertices = valores.Length - 1;
                        Face face = new Face();
                        for (int i = 1; i <= qtdeVertices; i++)
                        {
                            string[] indices = valores[i].Split('/');
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
                    // Qualquer outra linha (o, g, s, usemtl, mtllib, TITLE, #...) é ignorada automaticamente
                }

                // Exibir os valores recuperados do arquivo
                foreach (PointReal v in VerticesOriginais)
                    Console.WriteLine($"X: {v.X}, Y: {v.Y}, Z: {v.Z}");
                foreach (PointReal v in VerticesNormais)
                    Console.WriteLine($"X: {v.X}, Y: {v.Y}, Z: {v.Z}");

                foreach (Face f in Faces)
                {
                    Console.WriteLine("Face:");
                    for (int i = 0; i < f.IndicesVertices.Count; i++)
                    {
                        if (f.IndicesVerticesTextura.Count > 0)
                            Console.WriteLine($"Vértice: {f.IndicesVertices[i]}, Textura: {f.IndicesVerticesTextura[i]}, Normal: {f.IndicesVerticesNormais[i]}");
                        else
                            Console.WriteLine($"Vértice: {f.IndicesVertices[i]}, Normal: {f.IndicesVerticesNormais[i]}");
                    }
                }
            }
        }


        //desenhar o objeto com base nos vértices e faces recuperados do arquivo .obj
        public PointReal Projetar(PointReal p, int largura, int altura)
        {
            double x = (int)(p.X) + largura / 2;
            double y = (int)(-p.Y) + altura / 2;

            return new PointReal(x, y, 0);
        }

        private void AtualizarVerticesAtuais(int largura, int altura)
        {
            VerticesAtuais.Clear();
            foreach (PointReal vertice in VerticesOriginais)
            {
                PointReal verticeTransformado = AplicarMatriz(vertice);
                PointReal verticeProjetado = Projetar(verticeTransformado, largura, altura);
                VerticesAtuais.Add(verticeProjetado);
            }
        }

        // Esse desenhar plota na tela as faces do objeto 3D carregado atualmente
        public Bitmap Desenhar(int largura, int altura, double escala = 1)
        {
            AtualizarVerticesAtuais(largura, altura);//passa tamanho real imagem

            // Recria só se o tamanho mudou
            if (bitmap == null || bitmap.Width != largura || bitmap.Height != altura)
                bitmap = new Bitmap(largura, altura, PixelFormat.Format24bppRgb);
            else
            {
                // Limpa o bitmap reaproveitado
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Black);
                }
                //ou
                /*
                    using var g = Graphics.FromImage(bitmap);
                    g.Clear(Color.Black);
                 */
            }

            BitmapData img = bitmap.LockBits(
                new Rectangle(0, 0, largura, altura),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            try
            {
                unsafe
                {
                    byte* origem = (byte*)img.Scan0.ToPointer();

                    foreach (Face face in Faces)
                    {
                        for (int i = 0; i < face.IndicesVertices.Count; i++)
                        {
                            int atualIndex = face.IndicesVertices[i] - 1;

                            int proximoIndex;

                            if (i == face.IndicesVertices.Count - 1)
                                proximoIndex = face.IndicesVertices[0] - 1;
                            else
                                proximoIndex = face.IndicesVertices[i + 1] - 1;

                            if (atualIndex >= 0 && atualIndex < VerticesAtuais.Count &&
                                proximoIndex >= 0 && proximoIndex < VerticesAtuais.Count)
                            {
                                PointReal p1 = VerticesAtuais[atualIndex];
                                PointReal p2 = VerticesAtuais[proximoIndex];

                                Bresenham(
                                    origem,
                                    img.Stride,
                                    largura,
                                    altura,
                                    p1.X,
                                    p1.Y,
                                    p2.X,
                                    p2.Y,
                                    255, 255, 255
                                );
                            }
                        }
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(img);
            }
            return bitmap;
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


        public void GerarMatrizIdentidade()
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
            if (eixo== 'x')
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
        unsafe public static void Bresenham(byte* origem, int stride, int width, int height,
                            double x1double, double y1double, double x2double, double y2double, int R, int G, int B)
        {

            // Converte para int só aqui, mantendo precisão até a última hora
            int x1 = (int)Math.Round(x1double);
            int y1 = (int)Math.Round(y1double);
            int x2 = (int)Math.Round(x2double);
            int y2 = (int)Math.Round(y2double);

            int pixelSize = 3;

            // Verifica se a reta é muito inclinada
            // Se |dy| > |dx| significa que ela é mais vertical que horizontal
            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            // Se for muito inclinada, trocamos x por y, faz o algoritmo funcionar para todos os octantes
            if (steep)
            {
                int aux;

                aux = x1; x1 = y1; y1 = aux;

                aux = x2; x2 = y2; y2 = aux;
            }
            //desenho será sempre da esquerda para direita
            if (x1 > x2)
            {
                int aux;

                aux = x1; x1 = x2; x2 = aux;

                aux = y1; y1 = y2; y2 = aux;
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
                    byte* pixel = origem + py * stride + px * pixelSize;

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
        public List<PointReal> GetVerticesAtuais()
        {
            return VerticesAtuais;
        }
        public List<Face> GetFaces()
        {
            return Faces;
        }
    }
    
}
