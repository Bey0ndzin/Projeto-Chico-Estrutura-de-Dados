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
            foreach(Ponto p in pontosDaPoli.Lista())
            {
                if (inicio == null)
                    inicio = p;
                else
                {
                    fim = p;
                    g.DrawLine(pen, inicio.X, inicio.Y, fim.X, fim.Y);
                    inicio = fim;
                    if (p == pontosDaPoli.Ultimo.Info)
                    {
                        fim = pontosDaPoli.Primeiro.Info;
                        g.DrawLine(pen, inicio.X, inicio.Y, fim.X, fim.Y);
                    }
                }
            }
        }
        public override string ToString()
        {
            string listaPontos = "";
            foreach (Ponto p in pontosDaPoli.Lista())
            {
                listaPontos += transformaString("g", 5) +
                               transformaString(p.X, 5) +
                               transformaString(p.Y, 5) +
                               transformaString(p.Cor.R, 5) +
                               transformaString(p.Cor.G, 5) +
                               transformaString(p.Cor.B, 5) +
                               transformaString(espessura, 5) + "\n";
            }
            listaPontos += transformaString("k", 5) +
                           transformaString(0, 5) +
                           transformaString(0, 5) +
                           transformaString(0, 5) +
                           transformaString(0, 5) +
                           transformaString(0, 5) +
                           transformaString(0, 5) + "\n";
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
