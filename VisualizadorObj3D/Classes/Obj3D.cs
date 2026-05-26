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
        private List<PointReal> VerticesTextura { get; set; } //tratar??
        private List<PointReal> VerticesAtuais { get; set; }
        private List<PointReal> VerticesProjetados { get; set; }
        private List<Face> Faces { get; set; }
        private double[,] MatrizAcumulada { get; set; }
        private double[,] ZBuffer { get; set; }
        private Color[,] FrameBuffer { get; set; }

        private List<PointReal> VerticesTela { get; set; }
        public Bitmap bitmap { get; set; }

        PointReal pontoOlho = new PointReal(0, 0, 10);

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
        // ============== DESENHAR o objeto com base nos vértices e faces recuperados do arquivo .obj
        public PointReal ConverterParaTela(PointReal p, int largura, int altura)
        {
            double x = p.X + largura / 2;
            double y = -p.Y + altura / 2;

            return new PointReal(x, y, 0);
        }

        private void AtualizarVerticesAtuais()
        {
            VerticesAtuais.Clear();
            foreach (PointReal vertice in VerticesOriginais)
            {
                PointReal verticeTransformado = OperacaoMatriz.AplicarMatriz(vertice, MatrizAcumulada);
                VerticesAtuais.Add(verticeTransformado);
            }
        }

        // Esse desenhar plota na tela as faces do objeto 3D carregado atualmente
        public Bitmap Desenhar(int largura, int altura, double escala, bool ehProjecao, char tipoProjecao, bool eliminarFacesOcultas)
        {
            
            AtualizarVerticesAtuais();//passa tamanho real imagem

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
                            desenharFace = face.EhVisivel(face, tipoProjecao, VerticesAtuais);
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

        //metodo principal
        public void PreencherObjeto3D(Color cor, bool usarLuz, string tipoTonalizacao, bool ehProjecao, char tipoProjecao,
            Color corLuz, double luzX, double luzY, double luzZ, double ka, double kd, double ks, int nEspecular, string componente)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            // atualiza os vértices atuais para a exibição correta
            AtualizarVerticesAtuais();

            InicializarBuffers(width, height);

            // coleta apenas as faces que serão preenchidas na tela
            List<Face> facesVisiveis = GetFacesVisiveis();

            // traduz os vértices se for projeção
            if (ehProjecao)
                VerticesProjetados = Projecao.Projetar(VerticesAtuais, tipoProjecao);
            else
                VerticesProjetados = new List<PointReal>(VerticesAtuais);

            // traduz os vértices para funcionar com o bitmap atual
            VerticesTela = new List<PointReal>();
            foreach (PointReal p in VerticesProjetados)
            {
                VerticesTela.Add(ConverterParaTela(p, bitmap.Width,bitmap.Height));
            }

            for (int i = 0; i < facesVisiveis.Count; i++)
            {
                // passar nessa função a flag para utilização (ou não) de iluminação
                // além do tipo de tonalização da imagem
                PreencherFaceZBuffer(facesVisiveis[i], cor, width, height, usarLuz, tipoTonalizacao, componente,
                    corLuz, luzX, luzY, luzZ, ka, kd, ks, nEspecular);
            }

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                AtualizarBitmapComFrameBuffer(data, width, height);
            }
            bitmap.UnlockBits(data);
        }

        private void PreencherFaceZBuffer(Face face, Color corObjeto, int width, int height, bool usarLuz, String tipoTonalizacao, String componente, 
            Color corLuz, double luzX, double luzY, double luzZ, double ka, double kd, double ks, int nEspecular)
        {
            // Pegamos os vértices da face
            List<PointReal> verticesFace = face.GetVertices(VerticesAtuais);

            if (usarLuz)
            {
                // 1. Calcula L, E, H UMA VEZ para a face (Atalho da Luz Direcional)
                PointReal pontoLuz = new PointReal(luzX, luzY, luzZ);
                face.CalcularVetorE();
                face.CalcularVetorL(pontoLuz);
                face.CalcularVetorH();

               
                if (tipoTonalizacao.ToLower().Equals("flat"))
                {
                    face.CalcularVetorNormal(verticesFace);
                    
                    // Calcula a cor iluminada e manda pintar
                    Color corIluminada = face.CalcularCorIluminacao(corLuz, corObjeto, ka, kd, ks, nEspecular, componente);
                    pintarFaceFlat(face, corIluminada); 
                }
                else if (tipoTonalizacao.ToLower().Equals("gouraud"))
                {
                    List<Color> coresFace = new List<Color>();
                    
                    for (int i = 0; i < verticesFace.Count; i++)
                    {
                        PointReal verticeAtual = verticesFace[i];

                        // Pega emprestado os vetores da face
                        
                        verticeAtual.VetorE = face.VetorE;
                        verticeAtual.VetorL = face.VetorL;
                        verticeAtual.VetorH = face.VetorH;
                        List<Face> facesAdjacentes = GetFacesAdjacentes(verticeAtual);
                        foreach (Face f in facesAdjacentes) // 'faces' é a sua lista global de todas as faces
                        {
                            List<PointReal> vertsDaFace = f.GetVertices(VerticesAtuais);
                            f.CalcularVetorNormal(vertsDaFace);
                        }

                        verticeAtual.CalcularVetorNormalVertice(facesAdjacentes);
                        // ATENÇÃO: Aqui você precisa garantir que o vértice tenha a normal dele (VetorN)
                        // Seja lendo do arquivo .obj (o 'vn') ou calculando as adjacências se você preferir manter

                        coresFace.Add(verticeAtual.CalcularCorIluminacao(corLuz, corObjeto, ka, kd, ks, nEspecular, componente));
                    }

                    pintarFaceGouraud(face, verticesFace, coresFace); 
                }
                else if (tipoTonalizacao.ToLower().Equals("phong"))
                {
                    for (int i = 0; i < verticesFace.Count; i++)
                    {
                        PointReal verticeAtual = verticesFace[i];

                        // Mesma coisa: Garanta que o vértice tenha a Normal dele calculada ou lida
                        verticeAtual.VetorE = face.VetorE;
                        verticeAtual.VetorL = face.VetorL;
                        verticeAtual.VetorH = face.VetorH;
                    }

                    // Repassa para a Scanline do Phong fazer a mágica pixel por pixel
                    //pintarFacePhong(face, verticesFace, corLuz, corObjeto, ka, kd, ks, nEspecular, componente);
                }
            }
            else
            {
               
                pintarFaceFlat(face, corObjeto);
            }
        }
      
        private void pintarFaceFlat(Face face, Color corFinalDaFace)
        {
         
            int width = bitmap.Width;
            int height = bitmap.Height;
            PlanoFace plano = CalcularPlanoFace(face);
            EdgeTable[] et = new EdgeTable[height];
            FormarEdgeTable(et, face);
            int yMin = (int)GetYMinTela(face);
            int y = yMin;
            EdgeTable aet = new EdgeTable();
            while (!IsVectorEdgeEmpty(et, et.Length) || aet.Count() > 0)
            {
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

                aet.Sort();
                aet.RemoveAllYMax(y);

                int quant = aet.Count();
                for (int i = 0; i < (quant / 2); i++)
                {
                    NoEdgeTable par1 = aet.GetNoEdgeTableAt(i * 2);
                    NoEdgeTable par2 = aet.GetNoEdgeTableAt(i * 2 + 1); 

                    int limite = (int)Math.Ceiling(par2.xMin);

                    for (int j = (int)Math.Ceiling(par1.xMin); j < limite; j++)
                    {
                    
                        if (j >= 0 && j < width && y >= 0 && y < height)
                        {
                            double zAtual = CalcularZDoPlano(plano, j, y);
                            if (zAtual < ZBuffer[y, j])
                            {
                                ZBuffer[y, j] = zAtual; 
                                FrameBuffer[y, j] = corFinalDaFace; // cor do modelo flat
                            }
                        }
                    }
                }

                for (int i = 0; i < aet.Count(); i++)
                    aet.GetNoEdgeTableAt(i).Incrementar();

                y++;
            }
        }
        private void pintarFaceGouraud(Face face, List<PointReal> verticesFace, List<Color> coresFace)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            PlanoFace plano = CalcularPlanoFace(face);

            EdgeTable[] et = new EdgeTable[height];
            FormarEdgeTableGouraud(et, face, verticesFace, coresFace); 

            int yMin = (int)GetYMinTela(face);
            int y = yMin;
            EdgeTable aet = new EdgeTable();

            while (!IsVectorEdgeEmpty(et, et.Length) || aet.Count() > 0)
            {
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

                aet.Sort();
                aet.RemoveAllYMax(y);

                int quant = aet.Count();
                for (int i = 0; i < (quant / 2); i++)
                {
                    NoEdgeTable par1 = aet.GetNoEdgeTableAt(i * 2); 
                    NoEdgeTable par2 = aet.GetNoEdgeTableAt(i * 2 + 1); 
                    double deltaX = par2.xMin - par1.xMin;
                    
                    if (deltaX == 0) 
                        deltaX = 1; 

                    double rIncHor = (par2.rMin - par1.rMin) / deltaX;
                    double gIncHor = (par2.gMin - par1.gMin) / deltaX;
                    double bIncHor = (par2.bMin - par1.bMin) / deltaX;

                    double rPixel = par1.rMin;
                    double gPixel = par1.gMin;
                    double bPixel = par1.bMin;

                    int limite = (int)Math.Ceiling(par2.xMin);
                    for (int j = (int)Math.Ceiling(par1.xMin); j < limite; j++)
                    {
                        if (j >= 0 && j < width && y >= 0 && y < height)
                        {
                            double zAtual = CalcularZDoPlano(plano, j, y);

                            if (zAtual < ZBuffer[y, j])
                            {
                                ZBuffer[y, j] = zAtual;
                                
                                Color corInterpolada = Color.FromArgb(
                                    LimitarCor(rPixel * 255.0), 
                                    LimitarCor(gPixel * 255.0), 
                                    LimitarCor(bPixel * 255.0)
                                );
                                FrameBuffer[y, j] = corInterpolada;
                            }
                        }
                        
                        rPixel += rIncHor;
                        gPixel += gIncHor;
                        bPixel += bIncHor;
                    }
                }
                for (int i = 0; i < aet.Count(); i++)
                {
                    NoEdgeTable no = aet.GetNoEdgeTableAt(i);
                    no.Incrementar(); 
                }

                y++;
            }
        }
        private int LimitarCor(double valor)
        {
            if (valor > 255.0)
                return 255;
            if (valor < 0.0) 
                return 0;
            return (int) valor;
        }
        private void InicializarBuffers(int largura, int altura)
        {
            ZBuffer = new double[altura, largura];
            FrameBuffer = new Color[altura, largura];

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    ZBuffer[y, x] = double.MaxValue;
                    FrameBuffer[y, x] = Color.Black;
                }
            }
        }

        private List<Face> GetFacesVisiveis()
        {
            List<Face> visiveis = new List<Face>();

            foreach (Face f in Faces)
                if (f.EhVisivel(f, Form1.c, VerticesAtuais) /*FaceEhVisivel(f, Form1.c)*/)
                    visiveis.Add(f);

            return visiveis;
        }

        private List<Face> GetFacesAdjacentes(PointReal verticeAlvo)
        {
            List<Face> facesVizinhas = new List<Face>();

            // 'faces' é a lista que contém todos os polígonos do seu objeto 3D
            foreach (Face faceAtual in Faces)
            {
                // Pega os vértices que compõem essa face específica
                List<PointReal> verticesDestaFace = faceAtual.GetVertices(VerticesAtuais);

                // Verifica se o nosso 'verticeAlvo' é um dos vértices desta face
                foreach (PointReal v in verticesDestaFace)
                {
                    // É mais seguro comparar as coordenadas X, Y, Z do que a referência na memória.
                    // Se as coordenadas baterem, significa que os vértices estão no mesmo lugar (se tocam)!
                    if (v.X == verticeAlvo.X && v.Y == verticeAlvo.Y && v.Z == verticeAlvo.Z)
                    {
                        facesVizinhas.Add(faceAtual);

                        // Como já confirmamos que essa face toca no vértice, 
                        // podemos parar de procurar os outros vértices dela e ir para a próxima face.
                        break;
                    }
                }
            }

            return facesVizinhas;
        }

        private unsafe void AtualizarBitmapComFrameBuffer(BitmapData data, int width, int height)
        {
            byte* src = (byte*)data.Scan0.ToPointer();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = FrameBuffer[y, x];
                    byte* pixel = src + y * data.Stride + x * 3;
                    pixel[0] = c.B;
                    pixel[1] = c.G;
                    pixel[2] = c.R;
                }
            }
        }

        //guardar a equação do plano da face, utilizada pra descobrir o z de cada pixel da face
        private class PlanoFace
        {
            public double A;
            public double B;
            public double C;
            public double D;
        }

        private double CalcularZDoPlano(PlanoFace plano, int xTela, int yTela)
        {
            if (Math.Abs(plano.C) < 0.000001)
                return double.MaxValue;

            return -(plano.A * xTela + plano.B * yTela + plano.D) / plano.C;
        }

        private PlanoFace CalcularPlanoFace(Face face)
        {
            int i1 = face.IndicesVertices[0] - 1;
            int i2 = face.IndicesVertices[1] - 1;
            int i3 = face.IndicesVertices[2] - 1;
            PointReal p1Tela = VerticesTela[i1];
            PointReal p2Tela = VerticesTela[i2];
            PointReal p3Tela = VerticesTela[i3];

            double z1 = VerticesProjetados[i1].Z;
            double z2 = VerticesProjetados[i2].Z;
            double z3 = VerticesProjetados[i3].Z;

            double A1 = p2Tela.X - p1Tela.X;
            double B1 = p2Tela.Y - p1Tela.Y;
            double C1 = z2 - z1;

            double A2 = p3Tela.X - p1Tela.X;
            double B2 = p3Tela.Y - p1Tela.Y;
            double C2 = z3 - z1;

            PlanoFace plano = new PlanoFace();
            plano.A = B1 * C2 - C1 * B2;
            plano.B = C1 * A2 - A1 * C2;
            plano.C = A1 * B2 - B1 * A2;
            plano.D = -(plano.A * p1Tela.X + plano.B * p1Tela.Y + plano.C * z1);

            return plano;
        }

        private void FormarEdgeTable(EdgeTable[] et, Face face)
        {
            //formar a et, primeira parte do algoritmo para rasterização de polígonos

            List<Reta> arestas = face.GetArestas(VerticesTela);

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

                if(yMin > 0 && yMin < et.Length)
                {
                    if (et[yMin] == null)
                    {
                        et[yMin] = new EdgeTable();
                    }
                    et[yMin].Add(novoNo);
                }
            }
        }
        private void FormarEdgeTableGouraud(EdgeTable[] et, Face face, List<PointReal> verticesFace, List<Color> coresFace)
        {
        
            for (int i = 0; i < face.IndicesVertices.Count; i++)
            {
                int prox = (i + 1) % face.IndicesVertices.Count; 

                int idx1 = face.IndicesVertices[i] - 1; 
                int idx2 = face.IndicesVertices[prox] - 1;

                PointReal p1Tela = VerticesTela[idx1];
                PointReal p2Tela = VerticesTela[idx2];

                Color cor1 = coresFace[i];
                Color cor2 = coresFace[prox];

                PointReal pTopo, pBase;
                Color cTopo, cBase;

                if (p1Tela.Y < p2Tela.Y)
                {
                    pTopo = p1Tela; pBase = p2Tela;
                    cTopo = cor1;   cBase = cor2;
                }
                else
                {
                    pTopo = p2Tela; pBase = p1Tela;
                    cTopo = cor2;   cBase = cor1;
                }

                double deltaY = pBase.Y - pTopo.Y;
                if (deltaY > 0)
                {
                    NoEdgeTable novoNo = new NoEdgeTable();

                    novoNo.yMax = (int)Math.Round(pBase.Y);
                    novoNo.xMin = pTopo.X;
                    novoNo.xInc = (pBase.X - pTopo.X) / deltaY;

                    novoNo.rMin = cTopo.R / 255.0;
                    novoNo.gMin = cTopo.G / 255.0;
                    novoNo.bMin = cTopo.B / 255.0;

                    double rBaseNormal = cBase.R / 255.0;
                    double gBaseNormal = cBase.G / 255.0;
                    double bBaseNormal = cBase.B / 255.0;

                    novoNo.rInc = (rBaseNormal - novoNo.rMin) / deltaY;
                    novoNo.gInc = (gBaseNormal - novoNo.gMin) / deltaY;
                    novoNo.bInc = (bBaseNormal - novoNo.bMin) / deltaY;

                    int yMin = (int)Math.Round(pTopo.Y);
                    
                    if (yMin >= 0 && yMin < et.Length)
                    {
                        if (et[yMin] == null) et[yMin] = new EdgeTable();
                        et[yMin].Add(novoNo);
                    }
                }

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

        private double GetYMaxTela(Face face)
        {
            double maior = double.MinValue;
            foreach (int indiceVertice in face.IndicesVertices)
            {
                int indice = indiceVertice - 1;
                PointReal pTela = VerticesTela[indice];

                if (pTela.Y > maior)
                    maior = pTela.Y;
            }
            return maior;
        }
        private double GetYMinTela(Face face)
        {
            double menor = double.MaxValue;
            foreach (int indiceVertice in face.IndicesVertices)
            {
                int indice = indiceVertice - 1;
                PointReal pTela = VerticesTela[indice];

                if (pTela.Y < menor)
                    menor = pTela.Y;
            }
            return menor;
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
