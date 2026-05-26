using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace ProcessamentoImagens.classes
{
    public class PointReal
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public PointReal VetorN { get; set; }
        public PointReal VetorE { get; set; }
        public PointReal VetorL { get; set; }
        public PointReal VetorH { get; set; }

        public PointReal()
        {
            X = Y = Z = -1;
        }

        public PointReal(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // ==============================================================================
        // FUNÇÕES PARA O CÁLCULO DOS VETORES DO VÉRTICE

      
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
            //VetorE = CalcularDivisaoModulo(PontoObs, CalcularVetorModulo(PontoObs));
            VetorE = new PointReal(0, 0, -1);
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
     
            double produtoEscalarLN = CalcularProdutoEscalar(VetorL, VetorN);
            double k_dR = kd * corObjetoNormalR * corLuzNormalR * produtoEscalarLN;
            double k_dG = kd * corObjetoNormalG * corLuzNormalG * produtoEscalarLN;
            double k_dB = kd * corObjetoNormalB * corLuzNormalB * produtoEscalarLN;

            double produtoEscalarHN = CalcularProdutoEscalar(VetorH, VetorN);
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
            if (valor > 255)
                return 255;
            if (valor < 0) 
                return 0;
            return (int) valor;
        }
        public void CalcularVetorNormalVertice(List<Face> facesAdjacentes)
        {
            double somaX = 0;
            double somaY = 0;
            double somaZ = 0;
            
            // 1. Soma as normais de todas as faces que tocam neste vértice
            foreach (Face faceVizinha in facesAdjacentes)
            {
                // Pega a normal da face vizinha (garanta que a normal dela já foi calculada antes!)
                somaX += faceVizinha.VetorN.X;
                somaY += faceVizinha.VetorN.Y;
                somaZ += faceVizinha.VetorN.Z;
            }

            // 2. Cria o vetor resultante da soma
            VetorN = new PointReal(somaX, somaY, somaZ);

            // 3. Calcula o módulo e normaliza (o mesmo processo que você já faz para a luz)
            double moduloN = Math.Sqrt(Math.Pow(VetorN.X, 2) + Math.Pow(VetorN.Y, 2) + Math.Pow(VetorN.Z, 2));

            if (moduloN != 0)
            {
                VetorN = new PointReal(VetorN.X / moduloN, VetorN.Y / moduloN, VetorN.Z / moduloN);
            }
            else
            {
                VetorN = new PointReal(0, 0, 1); // Trava de segurança contra o NaN
            }
        }
        
    }
}
