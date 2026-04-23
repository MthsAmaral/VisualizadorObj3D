using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace ProcessamentoImagens.classes
{
    internal class Face
    {
        private List<Reta> ArestasOriginais { get; set; }
        private List<Reta> ArestasNormalizadas { get; set; }
        public List<int> IndicesVertices { get; set; } //tratar depois
        public List<int> IndicesVerticesTextura { get; set; } //tratar depois
        public List<int> IndicesVerticesNormais { get; set; } //tratar depois

        public Face()
        {
            ArestasOriginais = new List<Reta>();
            ArestasNormalizadas = new List<Reta>();
            IndicesVertices = new List<int>();
            IndicesVerticesTextura = new List<int>();
            IndicesVerticesNormais = new List<int>();
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

        //public List<Reta> GetArestasTransformadas()
        //{
        //    List<Reta> arestasTransformadas = new List<Reta>();
        //    List<Point> novosVertices = GetVerticesModificados();
        //    Point vertice1, vertice2;

        //    //ajustar os vértices das novas arestas
        //    vertice1 = novosVertices[0];
        //    for (int i = 1; i < novosVertices.Count; i++)
        //    {
        //        vertice2 = novosVertices[i];
        //        arestasTransformadas.Add(new Reta(vertice1, vertice2));
        //        vertice1 = vertice2;
        //    }
        //    vertice2 = novosVertices[0];
        //    arestasTransformadas.Add(new Reta(vertice1, vertice2)); //última aresta de fechamento

        //    return arestasTransformadas;
        //}

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
