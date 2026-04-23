using System.Drawing;

namespace ProcessamentoImagens.classes
{
    internal class Reta
    {
        // Reta adaptada para 3D
        private PointReal Ini { get; set; }
        private PointReal Fim { get; set; }

        public Reta()
        {
            // inicializando os pontos da minha reta
            Ini = new PointReal(-1,-1,-1);
            Fim = new PointReal(-1,-1,-1);
        }

        public Reta(PointReal ini, PointReal fim)
        {
            this.Ini = ini;
            this.Fim = fim;
        }

        public PointReal GetIni()
        {
            return Ini;
        }

        public PointReal GetFim()
        {
            return Fim;
        }

        //vertice inicial
        public double GetIniX()
        {
            return Ini.X;
        }
        public double GetIniY()
        {
            return Ini.Y;
        }

        public double GetIniZ()
        {
            return Ini.Z;
        }

        //vertice final
        public double GetFimX()
        {
            return Fim.X;
        }

        public double GetFimY()
        {
            return Fim.Y;
        }

        public double GetFimZ()
        {
            return Fim.Z;
        }

        // usado para pintar o polígono
        //public int GetYMin()
        //{
        //    if(Ini.Y < Fim.Y)
        //        return Ini.Y;
            
        //    if(Fim.Y < Ini.Y)
        //        return Fim.Y;

        //    return Ini.Y; //vai retornar aqui caso os dois forem iguais -> empate
        //}

        //public int GetYMax()
        //{
        //    if(Ini.Y > Fim.Y)
        //        return Ini.Y;
            
        //    if(Fim.Y > Ini.Y)
        //        return Fim.Y;

        //    return Ini.Y; //vai retornar aqui caso os dois forem iguais -> empate
        //}

        //public int GetXMin()
        //{
        //    //primeiro preciso descobrir qual dos Y é maior
        //    if(Ini.Y < Fim.Y)
        //        return Ini.X;
            
        //    if(Fim.Y < Ini.Y)
        //        return Fim.X;

        //    //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
        //    if(Ini.X < Fim.X)
        //        return Ini.X;

        //    if(Fim.X < Ini.X)
        //        return Fim.X;

        //    // vem nesse return se os dois pontos são exatamente iguais
        //    return Ini.X;
        //}

        //public int GetXMax()
        //{
        //    //primeiro preciso descobrir qual dos Y é maior
        //    if(Ini.Y > Fim.Y)
        //        return Ini.X;
            
        //    if(Fim.Y > Ini.Y)
        //        return Fim.X;

        //    //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
        //    if(Ini.X > Fim.X)
        //        return Ini.X;

        //    if(Fim.X > Ini.X)
        //        return Fim.X;

        //    // vem nesse return se os dois pontos são exatamente iguais
        //    return Ini.X;
        //}
    }
}
