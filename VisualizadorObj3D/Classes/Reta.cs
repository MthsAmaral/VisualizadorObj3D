using VisualizadorObj3D.Classes;


namespace VisualizadorObj3D.classes
{
    public class Reta
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

        public int GetIniR()
        {
            return Ini.R;
        }
        
        public int GetIniG()
        {
            return Ini.G;
        }
        public int GetIniB()
        {
            return Ini.B;
        }
        public int GetFimR()
        {
            return Fim.R;
        }
        public int GetFimG()
        {
            return Fim.G;
        }
        public int GetFimB()
        {
            return Fim.B;
        }
        public int GetFimNX()
        {
            return Fim.NX;
        }
        public int GetFimNY()
        {
            return Fim.NY;
        }
        public int GetFimNZ()
        {
            return Fim.NZ;
        }
        public int GetIniNX()
        {
            return Ini.NX;
        }
        public int GetIniNY()
        {
            return Ini.NY;
        }
        public int GetIniNZ()
        {
            return Ini.NZ;
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
        public int GetRMin()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y < Fim.Y)
                return Ini.R;

            if (Fim.Y < Ini.Y)
                return Fim.R;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.R < Fim.R)
                return Ini.R;

            if (Fim.R < Ini.R)
                return Fim.R;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.R;
        }
        public int GetGMin()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y < Fim.Y)
                return Ini.G;

            if (Fim.Y < Ini.Y)
                return Fim.G;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.G < Fim.G)
                return Ini.G;

            if (Fim.G < Ini.G)
                return Fim.G;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.G;
        }
        public int GetBMin()
        {
            //primeiro preciso descobrir qual dos Y é maior
            if (Ini.Y < Fim.Y)
                return Ini.B;

            if (Fim.Y < Ini.Y)
                return Fim.B;

            //passa os dois if's anteriores se os y's forem iguais -> na mesma linha
            if (Ini.B < Fim.B)
                return Ini.B;

            if (Fim.B < Ini.B)
                return Fim.B;

            // vem nesse return se os dois pontos são exatamente iguais
            return Ini.B;
        }
    }
    
}
