using ProcessamentoImagens.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using VisualizadorObj3D.Classes;

namespace ProcessamentoImagens.classes
{
    public class Face
    {
        public List<int> IndicesVertices { get; set; }
        public List<int> IndicesVerticesTextura { get; set; } //tratar --> iluminação
        public List<int> IndicesVerticesNormais { get; set; } //tratar --> iluminação

        public PointReal VetorN { get; set; }
        public PointReal VetorE { get; set; }
        public PointReal VetorL { get; set; }
        public PointReal VetorH { get; set; }
        
        public Face()
        {
            IndicesVertices = new List<int>();
            IndicesVerticesTextura = new List<int>();
            IndicesVerticesNormais = new List<int>();
        }

        public void CalcularVetorNormal(List<PointReal> vertices)
        {
            PointReal vA = vertices[0];
            PointReal vB = vertices[1];
            PointReal vC = vertices[2];
            PointReal vAB = CalcularSubtracaoVetor(vB, vA);
            PointReal vAC = CalcularSubtracaoVetor(vC, vA);
            VetorN = CalcularProdutoVetorial(vAB, vAC);
            double moduloN = CalcularVetorModulo(VetorN);
            if (moduloN != 0)
                VetorN = CalcularDivisaoModulo(VetorN, moduloN);
        }
        private PointReal CalcularDivisaoModulo(PointReal v1, double modulo)
        {
            return new PointReal(v1.X / modulo, v1.Y / modulo, v1.Z / modulo);
        }
        private double CalcularVetorModulo(PointReal v1)
        {
            return Math.Sqrt(Math.Pow(v1.X, 2) + Math.Pow(v1.Y, 2) + Math.Pow(v1.Z, 2));
        }
        private PointReal CalcularProdutoVetorial(PointReal v1, PointReal v2)
        {
            double i1, i2, j1, j2, k1, k2;
            i1 = v1.Y * v2.Z;
            j1 = v1.Z * v2.X;
            k1 = v1.X * v2.Y;
            i2 = v1.Z * v2.Y;
            j2 = v1.X * v2.Z;
            k2 = v1.Y * v2.X;

            return new PointReal(i1 - i2, j1 - j2, k1 -k2);
        }
        private double CalcularProdutoEscalar(PointReal v1, PointReal v2)
        {
            return (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z);
        }
        private PointReal CalcularSubtracaoVetor(PointReal v1, PointReal v2)
        {
            return new PointReal(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        private PointReal CalcularAdicaoVetor(PointReal v1, PointReal v2)
        {
            return new PointReal(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public void CalcularVetorE()
        {
            VetorE = new PointReal(0, 0, -1);
        }

        public void CalcularVetorL(PointReal pontoLuz)
        {
            double moduloL = CalcularVetorModulo(pontoLuz);

          
            if (moduloL != 0)
                VetorL = CalcularDivisaoModulo(pontoLuz, moduloL);
            else
                VetorL = new PointReal(0, 0, 1); 
        }
        public void CalcularVetorH()
        {
            PointReal vELAdicao = CalcularAdicaoVetor(VetorL, VetorE);
            double moduloH = CalcularVetorModulo(vELAdicao);

            if (moduloH != 0)
                VetorH = CalcularDivisaoModulo(vELAdicao, moduloH);
            else
                VetorH = new PointReal(0, 0, 1);
        }

        public double CalcularDifusa()
        {
            return VetorL.X * VetorN.X + VetorL.Y * VetorN.Y + VetorL.Z * VetorN.Z;
        }
        public double CalcularEspecular(int nEspecular)
        {
            return Math.Pow(VetorH.X * VetorN.X + VetorH.Y * VetorN.Y + VetorH.Z * VetorN.Z, nEspecular);
        }
        public Color CalcularCorIluminacao(Color corLuz, Color corObjeto, double ka, double kd, double ks, int nEspecular, string componente)
        {
            // Superficie
           // k_a: ka * Cor Objeto * Cor Luz
           // k_d: kd * Cor Objeto * Cor Luz * <L, N>
           // k_e:  ks * Cor Luz * <H, N> elevado n 
            double corObjetoNormalR = corObjeto.R / 255.0;
            double corObjetoNormalG = corObjeto.G / 255.0;
            double corObjetoNormalB = corObjeto.B / 255.0;

            double corLuzNormalR = corLuz.R / 255.0;
            double corLuzNormalG = corLuz.G / 255.0;
            double corLuzNormalB = corLuz.B / 255.0;

            double k_aR = ka * corObjetoNormalR * corLuzNormalR;
            double k_aG = ka * corObjetoNormalG * corLuzNormalG;
            double k_aB = ka * corObjetoNormalB * corLuzNormalB;
     
            double produtoEscalarLN = Math.Max(0,CalcularProdutoEscalar(VetorL, VetorN));
            double k_dR = kd * corObjetoNormalR * corLuzNormalR * produtoEscalarLN;
            double k_dG = kd * corObjetoNormalG * corLuzNormalG * produtoEscalarLN;
            double k_dB = kd * corObjetoNormalB * corLuzNormalB * produtoEscalarLN;

            double produtoEscalarHN = Math.Max(0,CalcularProdutoEscalar(VetorH, VetorN));
            double especular = Math.Pow(produtoEscalarHN, nEspecular);
            double k_sR = ks * corLuzNormalR * especular;
            double k_sG = ks * corLuzNormalG * especular;
            double k_sB = ks * corLuzNormalB * especular;

            double somaR, somaG, somaB;
            if (componente.Equals("ambiente"))
            {
                somaR = k_aR;
                somaG = k_aG;
                somaB = k_aB;
            }
            else
            if (componente.Equals("difusa"))
            {
                somaR = k_dR;
                somaG = k_dG;
                somaB = k_dB;
            }
            else
            if (componente.Equals("especular"))
            {
                somaR = k_sR;
                somaG = k_sG;
                somaB = k_sB;
            }
            else // total
            {
                somaR = k_aR + k_dR + k_sR;
                somaG = k_aG + k_dG + k_sG;
                somaB = k_aB + k_dB + k_sB;   
            }
            
            int finalR = LimitarCor(somaR * 255.0);
            int finalG = LimitarCor(somaG * 255.0);
            int finalB = LimitarCor(somaB * 255.0);

            return Color.FromArgb(finalR, finalG, finalB);
        }
        private int LimitarCor(double valor)
        {
           
            if (valor > 255.0)
                return 255;

            if (valor < 0.0)
                return 0;

            return (int)valor;
        }
        //================== MÉTODOS UTILIZADOS NO ELIMINAR FACES OCULTAS =========================
        public bool EhVisivel(Face face, char tipoProjecao, List<PointReal> verticesAtuais)
        {
            if (face.IndicesVertices.Count < 3)
                return false;

            PointReal normal = CalcularNormalFace(face, verticesAtuais);

            int i = face.IndicesVertices[0] - 1;
            PointReal pontoFace = verticesAtuais[i];

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
        private PointReal CalcularNormalFace(Face face, List<PointReal> verticesAtuais)
        {
            if (face.IndicesVertices.Count < 3)
            {
                return new PointReal(0, 0, 0);
            }

            int i1 = face.IndicesVertices[0] - 1;
            int i2 = face.IndicesVertices[1] - 1;
            int i3 = face.IndicesVertices[2] - 1;

            PointReal p1 = verticesAtuais[i1];
            PointReal p2 = verticesAtuais[i2];
            PointReal p3 = verticesAtuais[i3];

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

        //public Reta GetArestaAt(int pos)
        //{
        //    if (pos > -1 && pos < Arestas.Count)
        //        return Arestas[pos];
        //    return null;
        //}

        //public List<Reta> GetArestas()
        //{
        //    return Arestas;
        //}

        //public void AddAresta(Reta r)
        //{
        //    Arestas.Add(r);
        //}

        //public void ClearPoligono()
        //{
        //    Arestas.Clear();
        //}

        //public int CountArestas()
        //{
        //    return Arestas.Count;
        //}

        //public int GetYMax()
        //{
        //    List<Point> vertices = GetVerticesModificados();
        //    int maior = vertices[0].Y;

        //    for(int i=1; i<vertices.Count; i++)
        //        if(vertices[i].Y > maior)
        //            maior = vertices[i].Y;

        //    return maior;
        //}

        //public int GetYMin()
        //{
        //    List<Point> vertices = GetVerticesModificados();
        //    int menor = vertices[0].Y;

        //    for(int i=1; i<vertices.Count; i++)
        //        if(vertices[i].Y < menor)
        //            menor = vertices[i].Y;

        //    return menor;
        //}

        //public int GetPosAresta(Point p)
        //{
        //    int i=0;
        //    List<Reta> arestasTransformadas = GetArestasTransformadas();
        //    while(i<arestasTransformadas.Count && (p.X != arestasTransformadas[i].GetIniX() || p.Y != arestasTransformadas[i].GetIniY()))
        //        i++;

        //    if(i<arestasTransformadas.Count && p.X == arestasTransformadas[i].GetIniX() && p.Y == arestasTransformadas[i].GetIniY())
        //        return i;
        //    return -1;
        //}

        public List<Reta> GetArestas(List<PointReal> verticesAtuais)
        {
            List<Reta> arestas = new List<Reta>();
            PointInteiro vertice1, vertice2;
            List<PointInteiro> novosVertices = GetVerticesDaFace(verticesAtuais);

            //ajustar os vértices das novas arestas
            vertice1 = novosVertices[0];
            for (int i = 1; i < novosVertices.Count; i++)
            {
                vertice2 = novosVertices[i];
                arestas.Add(new Reta(vertice1, vertice2));
                vertice1 = vertice2;
            }
            vertice2 = novosVertices[0];
            arestas.Add(new Reta(vertice1, vertice2)); //última aresta de fechamento

            return arestas;
        }

        private List<PointInteiro> GetVerticesDaFace(List<PointReal> verticesAtuais)
        {
            List<PointInteiro> vertices = new List<PointInteiro>();
            foreach(int i in IndicesVertices)
            {
                PointReal point = verticesAtuais[i-1];
                PointInteiro p = new PointInteiro();
                p.X = (int) point.X;
                p.Y = (int) point.Y;
                p.Z = (int) point.Z;
                vertices.Add(p);
            }
                

            return vertices;
        }

        //// Retorno dos vértices do meu polígono
        //public List<Point> GetVerticesOriginais()
        //{
        //    List<Point> vertices = new List<Point>();

        //    for (int i = 0; i < Arestas.Count; i++)
        //        vertices.Add(new Point(Arestas[i].GetIniX(), Arestas[i].GetIniY()));

        //    return vertices;
        //}

        //public List<Point> GetVerticesModificados()
        //{
        //    List<Point> vertices = GetVerticesOriginais();
        //    List<Point> novosVertices = new List<Point>();

        //    for (int i = 0; i < vertices.Count; i++)
        //        novosVertices.Add(MultiplicaVerticeMatriz(vertices[i]));

        //    return novosVertices;
        //}

        public List<PointReal> GetVertices(List<PointReal> VerticesObj3D)
        {
            List<PointReal> verticesFace = new List<PointReal>();
            for(int i = 0; i<IndicesVertices.Count; i++)
            {
                verticesFace.Add(VerticesObj3D[IndicesVertices[i] - 1]);
            }
            return verticesFace;
        }

        public PointReal CalcularCentroide(List<PointReal> vertices)
        {
            double x = 0, y = 0, z = 0;

            foreach (var v in vertices)
            {
                x += v.X;
                y += v.Y;
                z += v.Z;
            }

            int n = vertices.Count;
            return new PointReal(x / n, y / n, z / n);
        }
    }
}
