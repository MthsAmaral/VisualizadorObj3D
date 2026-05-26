using VisualizadorObj3D.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizadorObj3D.Classes
{
    public static class Projecao
    {

        public static List<PointReal> Projetar(List<PointReal> verticesAtuais, char tipoProjecao)
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

            //frontal superior ou lateral
            if (tipoProjecao == 'f' || tipoProjecao == 's' || tipoProjecao == 'l')
            {
                return Ortografica(verticesAtuais, tipoProjecao);
            }
            else if (tipoProjecao == 'c' || tipoProjecao == 'b')
            {
                return Obliqua(verticesAtuais, tipoProjecao);
            }
            else if (tipoProjecao == 'p')
            {
                return Perspectiva1Ponto(verticesAtuais, Form1.distanciaFocal);//d=200
            }
            else
            {
                List<PointReal> copia = new List<PointReal>();
                foreach (PointReal p in verticesAtuais)
                {
                    copia.Add(new PointReal(p.X, p.Y, p.Z));
                }
                return copia;
            }
        }



        private static List<PointReal> Ortografica(List<PointReal> verticesAtuais, char c)
        {

            List<PointReal> projetados = new List<PointReal>();
            for (int i = 0; i < verticesAtuais.Count; i++)
            {
                PointReal pontoReal = verticesAtuais[i];
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

                projetados.Add(ponto);
            }
            return projetados;
        }


        //projeção obliqua
        private static List<PointReal> Obliqua(List<PointReal> verticesAtuais, char op)
        {
            List<PointReal> vProjetados = new List<PointReal>();
            double l, angulo;

            if (op == 'c') //cavaleira
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

            foreach (PointReal p in verticesAtuais)
            {
                PointReal projetado = new PointReal();

                projetado.X = p.X + p.Z * l * cos;
                projetado.Y = p.Y + p.Z * l * sin;
                projetado.Z = 0;

                vProjetados.Add(projetado);
            }
            return vProjetados;
        }


        private static List<PointReal> Perspectiva1Ponto(List<PointReal> verticesAtuais, double d)
        {
            List<PointReal> vProjetados = new List<PointReal>();

            foreach (PointReal p in verticesAtuais)
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

                vProjetados.Add(projetado);
            }
            return vProjetados;
        }




        // VETOR DE OBSERVAÇÃO PARA ELIMINAÇÃO DE FACES OCULTAS
        public static PointReal ObterVetorObservacao(PointReal pontoFace, char tipoProjecao)
        {
            switch (tipoProjecao)
            {
                case 'f': // ortográfica frontal no plano XY
                    return new PointReal(0, 0, -1);

                case 'l': // ortográfica lateral
                    return new PointReal(-1, 0, 0);

                case 's': // ortográfica superior
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
                        double alpha = 63.4 * Math.PI / 180.0;
                        return new PointReal(l * Math.Cos(alpha), l * Math.Sin(alpha), -1);
                    }

                case 'p': // perspectiva: observador na origem
                    {
                        double distanciaCamera = 400.0;

                        // Aplica o mesmo empurrão em z que a projeção faz
                        PointReal pontoCamera = new PointReal(
                            pontoFace.X,
                            pontoFace.Y,
                            pontoFace.Z + distanciaCamera
                        );

                        return new PointReal(pontoCamera.X, pontoCamera.Y, pontoCamera.Z);
                    }

                default://assume frontal
                    return new PointReal(0, 0, 1);
            }
        }
    }
}
