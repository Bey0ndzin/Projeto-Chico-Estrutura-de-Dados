using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace apProjetoListaLigada
{
    class ListaSimples<Ponto> where Ponto : IComparable<Ponto>
    {
        NoLista<Ponto> atual, anterior, primeiro, ultimo;
        int quantosNos;

        public ListaSimples()
        {
            primeiro = ultimo = anterior = atual = null;
            quantosNos = 0;
        }

        public bool EstaVazia
        {
            get => primeiro == null;
        }

        public int QuantosNos
        {
            get => quantosNos;
        }

        public NoLista<Ponto> Atual { get => atual; }
        public NoLista<Ponto> Anterior { get => anterior; }
        public NoLista<Ponto> Ultimo { get => ultimo; }
        public NoLista<Ponto> Primeiro { get => primeiro; }

        public List<Ponto> Lista()
        {
            var lista = new List<Ponto>();
            atual = primeiro;
            while (atual != null)
            {
                lista.Add(atual.Info);
                atual = atual.Prox;
            }
            return lista;
        }

        public void InserirAntesDoInicio(Ponto novoPonto)
        {
            var novoNo = new NoLista<Ponto>(novoPonto);
            if (EstaVazia)          // se a lista está vazia, estamos
                ultimo = novoNo;    // incluindo o 1o e o último nós!

            novoNo.Prox = primeiro;
            primeiro = novoNo;
            quantosNos++;
        }

        public void InserirAposFim(Ponto novoPonto)
        {
            var novoNo = new NoLista<Ponto>(novoPonto);
            if (EstaVazia)
                primeiro = novoNo;
            else
                ultimo.Prox = novoNo;

            ultimo = novoNo;
            ultimo.Prox = null;
            quantosNos++;
        }

        public void InserirAposFim(NoLista<Ponto> noExistente)
        {
            if (EstaVazia)
                primeiro = noExistente;
            else
                ultimo.Prox = noExistente;

            ultimo = noExistente;
            ultimo.Prox = null;

            quantosNos++;
        }
        public bool ExistePonto(Ponto procurado)
        {
            anterior = atual = null;
            if (!EstaVazia)
            {
                if (procurado.CompareTo(primeiro.Info) < 0)
                    return false;
                else if (procurado.CompareTo(ultimo.Info) > 0)
                {
                    anterior = ultimo;
                    return false;
                }
                atual = primeiro;
                bool achou = false;
                bool fim = false;
                while (!achou && !fim)
                {
                    if (atual == null)
                        fim = true;
                    /*else if (atual.Info.CompareTo(procurado) > 0)
                        fim = true;*/
                    else if (atual.Info.CompareTo(procurado) == 0)
                        achou = true;
                    else
                    {
                        anterior = atual;
                        atual = atual.Prox;
                    }
                }
                return achou;
            }
            return false;
        }
        public Ponto Procurar()
        {
            return atual.Info;
        }
        public void InserirEmOrdem(Ponto Pontos)
        {
            if (EstaVazia)
                InserirAntesDoInicio(Pontos);

            else if (Pontos.CompareTo(primeiro.Info) < 0)
                InserirAntesDoInicio(Pontos);

            else if (Pontos.CompareTo(ultimo.Info) > 0)
                InserirAposFim(Pontos);

            else if (!ExistePonto(Pontos))
            {
                var novo = new NoLista<Ponto>(Pontos, null);
                anterior.Prox = novo;
                novo.Prox = atual;
                if (anterior == ultimo)
                    ultimo = novo;
                quantosNos++;
            }
        }
        public ListaSimples<Ponto> ExcluirNo(Ponto PontoExcluir)
        {
            var novaLista = new ListaSimples<Ponto>();
            if (!EstaVazia)
            {
                if (ExistePonto(PontoExcluir))
                {
                    if (anterior != null)
                        anterior.Prox = atual.Prox;

                    while (atual != null && atual.Prox != null)
                    {
                        atual.Info = atual.Prox.Info;
                        atual = atual.Prox;
                    }
                    atual = primeiro;
                    if (atual == primeiro && atual != ultimo)
                    {
                        while (atual != null)
                        {
                            novaLista.InserirEmOrdem(atual.Info);
                            atual = atual.Prox;
                        }
                    }

                    quantosNos--;
                }
                else
                    return this;
            }
            return novaLista;
        }

        public void ExcluirNo2(Ponto PontoExcluir)
        {
            if (!EstaVazia)
            {
                if (ExistePonto(PontoExcluir))
                {
                    if (anterior != null)
                        anterior.Prox = atual.Prox;

                    while (atual != null && atual.Prox != null)
                    {
                        atual.Info = atual.Prox.Info;
                        atual = atual.Prox;
                    }
                    atual = null;
                    quantosNos--;
                }
            }
        }

        public bool Remover(Ponto PontoARemover)
        {
            if (EstaVazia)
                return false;

            if (ExistePonto(PontoARemover))
            {
                if (atual == primeiro)
                {
                    primeiro = primeiro.Prox;
                    atual = primeiro;
                    if (primeiro == null)
                        ultimo = null;
                    quantosNos--;
                }
                else if (atual == ultimo)
                {
                    ultimo = anterior;
                    ultimo.Prox = null;
                    atual = ultimo;
                    quantosNos--;
                }
                else
                {
                    anterior.Prox = atual.Prox;
                    atual = atual.Prox;
                    quantosNos--;
                }
                return true;
            }
            return false;
        }

    }
}
