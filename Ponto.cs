using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace apProjetoListaLigada
{
    class Ponto : IComparable<Ponto>
    {
        private int x, y;
        private Color cor;

        public Ponto(int x, int y, Color cor)
        {
            this.x = x;
            this.y = y;
            this.cor = cor;
        }

        public int X
        {
            get => x;
        }
        
        public int Y
        {
            get => y; 
        }

        public Color Cor
        { 
            get => cor; 
        }

        public void SetCor(Color corNova)
        {
            cor = corNova;
        }
        public void SetX(int X)
        {
            x = X;
        }
        public void SetY(int Y)
        {
            y = Y;
        }


        public virtual void desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawEllipse(pen, x - 1, y - 1, 1, 1);
        }

        public int CompareTo(Ponto outro)
        {
            int difX = X - outro.X;
            if(difX == 0 ) 
                return Y - outro.Y;
            return difX;
        }
        public String transformaString(int valor, int qntPosicao)
        {
            String cadeia = valor + "";
            while (cadeia.Length < qntPosicao)
                cadeia = "0" + cadeia;
            return cadeia.Substring(0, qntPosicao);
        }
        public String transformaString(String valor, int qntPosicao)
        {
            String cadeia = valor + "";
            while (cadeia.Length < qntPosicao)
                cadeia = cadeia + " ";
            return cadeia.Substring(0, qntPosicao);
        }
        public override string ToString()
        {
            return transformaString("p", 5) +
                   transformaString(X, 5) +
                   transformaString(Y, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 6) +
                   transformaString(Cor.B, 5);
        }
    }
}
