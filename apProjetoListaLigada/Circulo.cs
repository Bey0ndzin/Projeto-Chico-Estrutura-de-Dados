using System;
using System.Drawing;
using System.Threading;

namespace apProjetoListaLigada
{
    class Circulo : Ponto
    {
        int raio, espessura;

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

        public override void desenhar(Color cor, Graphics g, int espessura)
        {
            this.espessura = espessura;
            Pen pen = new Pen(cor, espessura);
            //g.DrawEllipse(pen, base.X - raio, 2 * raio, base.Y - raio, 2 * raio);
            g.DrawEllipse(pen, base.X - raio, base.Y - raio, 2*raio, 2*raio);
        }

        public String transformaString(int valor, int qntPosicao)
        {
            String cadeia = valor + "";
            while (cadeia.Length < qntPosicao)
                cadeia = "0" + cadeia;
            return cadeia.Substring(0, qntPosicao);
        }
        public String transformaString(String valor, int qntPosicao)
        {
            String cadeia = valor + "";
            while (cadeia.Length < qntPosicao)
                cadeia = cadeia + " ";
            return cadeia.Substring(0, qntPosicao);
        }
        public override string ToString()
        {
            return transformaString("c", 5) +
                   transformaString(base.X, 5) +
                   transformaString(base.Y, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5) +
                   transformaString(raio, 5) +
                   transformaString(espessura, 5);
        }
    }
}
