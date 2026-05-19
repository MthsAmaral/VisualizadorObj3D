using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using VisualizadorObj3D;
using VisualizadorObj3D.Classes;

namespace ProcessamentoImagens.classes
{
    internal class Obj3D
    {
        private List<PointReal> VerticesOriginais { get; set; }
        private List<PointReal> VerticesNormais { get; set; }
        private List<PointReal> VerticesTextura { get; set; } //tratar depois
        private List<PointReal> VerticesAtuais { get; set; } //tratar depois
        private List<PointReal> VerticesProjetados { get; set; }
        private List<Face> Faces { get; set; }
        private double[,] MatrizAcumulada { get; set; } //tratar depois
        private double[,] ZBuffer { get; set; }
        private Color[,] FrameBuffer { get; set; }

        public Bitmap bitmap { get; set; }

        public Obj3D()
        {
            VerticesOriginais = new List<PointReal>();
            VerticesNormais = new List<PointReal>();
            VerticesTextura = new List<PointReal>();
            VerticesAtuais = new List<PointReal>();
            VerticesProjetados = new List<PointReal>();
            Faces = new List<Face>();
            MatrizAcumulada = new double[4, 4];
            GerarMatrizIdentidade(); // para a matriz acumulada 4x4
        }

        public Obj3D(string filePath) : this()
        {
            //ZBuffer = new double[bitmap.Width, bitmap.Height];
            //FrameBuffer = new Color[bitmap.Width, bitmap.Height];
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



        //================== PROJEÇÕES =========================
        private void ProjetarVertices(char tipoProjecao)
        {
            /*
                'f' = ortográfica frontal
                'l' = ortográfica lateral
                's' = ortográfica superior

                'c' = oblíqua cavaleira
                'b' = oblíqua cabinet

                'p' = perspectiva 1 ponto
                ' ' = sem projeção
             */
            VerticesProjetados.Clear();

            //frontal superior ou lateral
            if (tipoProjecao == 'f' || tipoProjecao == 's' || tipoProjecao == 'l')
            {
                ProjecaoOrtografica(tipoProjecao);
            }
            else if (tipoProjecao == 'c' || tipoProjecao == 'b')
            {
                ProjecaoObliqua(tipoProjecao);
            }
            else if (tipoProjecao == 'p')
            {
                ProjecaoPerspectiva1Ponto(200);
            }
            else
            {
                foreach (PointReal p in VerticesAtuais)
                {
                    VerticesProjetados.Add(new PointReal(p.X, p.Y, p.Z));
                }
            }
        }


        private void ProjecaoOrtografica(char c)
        {
            VerticesProjetados.Clear();
            for (int i = 0; i < VerticesAtuais.Count; i++)
            {
                PointReal pontoReal = VerticesAtuais[i];
                PointReal ponto = new PointReal();

                if (c == 'l') // mantem y e z
                {
                    ponto.X = pontoReal.Z;
                    ponto.Y = pontoReal.Y;
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

                VerticesProjetados.Add(ponto);
            }

        }

        //projeção obliqua
        private void ProjecaoObliqua(char op)
        {
            double l, angulo;

            if (op == 'c')//cavaleira
            {
                l = 1.0;
                angulo = 45.0;
            }
            else //cabinet
            {
                l = 0.5;
                angulo = 63.4;
            }

            double anguloRadianos = angulo * Math.PI / 180.0;
            double cos = Math.Cos(anguloRadianos);
            double sin = Math.Sin(anguloRadianos);

            foreach (PointReal p in VerticesAtuais)
            {
                PointReal projetado = new PointReal();

                projetado.X = p.X + p.Z * l * cos;
                projetado.Y = p.Y + p.Z * l * sin;
                projetado.Z = 0;

                VerticesProjetados.Add(projetado);
            }
        }

        private void ProjecaoPerspectiva1Ponto(double d)
        {
            VerticesProjetados.Clear();

            foreach (PointReal p in VerticesAtuais)
            {
                PointReal projetado = new PointReal();

                // empurra o objeto para frente no eixo Z
                double zCamera = p.Z + 400;

                // evita divisão por zero ou valores muito pequenos
                if (zCamera < 1)
                {
                    zCamera = 1;
                }

                projetado.X = p.X * d / zCamera;
                projetado.Y = p.Y * d / zCamera;
                projetado.Z = 0;

                VerticesProjetados.Add(projetado);
            }
        }


        private bool FaceEhVisivel(Face face, char tipoProjecao)
        {
            if (face.IndicesVertices.Count < 3)
            {
                return false;
            }

            PointReal normal = CalcularNormalFace(face);

            int i = face.IndicesVertices[0] - 1;
            PointReal pontoFace = VerticesAtuais[i];

            PointReal oa = ObterVetorObservacao(pontoFace, tipoProjecao);

            double produtoEscalar = oa.X * normal.X +
                                    oa.Y * normal.Y +
                                    oa.Z * normal.Z;

            // Pelo material:
            // positivo = traseira (não visível)
            // negativo = frontal (visível)
            // zero = lateral (não visível)
            return produtoEscalar < 0;
        }

        private PointReal CalcularNormalFace(Face face)
        {
            if (face.IndicesVertices.Count < 3)
            {
                return new PointReal(0, 0, 0);
            }

            int i1 = face.IndicesVertices[0] - 1;
            int i2 = face.IndicesVertices[1] - 1;
            int i3 = face.IndicesVertices[2] - 1;

            PointReal p1 = VerticesAtuais[i1];
            PointReal p2 = VerticesAtuais[i2];
            PointReal p3 = VerticesAtuais[i3];

            PointReal vet1 = new PointReal(
                p2.X - p1.X,
                p2.Y - p1.Y,
                p2.Z - p1.Z
            );

            PointReal vet2 = new PointReal(
                p3.X - p1.X,
                p3.Y - p1.Y,
                p3.Z - p1.Z
            );

            PointReal normal = new PointReal(
                vet1.Y * vet2.Z - vet1.Z * vet2.Y,
                vet1.Z * vet2.X - vet1.X * vet2.Z,
                vet1.X * vet2.Y - vet1.Y * vet2.X
            );

            return normal;
        }

        private PointReal ObterVetorObservacao(PointReal pontoFace, char tipoProjecao)
        {
            switch (tipoProjecao)
            {
                case 'f': // ortográfica frontal no plano XY
                    return new PointReal(0, 0, -1);

                case 'l': // lateral
                    return new PointReal(-1, 0, 0);

                case 's': // superior
                    return new PointReal(0, -1, 0);

                case 'c': // cavaleira
                    {
                        double l = 1.0;
                        double alpha = 45.0 * Math.PI / 180.0;
                        return new PointReal(l * Math.Cos(alpha), l * Math.Sin(alpha), -1);
                    }

                case 'b': // cabinet
                    {
                        double l = 0.5;
                        double alpha = 45.0 * Math.PI / 180.0;
                        return new PointReal(l * Math.Cos(alpha), l * Math.Sin(alpha), -1);
                    }

                case 'p': // perspectiva: observador na origem
                    {
                        double distanciaCamera = 400.0;

                        PointReal pontoCamera = new PointReal(
                            pontoFace.X,
                            pontoFace.Y,
                            pontoFace.Z + distanciaCamera
                        );

                        return new PointReal(pontoCamera.X, pontoCamera.Y, pontoCamera.Z);
                    }

                default://frontal
                    return new PointReal(0, 0, -1);
            }
        }

        // ================== FIM PROJEÇÕES ==================




        //desenhar o objeto com base nos vértices e faces recuperados do arquivo .obj
        public PointReal ConverterParaTela(PointReal p, int largura, int altura)
        {
            double x = p.X + largura / 2;
            double y = -p.Y + altura / 2;

            return new PointReal(x, y, 0);
        }

        private void AtualizarVerticesAtuais(int largura, int altura)
        {
            VerticesAtuais.Clear();
            foreach (PointReal vertice in VerticesOriginais)
            {
                PointReal verticeTransformado = AplicarMatriz(vertice);
                //PointReal verticeProjetado = ConverterParaTela(verticeTransformado, largura, altura);
                VerticesAtuais.Add(verticeTransformado);
            }
        }

        // Esse desenhar plota na tela as faces do objeto 3D carregado atualmente
        public Bitmap Desenhar(int largura, int altura, double escala, bool ehProjecao, char tipoProjecao, bool eliminarFacesOcultas)
        {
            
            AtualizarVerticesAtuais(largura, altura);//passa tamanho real imagem

            if (ehProjecao)
                ProjetarVertices(tipoProjecao);

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
            }

            BitmapData img = bitmap.LockBits(new Rectangle(0, 0, largura, altura),
                ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);

            try
            {
                unsafe
                {
                    byte* origem = (byte*)img.Scan0.ToPointer();

                    foreach (Face face in Faces)
                    {
                        bool desenharFace = true;
                        if(eliminarFacesOcultas)
                        {
                            desenharFace = FaceEhVisivel(face, tipoProjecao);
                        }
                        if(desenharFace)
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
                                    PointReal p1;
                                    PointReal p2;
                                    if (!ehProjecao)
                                    {
                                        p1 = VerticesAtuais[atualIndex];
                                        p2 = VerticesAtuais[proximoIndex];
                                    }
                                    else
                                    {
                                        p1 = VerticesProjetados[atualIndex];
                                        p2 = VerticesProjetados[proximoIndex];
                                    }
                                    p1 = ConverterParaTela(p1, largura, altura);
                                    p2 = ConverterParaTela(p2, largura, altura);

                                    if (Math.Abs(p1.X) < 10000 && Math.Abs(p1.Y) < 10000 &&
                                            Math.Abs(p2.X) < 10000 && Math.Abs(p2.Y) < 10000)
                                    {
                                        Bresenham(origem, img.Stride, largura, altura, p1.X, p1.Y, p2.X, p2.Y,
                                        255, 255, 255);
                                    }

                                }
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

        // Z-Buffer
        public void PreencherObjeto3D(Color cor)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;

            unsafe
            {
                List<Face> facesVisiveis = GetFacesVisiveis(); //possível remoção
                for (int i = 0; i < facesVisiveis.Count; i++)
                {
                    PreencherFaceZBuffer(facesVisiveis[i], cor, data, width, height);
                }
            }

            bitmap.UnlockBits(data);
        }
        private List<Face> GetFacesVisiveis()
        {
            List<Face> visiveis = new List<Face>();

            foreach(Face f in Faces)
                if(FaceEhVisivel(f, Form1.c))
                    visiveis.Add(f);

            return visiveis;
        }
        private double GetYMax(Face face)
        {
            List<int> indicesVertices = face.IndicesVertices;
            double maior = 0;
            for (int i = 0; i < indicesVertices.Count;i++)
            {
                int indice = indicesVertices[i]-1;
                PointReal pointReal = VerticesAtuais[indice];
                if (pointReal.Y > maior)
                    maior = pointReal.Y;
            }
            return maior;
        }
        private double GetYMin(Face face)
        {
            List<int> indicesVertices = face.IndicesVertices;
            double menor = 9999;
            for (int i = 0; i < indicesVertices.Count; i++)
            {
                int indice = indicesVertices[i]-1;
                PointReal pointReal = VerticesAtuais[indice];
                if (pointReal.Y < menor)
                    menor = pointReal.Y;
            }
            return menor;
        }
        private unsafe void PreencherFaceZBuffer(Face face, Color cor, BitmapData data, int width, int height)
        {
            byte* src = (byte*)data.Scan0.ToPointer();
            int yMax = (int) GetYMax(face);
            EdgeTable[] et = new EdgeTable[yMax + 1]; //vetor de tamanho yMax, para integrar todas as linhas possíveis
            FormarEdgeTable(et, face);

            int yMin =  (int) GetYMin(face);
            int y = yMin;
            EdgeTable aet = new EdgeTable();
            while (!IsVectorEdgeEmpty(et, et.Length) || aet.Count() > 0)
            {
                //pegar todos os elementos da posição [y]
                if (y > -1 && y < et.Length && et[y] != null)
                {
                    NoEdgeTable atual = et[y].GetNoEdgeTableAt(0);

                    while (atual != null)
                    {
                        NoEdgeTable prox = atual.prox;

                        atual.prox = null;
                        aet.Add(atual);

                        atual = prox;
                    }

                    et[y] = null;
                }

                //ordenar a lista de available
                aet.Sort();

                //remover os elementos (nós) com yMax == y
                aet.RemoveAllYMax(y);

                //desenhar os pixels utilizando os pares de coordenadas da AET
                int quant = aet.Count();
                for (int i = 0; i < (quant / 2); i++)
                {
                    NoEdgeTable par1 = aet.GetNoEdgeTableAt(i * 2);
                    NoEdgeTable par2 = aet.GetNoEdgeTableAt(i * 2 + 1);

                    //pintar do (xMin par1) até (xMin par2)
                    int limite = (int) Math.Ceiling(par2.xMin);
                    for (int j = (int) Math.Ceiling(par1.xMin); j < limite; j++)
                        PintaPixel(src, data.Stride, width, height, j, y, Color.Orange.R, Color.Orange.G, Color.Orange.B);
                }

                //atualizar os xMin utilizando os incrementos
                for (int i = 0; i < aet.Count(); i++)
                    aet.GetNoEdgeTableAt(i).Incrementar();

                y++;
            
            }

        }

        private void FormarEdgeTable(EdgeTable[] et, Face face)
        {
            //formar a et, primeira parte do algoritmo para rasterização de polígonos

            List<Reta> arestas = face.GetArestas(VerticesAtuais);

            foreach (Reta r in arestas)
            {
                NoEdgeTable novoNo = new NoEdgeTable();

                //pegar o yMax
                novoNo.yMax = r.GetYMax();

                //pegar o xMin
                novoNo.xMin = r.GetXMin();

                //calcular o incremento no novoNo
                novoNo.CalcularIncremento(r);

                //setar na posição de Edge Table, onde: [yMin]
                int yMin = r.GetYMin();
                if (et[yMin] == null)
                {
                    et[yMin] = new EdgeTable();
                }
                et[yMin].Add(novoNo);
            }
        }

        private bool IsVectorEdgeEmpty(EdgeTable[] et, int tamanho)
        {
            //verificar se o vetor de Edge Table possui algum elemento para ser verificado
            bool possuiElementos = false;
            for (int i = 0; i < tamanho && !possuiElementos; i++)
                if (et[i] != null)
                    possuiElementos = true;
            return !possuiElementos;
        }
        unsafe private static void PintaPixel(byte* src, int stride, int width, int height, int x, int y, int R, int G, int B)
        {
            if (x >= 0 && x < width && y >= 0 && y < height) //limitar no tamanho da imagem
            {
                byte* pixel;
                pixel = src + y * stride + x * 3;
                *(pixel++) = (byte)B;
                *(pixel++) = (byte)G;
                *(pixel++) = (byte)R;
            }
        }
    }

    
}
