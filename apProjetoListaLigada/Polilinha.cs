using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apProjetoListaLigada
{
    class Polilinha : Ponto
    {
        private ListaSimples<Ponto> pontosDaPoli;
        private int espessura;
        public Polilinha(int x1, int y1, Color novaCor) : base(x1, y1, novaCor)
        {
            pontosDaPoli = new ListaSimples<Ponto>();
        }

        public override void desenhar(Color corDesenho, Graphics g, int espessura)
        {
            this.espessura = espessura;
            Pen pen = new Pen(corDesenho, espessura);
            Ponto inicio = null, fim = null;
            pontosDaPoli.IniciarPercurso();
            while(pontosDaPoli.Percorrer())
            {
                if (inicio == null)
                    inicio = pontosDaPoli.Atual.Info;
                else
                {
                    fim = pontosDaPoli.Atual.Info;
                    g.DrawLine(pen, inicio.X, inicio.Y, fim.X, fim.Y);
                    inicio = fim = null;
                }
            }
        }
        public override string ToString()
        {
            return transformaString("g", 5) +
                   transformaString(base.X, 5) +
                   transformaString(base.Y, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5) +
                   transformaString(espessura, 5);
        }
        public void adicionarPonto(Ponto p)
        {
            pontosDaPoli.InserirAposFim(p);
        }
        public bool EstaVazia()
        {
            if (pontosDaPoli.EstaVazia)
                return false;
            return true;
        }
    }
}
