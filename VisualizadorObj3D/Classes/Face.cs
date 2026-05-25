using ProcessamentoImagens.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace ProcessamentoImagens.classes
{
    internal class Face
    {
        public List<int> IndicesVertices { get; set; }
        public List<int> IndicesVerticesTextura { get; set; } //tratar --> iluminação
        public List<int> IndicesVerticesNormais { get; set; } //tratar --> iluminação

        private PointReal VetorNormal { get; set; }
        private PointReal VetorE { get; set; }
        private PointReal VetorL { get; set; }
        private PointReal VetorH { get; set; }
        private PointReal N {  get; set; }
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
            N = CalcularProdutoEscalar(vAB, vAC);
            double moduloN = CalcularVetorModulo(N);
            N = CalcularDivisaoModulo(N, moduloN);
        }
        private PointReal CalcularDivisaoModulo(PointReal v1, double modulo)
        {
            return new PointReal(v1.X / modulo, v1.Y / modulo, v1.Z / modulo);
        }
        private double CalcularVetorModulo(PointReal v1)
        {
            return Math.Sqrt(Math.Pow(v1.X, 2) + Math.Pow(v1.Y, 2) + Math.Pow(v1.Z, 2));
        }
        private PointReal CalcularProdutoEscalar(PointReal v1, PointReal v2)
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
        private PointReal CalcularSubtracaoVetor(PointReal v1, PointReal v2)
        {
            return new PointReal(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        private PointReal CalcularAdicaoVetor(PointReal v1, PointReal v2)
        {
            return new PointReal(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public void CalcularVetorE(PointReal PontoObs)
        {
            VetorE = CalcularDivisaoModulo(PontoObs, CalcularVetorModulo(PontoObs));
        }
        public void CalcularVetorL(PointReal PontoLuz)
        {
            VetorL = CalcularDivisaoModulo(PontoLuz, CalcularVetorModulo(PontoLuz));
        }
        public void CalcularVetorH()
        {
            PointReal vELAdicao = CalcularAdicaoVetor(VetorL, VetorE);
            double modulovEL = CalcularVetorModulo(vELAdicao);


            VetorH = CalcularDivisaoModulo(vELAdicao, modulovEL);
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
    }
}
