using System;
using System.Drawing;
using System.Threading;

namespace apProjetoListaLigada
{
    class Circulo : Ponto
    {
        int raio;

        public int Raio
        {
            get => raio;
        }

        public Circulo(int xCentro, int yCentro, int novoRaio, Color novaCor) : base(xCentro, yCentro, novaCor)
        {
            raio = novoRaio;
        }

        public void setRaio(int novoRaio)
        {
            raio = novoRaio;
        }

        public override void desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            //g.DrawEllipse(pen, base.X - raio, 2 * raio, base.Y - raio, 2 * raio);
            g.DrawEllipse(pen, base.X - raio, base.Y - raio, 2*raio, 2*raio);
        }
    }
}
