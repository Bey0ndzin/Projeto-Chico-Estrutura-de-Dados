using System;
using System.Drawing;

namespace apProjetoListaLigada
{
    class Retangulo : Ponto
    {
        private Ponto pontoFinal;
        public Retangulo(int x1, int x2, int y1, int y2, Color novaCor) : base(x1, y1, novaCor)
        {
            pontoFinal = new Ponto(x2, y2, novaCor);

        }

        public void desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawRectangle(pen, base.X, pontoFinal.X, base.Y, pontoFinal.Y);
        }
    }
}
