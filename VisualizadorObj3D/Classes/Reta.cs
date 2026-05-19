
using ProcessamentoImagens.Classes;

namespace ProcessamentoImagens.classes
{
    internal class Reta
    {
        // Reta adaptada para 3D
        private PointInteiro Ini { get; set; }
        private PointInteiro Fim { get; set; }

        public Reta()
        {
            // inicializando os pontos da minha reta
            Ini = new PointInteiro(-1,-1,-1);
            Fim = new PointInteiro(-1,-1,-1);
        }

        public Reta(PointInteiro ini, PointInteiro fim)
        {
            this.Ini = ini;
            this.Fim = fim;
        }

        public PointInteiro GetIni()
        {
            return Ini;
        }

        public PointInteiro GetFim()
        {
            return Fim;
        }

        //vertice inicial
        public int GetIniX()
        {
            return Ini.X;
        }
        public int GetIniY()
        {
            return Ini.Y;
        }

        public int GetIniZ()
        {
            return Ini.Z;
        }

        //vertice final
        public int GetFimX()
        {
            return Fim.X;
        }

        public int GetFimY()
        {
            return Fim.Y;
        }

        public int GetFimZ()
        {
            return Fim.Z;
        }

        //usado para pintar o polígono
        public int GetYMin()
        {
            if (Ini.Y < Fim.Y)
                return Ini.Y;

            if (Fim.Y < Ini.Y)
                return Fim.Y;

            return Ini.Y; //vai retornar aqui caso os dois forem iguais -> empate
        }

        public int GetYMax()
        {
            if (Ini.Y > Fim.Y)
                return Ini.Y;

            if (Fim.Y > Ini.Y)
                return Fim.Y;

            return Ini.Y; //vai retornar aqui caso os dois forem iguais -> empate
        }

        public int GetXMin()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y < Fim.Y)
                return Ini.X;

            if (Fim.Y < Ini.Y)
                return Fim.X;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.X < Fim.X)
                return Ini.X;

            if (Fim.X < Ini.X)
                return Fim.X;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.X;
        }

        public int GetXMax()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y > Fim.Y)
                return Ini.X;

            if (Fim.Y > Ini.Y)
                return Fim.X;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.X > Fim.X)
                return Ini.X;

            if (Fim.X > Ini.X)
                return Fim.X;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.X;
        }
        public int GetZMin()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y < Fim.Y)
                return Ini.Z;

            if (Fim.Y < Ini.Y)
                return Fim.Z;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.Z < Fim.Z)
                return Ini.Z;

            if (Fim.Z < Ini.Z)
                return Fim.Z;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.Z;
        }
        public int GetZMax()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y > Fim.Y)
                return Ini.Z;

            if (Fim.Y > Ini.Y)
                return Fim.Z;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.Z > Fim.Z)
                return Ini.Z;

            if (Fim.Z > Ini.Z)
                return Fim.Z;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.Z;
        }
    }
    
}
