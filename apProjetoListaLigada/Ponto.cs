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
        private int espessura;

        public Ponto(int x, int y, Color cor)
        {
            this.x = x;
            this.y = y;
            this.cor = cor;
        }

        public int X
        {
            get => x;
            set => x = value;
        }
        
        public int Y
        {
            get => y;
            set => y = value;
        }

        public Color Cor
        { 
            get => cor;
            set => cor = value;
        }
        public virtual void desenhar(Color cor, Graphics g, int espessura)
        {
            this.espessura = espessura;
            Pen pen = new Pen(cor, espessura);
            g.DrawEllipse(pen, x - espessura / 2, y - espessura / 2, espessura, espessura);
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
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5) +
                   transformaString(espessura, 5);
        }
    }
}
