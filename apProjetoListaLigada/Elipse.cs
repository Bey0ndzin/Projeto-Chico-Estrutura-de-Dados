using System;
using System.Drawing;

namespace apProjetoListaLigada
{
    class Elipse : Ponto
    {
        int raioX, raioY;
        int espessura;

        public Elipse(int xCentro, int yCentro, int raioX, int raioY, Color novaCor) : base(xCentro, yCentro, novaCor)
        {
            this.raioX = raioX;
            this.raioY = raioY;
        }

        public int RaioX
        {
            get => raioX;
            set => raioX = value;
        }
        public int RaioY
        {
            get => raioY;
            set => raioY = value;
        }

        public override void desenhar(Color cor, Graphics g, int espessura)
        {
            this.espessura = espessura;
            Pen pen = new Pen(cor, espessura);
            g.DrawEllipse(pen, base.X - raioX, base.Y - raioY, 2*raioX, 2*raioY);
        }
        public override string ToString()
        {
            return transformaString("e", 5) +
                   transformaString(base.X, 5) +
                   transformaString(base.Y, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5) +
                   transformaString(RaioX, 5) +
                   transformaString(RaioY, 5) +
                   transformaString(espessura, 5);
        }
    }
}
