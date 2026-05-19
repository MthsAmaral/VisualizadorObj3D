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
            MatrizAcumulada = OperacaoMatriz.GerarMatrizIdentidade();
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
        public string[] LimparStringVazia(string[] array)
        {
            return array.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        }


        //====================================================================================================================================================
        //================== ELIMINAR DE FACES OCULTAS =========================
        private bool FaceEhVisivel(Face face, char tipoProjecao)
        {
            if (face.IndicesVertices.Count < 3)
                return false;

            PointReal normal = CalcularNormalFace(face);

            int i = face.IndicesVertices[0] - 1;
            PointReal pontoFace = VerticesAtuais[i];

            PointReal oa = Projecao.ObterVetorObservacao(pontoFace, tipoProjecao);

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






        //====================================================================================================================================================
        // ============== DESENHAR o objeto com base nos vértices e faces recuperados do arquivo .obj
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
                PointReal verticeTransformado = OperacaoMatriz.AplicarMatriz(vertice, MatrizAcumulada);
                //PointReal verticeProjetado = ConverterParaTela(verticeTransformado, largura, altura);
                VerticesAtuais.Add(verticeTransformado);
            }
        }

        // Esse desenhar plota na tela as faces do objeto 3D carregado atualmente
        public Bitmap Desenhar(int largura, int altura, double escala, bool ehProjecao, char tipoProjecao, bool eliminarFacesOcultas)
        {
            
            AtualizarVerticesAtuais(largura, altura);//passa tamanho real imagem

            if (ehProjecao)
                VerticesProjetados = Projecao.Projetar(VerticesAtuais, tipoProjecao);
            else
                VerticesProjetados = new List<PointReal>(VerticesAtuais);

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
                                    
                                    //VerticesProjetados SEMPRE tem vértices (se ehProjecao = falso, são cópias dos atuais)
                                    PointReal p1 = ConverterParaTela(VerticesProjetados[atualIndex], largura, altura);
                                    PointReal p2 = ConverterParaTela(VerticesProjetados[proximoIndex], largura, altura);

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

        //Bresenham: desenhar as linhas entre os vértices projetados
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








        // ====================================================================================================================================================
        // ========  Z-Buffer =========
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









        //====================================================================================================================================================
        // OPERAÇÕES COM MATRIZES
        public void ResetarMatrizAcumulada()
        {
            MatrizAcumulada = OperacaoMatriz.GerarMatrizIdentidade();
        }

        public void MultiplicaMatrizTranslacao(double dx, double dy, double dz)
        {
            double[,] translacao = OperacaoMatriz.CriarTranslacao(dx, dy, dz);
            MatrizAcumulada = OperacaoMatriz.Multiplicar(MatrizAcumulada, translacao);
        }

        public void MultiplicaMatrizEscala(double escalaX, double escalaY, double escalaZ)
        {
            double[,] escala = OperacaoMatriz.CriarEscala(escalaX, escalaY, escalaZ);
            MatrizAcumulada = OperacaoMatriz.Multiplicar(MatrizAcumulada, escala);
        }

        public void MultiplicaMatrizRotacao(int grau, char eixo)
        {
            double[,] rotacao = OperacaoMatriz.CriarRotacao(grau, eixo);
            MatrizAcumulada = OperacaoMatriz.Multiplicar(MatrizAcumulada, rotacao);
        }
    }
}
