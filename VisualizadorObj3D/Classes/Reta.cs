using System.Drawing;

namespace ProcessamentoImagens.classes
{
    internal class Reta
    {
        private Point Ini { get; set; }
        private Point Fim { get; set; }

        public Reta()
        {
            // inicializando os pontos da minha reta
            Ini = new Point(-1,-1);
            Fim = new Point(-1,-1);
        }

        public Reta(Point ini, Point fim)
        {
            this.Ini = ini;
            this.Fim = fim;
        }

        public Point GetIni()
        {
            return Ini;
        }

        public Point GetFim()
        {
            return Fim;
        }

        public int GetIniX()
        {
            return Ini.X;
        }
        public int GetIniY()
        {
            return Ini.Y;
        }

        public int GetFimX()
        {
            return Fim.X;
        }

        public int GetFimY()
        {
            return Fim.Y;
        }

        public int GetYMin()
        {
            if(Ini.Y < Fim.Y)
                return Ini.Y;
            
            if(Fim.Y < Ini.Y)
                return Fim.Y;

            return Ini.Y; //vai retornar aqui caso os dois forem iguais -> empate
        }

        public int GetYMax()
        {
            if(Ini.Y > Fim.Y)
                return Ini.Y;
            
            if(Fim.Y > Ini.Y)
                return Fim.Y;

            return Ini.Y; //vai retornar aqui caso os dois forem iguais -> empate
        }

        public int GetXMin()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if(Ini.Y < Fim.Y)
                return Ini.X;
            
            if(Fim.Y < Ini.Y)
                return Fim.X;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if(Ini.X < Fim.X)
                return Ini.X;

            if(Fim.X < Ini.X)
                return Fim.X;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.X;
        }

        public int GetXMax()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if(Ini.Y > Fim.Y)
                return Ini.X;
            
            if(Fim.Y > Ini.Y)
                return Fim.X;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if(Ini.X > Fim.X)
                return Ini.X;

            if(Fim.X > Ini.X)
                return Fim.X;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.X;
        }
    }
}
