using System;
using System.Drawing;

namespace apProjetoListaLigada
{
    class Elipse : Ponto
    {
        int raioX, raioY;

        public Elipse(int xCentro, int yCentro, int raioX, int raioY, Color novaCor) : base(xCentro, yCentro, novaCor)
        {
            this.raioX = raioX;
            this.raioY = raioY;
        }

        public int RaioX
        {
            get => raioX;
        }
        public int RaioY
        {
            get => raioY;
        }

        public void setRaioX(int novoRaio)
        {
            raioX = novoRaio;
        }

        public void setRaioY(int novoRaio)
        {
            raioY = novoRaio;
        }

        public override void desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawEllipse(pen, base.X - raioX, base.Y - raioY, 2*raioX, 2*raioY);
        }
    }
}
