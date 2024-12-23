﻿using System;
using System.Drawing;

namespace apProjetoListaLigada
{
    class Reta : Ponto
    {
        private Ponto pontoFinal;
        private int espessura;
        public Reta(int x1, int x2, int y1, int y2, Color novaCor) : base(x1, y1, novaCor) 
        {
            pontoFinal = new Ponto(x2, y2, novaCor);
        
        }

        public override void desenhar(Color corDesenho, Graphics g, int espessura)
        {
            this.espessura = espessura;
            Pen pen = new Pen(corDesenho, espessura);
            g.DrawLine(pen, base.X, pontoFinal.X, base.Y, pontoFinal.Y);
            //g.DrawLine(pen, base.X, base.Y, pontoFinal.X, pontoFinal.Y);
        }
        public override string ToString()
        {
            return transformaString("l", 5) +
                   transformaString(base.X, 5) +
                   transformaString(base.Y, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5) +
                   transformaString(pontoFinal.X, 5) +
                   transformaString(pontoFinal.Y, 5) +
                   transformaString(espessura, 5);
        }
    }
}
