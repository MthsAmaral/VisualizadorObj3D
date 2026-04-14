using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace ProcessamentoImagens.classes
{
    internal class Poligono
    {
        private List<Reta> Arestas { get; set; }
        private double[,] MatrizTransformacao { get; set; }

        public Poligono()
        {
            Arestas = new List<Reta>();
            MatrizTransformacao = new double[3, 3];

            GerarMatrizIdentidade();
        }

        public Reta GetArestaAt(int pos)
        {
            if (pos > -1 && pos < Arestas.Count)
                return Arestas[pos];
            return null;
        }

        public List<Reta> GetArestas()
        {
            return Arestas;
        }

        public void AddAresta(Reta r)
        {
            Arestas.Add(r);
        }

        public void ClearPoligono()
        {
            Arestas.Clear();
        }

        public int CountArestas()
        {
            return Arestas.Count;
        }

        private void GerarMatrizIdentidade()
        {
            /*
            1 0 0
            0 1 0
            0 0 1
            */
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (i == j)
                        MatrizTransformacao[i, j] = 1;
                    else
                        MatrizTransformacao[i, j] = 0; 
        }

        public Double? GetMatrizXY(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 3 && y < 3)
                return MatrizTransformacao[x, y];
            return null;
        }

        public void SetMatrizXY(int x, int y, double valor)
        {
            if (x > -1 && x < 3 && y > -1 && y < 3)
                MatrizTransformacao[x, y] = valor;
        }

        public override string ToString()
        {
            string retorno = $"{Arestas.Count}";
            for (int i = 0; i < Arestas.Count; i++)
            {
                retorno += $"|{Arestas[i].GetIniX()},{Arestas[i].GetIniY()}|{Arestas[i].GetFimX()},{Arestas[i].GetFimY()}";
            }
            return retorno;
        }

        public int GetYMax()
        {
            List<Point> vertices = GetVerticesModificados();
            int maior = vertices[0].Y;

            for(int i=1; i<vertices.Count; i++)
                if(vertices[i].Y > maior)
                    maior = vertices[i].Y;

            return maior;
        }

        public int GetYMin()
        {
            List<Point> vertices = GetVerticesModificados();
            int menor = vertices[0].Y;

            for(int i=1; i<vertices.Count; i++)
                if(vertices[i].Y < menor)
                    menor = vertices[i].Y;

            return menor;
        }

        public int GetPosAresta(Point p)
        {
            int i=0;
            List<Reta> arestasTransformadas = GetArestasTransformadas();
            while(i<arestasTransformadas.Count && (p.X != arestasTransformadas[i].GetIniX() || p.Y != arestasTransformadas[i].GetIniY()))
                i++;
                
            if(i<arestasTransformadas.Count && p.X == arestasTransformadas[i].GetIniX() && p.Y == arestasTransformadas[i].GetIniY())
                return i;
            return -1;
        }

        public List<Reta> GetArestasTransformadas()
        {
            List<Reta> arestasTransformadas = new List<Reta>();
            List<Point> novosVertices = GetVerticesModificados();
            Point vertice1, vertice2;

            //ajustar os vértices das novas arestas
            vertice1 = novosVertices[0];
            for (int i = 1; i < novosVertices.Count; i++)
            {
                vertice2 = novosVertices[i];
                arestasTransformadas.Add(new Reta(vertice1, vertice2));
                vertice1 = vertice2;
            }
            vertice2 = novosVertices[0];
            arestasTransformadas.Add(new Reta(vertice1, vertice2)); //última aresta de fechamento

            return arestasTransformadas;
        }

        // Retorno dos vértices do meu polígono
        public List<Point> GetVerticesOriginais()
        {
            List<Point> vertices = new List<Point>();

            for (int i = 0; i < Arestas.Count; i++)
                vertices.Add(new Point(Arestas[i].GetIniX(), Arestas[i].GetIniY()));

            return vertices;
        }

        public List<Point> GetVerticesModificados()
        {
            List<Point> vertices = GetVerticesOriginais();
            List<Point> novosVertices = new List<Point>();

            for (int i = 0; i < vertices.Count; i++)
                novosVertices.Add(MultiplicaVerticeMatriz(vertices[i]));

            return novosVertices;
        }

        private void MultiplicaMatrizTransformacao(double[,] matriz, double[,] resultado)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    double valor = 0;
                    for (int i = 0; i < 3; i++)
                        valor += MatrizTransformacao[l, i] * matriz[i, c];

                    //setar na matriz de resultado
                    resultado[l, c] = valor;
                }
            }
        }

        private void SetarTodaMatrizTransformacao(double[,] resultado)
        {
            for(int i=0; i<3; i++)
                for(int j=0; j<3; j++)
                    SetMatrizXY(i, j, resultado[i,j]);
        }

        public Point MultiplicaVerticeMatriz(Point vertice)
        {
            double valorX=0, valorY=0, valorZ=0;

            valorX += MatrizTransformacao[0,0]*vertice.X;
            valorX += MatrizTransformacao[0,1]*vertice.Y;
            valorX += MatrizTransformacao[0,2]*1;

            valorY += MatrizTransformacao[1,0]*vertice.X;
            valorY += MatrizTransformacao[1,1]*vertice.Y;
            valorY += MatrizTransformacao[1,2]*1;

            valorZ += MatrizTransformacao[2,0]*vertice.X;
            valorZ += MatrizTransformacao[2,1]*vertice.Y;
            valorZ += MatrizTransformacao[2,2]*1;

            return new Point((int)valorX, (int)valorY);
        }

        public void MultiplicaMatrizTranslacao(double dx, double dy)
        {
            /*
                1 0 dx -> dx -> translação em relação ao eixo x
                0 1 dy -> dy -> translação em relação ao eixo y
                0 0 1
            */
            double[,] resultado = new double[3, 3];
            double[,] matrizTranslacao = new double[3, 3] {
                { 1, 0, dx },
                { 0, 1, dy },
                { 0, 0, 1 }
            };

            MultiplicaMatrizTransformacao(matrizTranslacao, resultado);
            SetarTodaMatrizTransformacao(resultado);
        }

        public void MultiplicaMatrizEscala(double escalaX, double escalaY, Point vertice)
        {
            /*
                sx 0  0 -> sx -> escalaX
                0  sy 0 -> sy -> escalaY
                0  0  1
            */
            double[,] resultado = new double[3, 3];
            double[,] matrizEscala = new double[3, 3] {
                { escalaX, 0, 0 },
                { 0, escalaY, 0 },
                { 0, 0, 1 } };
            
            //Aplicar a translação -> mandar para a coordenada (0,0)
            MultiplicaMatrizTranslacao(vertice.X, vertice.Y);
            
            //Aplicar a transformação em questão -> rotação
            MultiplicaMatrizTransformacao(matrizEscala, resultado);
            SetarTodaMatrizTransformacao(resultado);

            //Aplicar a translação -> mandar para a coordenada (origemX, origemY)
            MultiplicaMatrizTranslacao(-vertice.X, -vertice.Y);
        }

        public void MultiplicaMatrizCisalhamento(double cisalhamentoX, double cisalhamentoY, Point vertice)
        {
            /*
                1 b 0 -> b -> cisalhamentoX
                a 1 0 -> a -> cisalhamentoY
                0 0 1
            */
            double[,] resultado = new double[3, 3];
            double[,] matrizCisalhamento = new double[3, 3] {
                { 1, cisalhamentoX, 0 },
                { cisalhamentoY, 1, 0 },
                { 0, 0, 1 }
            };

            //Aplicar a translação -> mandar para a coordenada (0,0)
            MultiplicaMatrizTranslacao(vertice.X, vertice.Y);

            //Aplicar a transformação em questão -> cisalhamento
            MultiplicaMatrizTransformacao(matrizCisalhamento, resultado);
            SetarTodaMatrizTransformacao(resultado);

            //Aplicar a translação -> mandar para a coordenada (origemX, origemY)
            MultiplicaMatrizTranslacao(-vertice.X, -vertice.Y);
        }

        public void MultiplicaMatrizReflexao(bool reflexaoX, bool reflexaoY, Point vertice)
        {
            /*
            em Y : -1  0  0   
                    0  1  0
                    0  0  1

            em X :  1  0  0
                    0 -1  0
                    0  0  1
            */
            double[,] resultado = new double[3, 3];
            double[,] matrizReflexao = new double[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
                };

            if (reflexaoX && reflexaoY)
            {
                matrizReflexao[0,0] = -1;
                matrizReflexao[1,1] = -1;
            }
            else if (reflexaoX)
                matrizReflexao[1,1] = -1;
            else if (reflexaoY)
                matrizReflexao[0,0] = -1;

            //Aplicar a translação -> mandar para a coordenada (0,0)
            MultiplicaMatrizTranslacao(vertice.X, vertice.Y);

            //Aplicar a transformação em questão -> reflexão
            MultiplicaMatrizTransformacao(matrizReflexao, resultado);
            SetarTodaMatrizTransformacao(resultado);
            
            //voltar para a posição original, porém refletido
            MultiplicaMatrizTranslacao(-vertice.X, -vertice.Y);
        }

        public void MultiplicaMatrizRotacao(int grau, Point vertice)
        {
            /*
                cos(grau)  -sen(grau)     0
                sen(grau)  cos(grau)      0
                0             0           1
            */
            double cosseno = Math.Cos(grau * Math.PI/180); //quando passado em radianos, funciona normalmente
            double seno = Math.Sin(grau * Math.PI/180);    //quando passado em radianos, funciona normalmente
            double[,] resultado = new double[3, 3];
            double[,] matrizRotacao = new double[3, 3] {
                { cosseno, -seno, 0 },
                { seno, cosseno, 0 },
                { 0, 0, 1 }
            };
            
            //Aplicar a translação -> mandar para a coordenada (0,0)
            MultiplicaMatrizTranslacao(vertice.X, vertice.Y);

            //Aplicar a transformação em questão -> rotação
            MultiplicaMatrizTransformacao(matrizRotacao, resultado);
            SetarTodaMatrizTransformacao(resultado);

            //Aplicar a translação -> mandar para a coordenada (origemX, origemY)
            MultiplicaMatrizTranslacao(-vertice.X, -vertice.Y);
        }

    }
}
