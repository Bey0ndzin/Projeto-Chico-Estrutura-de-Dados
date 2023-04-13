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
        private static ListaSimples<Ponto> pontosDaPoli;
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
                if (inicio == null && pontosDaPoli.Atual != null)
                    inicio = pontosDaPoli.Atual.Info;
                else
                {
                    if(pontosDaPoli.Atual != null)
                    {
                        fim = pontosDaPoli.Atual.Info;
                        g.DrawLine(pen, inicio.X, inicio.Y, fim.X, fim.Y);
                        inicio = fim;
                    }
                }
            }
        }
        public override string ToString()
        {
            var lista = new List<Ponto>();
            string listaPontos = "";
            pontosDaPoli.IniciarPercurso();
            while(pontosDaPoli.Percorrer())
            {
                lista.Add(pontosDaPoli.Atual.Info);
            }
            /*for (int i = 0; i < pontosDaPoli.QuantosNos; i++)
            {
                pontosDaPoli.Atual = pontosDaPoli.Primeiro;
                for(int v = 0; v < i; v++)
                {
                    if(pontosDaPoli.Atual != null)
                        pontosDaPoli.Atual = pontosDaPoli.Atual.Prox;
                }
                lista.Add(pontosDaPoli.Atual.Info);
            }*/
            foreach (Ponto p in lista)
            {
                listaPontos += transformaString("g", 5) +
                                transformaString(p.X, 5) +
                                transformaString(p.Y, 5) +
                                transformaString(p.Cor.R, 5) +
                                transformaString(p.Cor.G, 5) +
                                transformaString(p.Cor.B, 5) +
                                transformaString(p.Espessura, 5) + "\n";
            }
            return listaPontos;
        }
        public void adicionarPonto(Ponto p)
        {
            pontosDaPoli.InserirAposFim(p);
        }
        public bool EstaVazia()
        {
            if (!pontosDaPoli.EstaVazia)
                return false;
            return true;
        }
        public List<Ponto> Listar()
        {
            var lista = new List<Ponto>();
            pontosDaPoli.IniciarPercurso();
            while(pontosDaPoli.Percorrer())
            {
                lista.Add(pontosDaPoli.Atual.Info);
            }
            return lista;
        }
    }
}
