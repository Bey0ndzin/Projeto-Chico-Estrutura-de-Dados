using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apProjetoListaLigada
{   
    public partial class frmGrafico : Form
    {
        bool esperaPonto = false;

        bool esperaInicioReta = false;
        bool esperaFimReta = false;

        bool esperaInicioCirculo = false;
        bool esperaFimCirculo = false;

        bool esperaInicioElipse = false;
        bool esperaFimElipse = false;

        bool esperaInicioRetangulo = false;
        bool esperaFimRetangulo = false;

        bool esperaInicioPolilinha = false;
        bool esperaFimPolilinha = false;
        bool primLinha = false;
        bool fimPoli = false;

        int pXPoli;
        int pYPoli;

        ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        Color corAtual = Color.Black;
        private static Ponto p1 = new Ponto(0, 0, Color.Black);
        public frmGrafico()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if(dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader arqFiguras = new StreamReader(dlgAbrir.FileName);
                    String linha = arqFiguras.ReadLine();
                    Double xInfEsq = Convert.ToDouble(linha.Substring(0, 5).Trim());
                    Double yInfEsq = Convert.ToDouble(linha.Substring(5, 5).Trim());
                    Double xSupDir = Convert.ToDouble(linha.Substring(10, 5).Trim());
                    Double ySupDir = Convert.ToDouble(linha.Substring(15, 5).Trim());

                    while ((linha = arqFiguras.ReadLine()) != null)
                    {
                        String tipo = linha.Substring(0, 5).Trim();
                        int xBase = Convert.ToInt32(linha.Substring(5, 5).Trim());
                        int yBase = Convert.ToInt32(linha.Substring(10, 5).Trim());
                        int corR = Convert.ToInt32(linha.Substring(15, 5).Trim());
                        int corG = Convert.ToInt32(linha.Substring(20, 5).Trim());
                        int corB = Convert.ToInt32(linha.Substring(25, 5).Trim());
                        Color cor = new Color();
                        cor = Color.FromArgb(255, corR, corG, corB);

                        switch (tipo[0])
                        {
                            case 'p':
                                figuras.InserirAposFim(new NoLista<Ponto>(new Ponto(xBase, yBase, cor), null));
                                break;
                            case 'r':
                                int xFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                int yFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                figuras.InserirAposFim(new NoLista<Ponto>(new Reta(xBase, yBase, xFinal, yFinal, cor), null));
                                break;
                            case 'c':
                                int raio = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                figuras.InserirAposFim(new NoLista<Ponto>(new Circulo(xBase, yBase, raio, cor), null));
                                break;
                        }
                        arqFiguras.Close();
                        this.Text = dlgAbrir.FileName;
                        pbAreaDesenho.Invalidate();
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Erro de leitura no arquivo");
                }
            }
        }

        private void pbAreaDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = e.X + "," + e.Y;
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do ponto desejado!";
            limparEsperas();
            esperaPonto = true;
        }

        private void limparEsperas()
        {
            esperaPonto = false;
            esperaInicioReta = false;
            esperaFimReta = false;
            esperaInicioCirculo = false;
            esperaFimCirculo = false;
            esperaInicioElipse = false;
            esperaFimElipse = false;
            esperaInicioRetangulo = false;
            esperaFimRetangulo = false;
            esperaInicioPolilinha = false;
            esperaFimPolilinha = false;
            bool primLinha = false;
            bool fimPoli = false;
        }


        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (esperaPonto)
            {
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novoPonto, null));
                novoPonto.desenhar(novoPonto.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "clique no local do ponto desejado!";
                limparEsperas();
                esperaPonto = true;
            }
            else if(esperaInicioReta)
            {
                p1.SetCor(corAtual);
                p1.SetX(e.X);
                p1.SetY(e.Y);
                esperaInicioReta = false;
                esperaFimReta = true;
                stMensagem.Items[1].Text = "clique no ponto final da reta";
            }
            else if(esperaFimReta)
            {
                esperaInicioReta = false;
                esperaFimReta = false;
                Reta novaLinha = new Reta(p1.X, p1.Y, e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta";
                limparEsperas();
                esperaInicioReta = true;
            }
            else if (esperaInicioCirculo)
            {
                p1.SetCor(corAtual);
                p1.SetX(e.X);
                p1.SetY(e.Y);
                esperaInicioCirculo = false;
                esperaFimCirculo = true;
                stMensagem.Items[1].Text = "Clique no local do ponto final do círculo";
            }
            else if (esperaFimCirculo)
            {
                esperaFimCirculo = false;
                int raioX = Math.Abs(e.X - p1.X);
                int raioY = Math.Abs(e.Y - p1.Y);

                int raio;
                if (raioX >= raioY)
                    raio = raioX;
                else
                    raio = raioY;

                Circulo novoCirculo = new Circulo(p1.X, p1.Y, raio, corAtual);

                figuras.InserirAposFim(new NoLista<Ponto>(novoCirculo, null));
                novoCirculo.desenhar(novoCirculo.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto inicial do círculo";
                limparEsperas();
                esperaInicioCirculo = true;
            }
            else if (esperaInicioElipse)
            {
                p1.SetCor(corAtual);
                p1.SetX(e.X);
                p1.SetY(e.Y);
                esperaInicioElipse = false;
                esperaFimElipse = true;
                stMensagem.Items[1].Text = "Clique no local do ponto final da Elipse";
            }
            else if (esperaFimElipse)
            {
                esperaFimElipse = false;
                int raioX = Math.Abs(e.X - p1.X);
                int raioY = Math.Abs(e.Y - p1.Y);

                Elipse novaElipse = new Elipse(p1.X, p1.Y, raioX, raioY, corAtual);

                figuras.InserirAposFim(new NoLista<Ponto>(novaElipse, null));
                novaElipse.desenhar(novaElipse.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto inicial do círculo";
                limparEsperas();
                esperaInicioElipse = true;
            }
            else if (esperaInicioRetangulo)
            {
                p1.SetCor(corAtual);
                p1.SetX(e.X);
                p1.SetY(e.Y);
                esperaInicioRetangulo = false;
                esperaFimRetangulo = true;
                stMensagem.Items[1].Text = "clique no ponto final do retangulo";
            }
            else if (esperaFimRetangulo)
            {
                esperaInicioRetangulo = false;
                esperaFimRetangulo = false;
                int largura;
                int altura;
                Retangulo novoRet = null;
                if (e.X >= p1.X && e.Y >= p1.Y)
                {
                    largura = e.X - p1.X;
                    altura = e.Y - p1.Y;
                    novoRet = new Retangulo(p1.X, p1.Y, largura, altura, corAtual);
                }
                else if(e.X >= p1.X && e.Y <= p1.Y)
                {
                    largura = e.X - p1.X;
                    altura = p1.Y - e.Y;
                    novoRet = new Retangulo(p1.X, e.Y, largura, altura, corAtual);
                }
                else if (e.X <= p1.X && e.Y >= p1.Y)
                {
                    largura = p1.X - e.X;
                    altura = e.Y - p1.Y;
                    novoRet = new Retangulo(e.X, p1.Y, largura, altura, corAtual);
                }
                else if (e.X <= p1.X && e.Y <= p1.Y)
                {
                    largura = p1.X - e.X;
                    altura = p1.Y - e.Y;
                    novoRet = new Retangulo(e.X, e.Y, largura, altura, corAtual);
                }
                //novoRet = new Retangulo(p1.X, p1.Y, largura, altura, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novoRet, null));
                novoRet.desenhar(novoRet.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto inicial do retangulo";
                limparEsperas();
                esperaInicioRetangulo = true;
            }
            else if (esperaInicioPolilinha)
            {
                if (primLinha)
                {
                    pXPoli = e.X;
                    pYPoli = e.Y;
                }
                p1.SetCor(corAtual);
                p1.SetX(e.X);
                p1.SetY(e.Y);
                esperaInicioPolilinha = false;
                esperaFimPolilinha = true;
                primLinha = false;
                stMensagem.Items[1].Text = "clique no ponto final da polilinha";
            }
            else if (esperaFimPolilinha)
            {
                esperaFimPolilinha = true;
                Reta novaLinha = new Reta(p1.X, p1.Y, e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
                p1.SetX(e.X);
                p1.SetY(e.Y);
                stMensagem.Items[1].Text = "Clique no local do ponto inicial da polilinha";
                if (pXPoli - e.X <= 1 && pXPoli - e.X >= 0 && pYPoli - e.Y <= 1 && pYPoli - e.Y >= 0)
                {
                    limparEsperas();
                    stMensagem.Items[1].Text = "Polilinha finalizada!";
                    fimPoli = true;
                }
                else if (e.X - pXPoli <= 1 && e.X - pXPoli>= 0 && e.Y - pYPoli <= 1 && e.Y - pYPoli >= 0)
                {
                    limparEsperas();
                    stMensagem.Items[1].Text = "Polilinha finalizada!";
                    fimPoli = true;
                }
            }
        }

        private void btnReta_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta";
            limparEsperas();
            esperaInicioReta = true;
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial do círculo";
            limparEsperas();
            esperaInicioCirculo = true;
        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da Elipse";
            limparEsperas();
            esperaInicioElipse = true;
        }

        private void btnRetangulo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial do Retangulo";
            limparEsperas();
            esperaInicioRetangulo = true;
        }

        private void btnPolilinha_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da Polilinha";
            limparEsperas();
            if(fimPoli == false)
            {
                Reta novaLinha = new Reta(p1.X, p1.Y, pXPoli, pYPoli, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
            }
            esperaInicioPolilinha = true;
            primLinha = true;
        }

        private void pbAreaDesenho_DoubleClick(object sender, EventArgs e)
        {
            if(esperaFimPolilinha)
            {
                Reta novaLinha = new Reta(p1.X, p1.Y, pXPoli, pYPoli, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {

        }

        private void btnCor_Click(object sender, EventArgs e)
        {

        }
    }
}
