using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.classes.EdgeTable
{
    internal class EdgeTable
    {
        private NoEdgeTable et { get; set; } //abreviação para "Edge Table"

        public EdgeTable()
        {
            et = null;
        }

        public EdgeTable(NoEdgeTable no)
        {
            et = no;
        }

        public NoEdgeTable GetNoEdgeTableAt(int pos)
        {
            NoEdgeTable aux = et;
            int i = 0;

            while (aux != null && i < pos)
            {
                aux = aux.prox;
                i++;
            }

            return aux;
        }

        public void Add(NoEdgeTable no)
        {
            no.prox = null; 

            if (et == null)
                et = no;
            else
            {
                NoEdgeTable aux = et;
                while (aux.prox != null)
                    aux = aux.prox;

                aux.prox = no;
            }
        }

        public void AddAt(NoEdgeTable no, int pos)
        {
            NoEdgeTable aux, ant;

            if (pos == 0) //inserir na primeira posição
            {
                no.prox = et;
                et = no;
            }
            else //inserir em qualquer posição depois da primeira
            {
                aux = et;
                ant = aux;
                int i = 0;
                while (aux != null && i < pos + 1)
                {
                    ant = aux;
                    aux = aux.prox;
                }

                if (aux != null) //achei a posição correta
                {
                    ant.prox = no;
                    no.prox = aux;
                }
            }
        }

        public int Count()
        {
            //contar a quantidade de nós que possuem a minha lista
            int count = 0;
            NoEdgeTable aux = et;
            while (aux != null)
            {
                aux = aux.prox;
                count++;
            }
            return count;
        }

        public void Sort()
        {
            NoEdgeTable fim = GetNoEdgeTableAt(Count() - 1);
            NoEdgeTable i = et, posMenor, j;
            double menor;

            if (et == null)
                return;

            while (i != fim)
            {
                menor = i.xMin;
                posMenor = i;//Caixa com xMin menor

                j = i.prox;
                while (j != null)
                {
                    //ordena pela chave "xMin" mas no caso de empate utiliza o "inc"
                    if (j.xMin < menor || (j.xMin == menor && j.inc < posMenor.inc))
                    {
                        menor = j.xMin;
                        posMenor = j;
                    }
                    j = j.prox;
                }

                int auxYMax = posMenor.yMax;
                double auxXMin = posMenor.xMin;
                double auxInc = posMenor.inc;

                posMenor.yMax = i.yMax;
                posMenor.xMin = i.xMin;
                posMenor.inc = i.inc;

                i.yMax = auxYMax;
                i.xMin = auxXMin;
                i.inc = auxInc;

                i = i.prox;
            }
        }

        public void RemoveAllYMax(int y)
        {
            //remover todos os elementos da minha lista que o yMax == y
            NoEdgeTable aux = et;
            NoEdgeTable ant = aux;
            while (aux != null) //realizar uma varredura
            {
                if (aux.yMax == y) //remover essa caixa
                {
                    if (aux == et)
                    {
                        et = aux.prox;
                    }
                    else
                    {
                        ant.prox = aux.prox;

                    }
                    aux = aux.prox;
                }
                else
                {
                    ant = aux;
                    aux = aux.prox;
                }
            }
        }

        public void Clear()
        {
            //limpa a EdgeTable
            et = null;
        }

        public void Remove()
        {
            //remove o último elemento da ET
            if (et != null)
            {
                if (et.prox == null)
                    et = null;
                else
                {
                    NoEdgeTable aux = et;
                    NoEdgeTable ant = aux;
                    while (aux.prox != null) //vai chegar no último nó da lista
                    {
                        ant = aux;
                        aux = aux.prox;
                    }
                    ant.prox = null;
                }
            }

        }

        public void RemoveAt(int pos)
        {
            //remove o no da et na posição pos
            if (pos > -1 && pos < Count()) //para garantir que está dentro do range
            {
                if (pos == 0) //tira a primeira posição
                {
                    et = et.prox;
                }
                else
                {
                    NoEdgeTable ant = et;
                    NoEdgeTable aux = et.prox;
                    int posicao = 1;
                    while (aux != null && posicao < pos + 1)
                    {
                        ant = aux;
                        aux = aux.prox;
                        posicao++;
                    }
                    ant.prox = aux.prox;
                }
            }
        }
    }
}
