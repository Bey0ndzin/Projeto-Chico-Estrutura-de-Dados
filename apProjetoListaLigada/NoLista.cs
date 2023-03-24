using System;
using System.Drawing;

namespace apProjetoListaLigada
{
    class NoLista<Ponto> where Ponto : IComparable<Ponto>
    {
        Ponto info;
        NoLista<Ponto> prox;

        public NoLista(Ponto info, NoLista<Ponto> prox)
        {
            this.info = info;
            this.prox = prox;
        }

        public NoLista(Ponto info) 
        {
            this.info = info;
            prox = null;
        }

        public Ponto Info 
        {
            get => info;
            set => info = value;
        }

        public NoLista<Ponto> Prox
        {
            get => prox;
            set => prox = value;
        }
    }
}
