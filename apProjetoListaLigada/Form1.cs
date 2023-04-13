using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apProjetoListaLigada
{   
    public partial class frmGrafico : Form
    {
        //Váriaveis de espera
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

        //Várivel global de espessura, x e y(para guardar e.X e e.Y), váriavel de paint(para fazer preview)
        int espessura = 1;
        bool paint = false;
        int poliPrimX;
        int poliPrimY;
        int x, y;

        //Bitmap e Grafico para salvar como Imagem
        Bitmap bm;
        Graphics grafico;

        //Lista Simples de figuras para guardar cada forma
        ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        //Polilinha (armazena uma Lista Simples de Pontos)
        private Polilinha poli;
        //Cor atual para pintar as formas
        Color corAtual = Color.Black;
        //P1 para armazenar o ponto inicial de alguma forma
        private static Ponto p1 = new Ponto(0, 0, Color.Black);
        public frmGrafico()
        {
            InitializeComponent();
            //Inicializando as váriaveis importantes
            bm = new Bitmap(pbAreaDesenho.Width, pbAreaDesenho.Height);
            grafico = Graphics.FromImage(bm);
            grafico.Clear(Color.White);
            pbAreaDesenho.Image = bm;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if(dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader arqFiguras = new StreamReader(dlgAbrir.FileName);
                    int espessuraPoli = 1;

                    while (!arqFiguras.EndOfStream)
                    {
                        String linha = arqFiguras.ReadLine();
                        if(linha != "")
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
                                    int espessuraP = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    figuras.InserirAposFim(new NoLista<Ponto>(new Ponto(xBase, yBase, cor), null));
                                    Ponto novoPonto = new Ponto(xBase, yBase, cor);
                                    novoPonto.desenhar(novoPonto.Cor, grafico, espessuraP);
                                    break;
                                case 'l':
                                    int xFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int yFinal = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    int espessuraR = Convert.ToInt32(linha.Substring(40, 5).Trim());
                                    figuras.InserirAposFim(new NoLista<Ponto>(new Reta(xBase, xFinal, yBase, yFinal, cor), null));
                                    Reta novaLinha = new Reta(xBase, xFinal, yBase, yFinal, cor);
                                    novaLinha.desenhar(novaLinha.Cor, grafico, espessuraR);
                                    break;
                                case 'c':
                                    int raio = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int espessuraC = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    figuras.InserirAposFim(new NoLista<Ponto>(new Circulo(xBase, yBase, raio, cor), null));
                                    Circulo novoCirculo = new Circulo(xBase, yBase, raio, cor);
                                    novoCirculo.desenhar(novoCirculo.Cor, grafico, espessuraC);
                                    break;
                                case 'e':
                                    int raioX = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int raioY = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    int espessuraE = Convert.ToInt32(linha.Substring(40, 5).Trim());
                                    figuras.InserirAposFim(new NoLista<Ponto>(new Elipse(xBase, yBase, raioX, raioY, cor), null));
                                    Elipse novaElipse = new Elipse(xBase, yBase, raioX, raioY, cor);
                                    novaElipse.desenhar(novaElipse.Cor, grafico, espessuraE);
                                    break;
                                case 'r':
                                    int xFinalRet = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int yFinalRet = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    int espessuraRet = Convert.ToInt32(linha.Substring(40, 5).Trim());
                                    figuras.InserirAposFim(new NoLista<Ponto>(new Retangulo(xBase, xFinalRet, yBase, yFinalRet, cor), null));
                                    Retangulo novoRet = new Retangulo(xBase, xFinalRet, yBase, yFinalRet, cor);
                                    novoRet.desenhar(novoRet.Cor, grafico, espessuraRet);
                                    break;
                                case 'g':
                                    if (poli == null)
                                        poli = new Polilinha(0, 0, corAtual);
                                    espessuraPoli = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    poli.adicionarPonto(new Ponto(xBase, yBase, corAtual));
                                    break;
                                case 'k':
                                    figuras.InserirAposFim(poli);
                                    poli.desenhar(corAtual, grafico, espessuraPoli);
                                    poli = null;
                                    break;
                            }

                            this.Text = dlgAbrir.FileName;
                            pbAreaDesenho.Invalidate();
                        }
                    }
                    arqFiguras.Close();
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

            if (paint)
            {
                if (esperaFimReta)
                {
                    Reta novaLinha = new Reta(p1.X, p1.Y, x, y, corAtual);
                    novaLinha.desenhar(novaLinha.Cor, g, espessura); ;
                }
                else if (esperaFimCirculo)
                {
                    int dx = x - p1.X;
                    int dy = y - p1.Y;
                    int raio = (int)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)) / 2;

                    int meioX = p1.X + dx / 2;
                    int meioY = p1.Y + dy / 2;

                    Circulo novoCirculo = new Circulo(meioX, meioY, raio, corAtual);
                    novoCirculo.desenhar(novoCirculo.Cor, g, espessura);
                }
                else if (esperaFimElipse)
                {
                    int raioX = Math.Abs(x - p1.X);
                    int raioY = Math.Abs(y - p1.Y);

                    Elipse novaElipse = new Elipse(p1.X, p1.Y, raioX, raioY, corAtual);

                    novaElipse.desenhar(novaElipse.Cor, g, espessura);
                }
                else if (esperaFimRetangulo)
                {
                    int largura;
                    int altura;
                    Retangulo novoRet = null;
                    if (x >= p1.X && y >= p1.Y)
                    {
                        largura = x - p1.X;
                        altura = y - p1.Y;
                        novoRet = new Retangulo(p1.X, p1.Y, largura, altura, corAtual);
                    }
                    else if (x >= p1.X && y <= p1.Y)
                    {
                        largura = x - p1.X;
                        altura = p1.Y - y;
                        novoRet = new Retangulo(p1.X, y, largura, altura, corAtual);
                    }
                    else if (x <= p1.X && y >= p1.Y)
                    {
                        largura = p1.X - x;
                        altura = y - p1.Y;
                        novoRet = new Retangulo(x, p1.Y, largura, altura, corAtual);
                    }
                    else if (x <= p1.X && y <= p1.Y)
                    {
                        largura = p1.X - x;
                        altura = p1.Y - y;
                        novoRet = new Retangulo(x, y, largura, altura, corAtual);
                    }
                    novoRet.desenhar(novoRet.Cor, g, espessura);
                }
                else if (esperaFimPolilinha)
                {
                    Reta novaLinha = new Reta(p1.X, p1.Y, x, y, corAtual);
                    novaLinha.desenhar(novaLinha.Cor, g, espessura);
                }
            }
        }

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = e.X + "," + e.Y;


            x = e.X;
            y = e.Y;

            pbAreaDesenho.Refresh();
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
        }


        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            paint = true;
            if (esperaPonto)
            {
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novoPonto, null));
                novoPonto.desenhar(novoPonto.Cor, grafico, espessura);
                stMensagem.Items[1].Text = "clique no local do ponto desejado!";
                limparEsperas();
                esperaPonto = true;
            }
            else if(esperaInicioReta)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioReta = false;
                esperaFimReta = true;
                stMensagem.Items[1].Text = "clique no ponto final da reta";
            }
            else if(esperaFimReta)
            {
                paint = false;
                x = e.X;
                y = e.Y;
                esperaFimReta = false;
                Reta novaLinha = new Reta(p1.X, p1.Y, e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.desenhar(novaLinha.Cor, grafico, espessura);;
                stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta";
                limparEsperas();
                esperaInicioReta = true;
            }
            else if (esperaInicioCirculo)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioCirculo = false;
                esperaFimCirculo = true;
                stMensagem.Items[1].Text = "Clique no local do ponto final do círculo";
            }
            else if (esperaFimCirculo)
            {
                paint = false;

                int dx = x - p1.X;
                int dy = y - p1.Y;
                int raio = (int)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)) / 2;

                int meioX = p1.X + dx / 2;
                int meioY = p1.Y + dy / 2;

                Circulo novoCirculo = new Circulo(meioX, meioY, raio, corAtual);

                figuras.InserirAposFim(new NoLista<Ponto>(novoCirculo, null));
                novoCirculo.desenhar(novoCirculo.Cor, grafico, espessura);
                stMensagem.Items[1].Text = "Clique no local do ponto inicial do círculo";
                limparEsperas();
                esperaInicioCirculo = true;
            }
            else if (esperaInicioElipse)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioElipse = false;
                esperaFimElipse = true;
                stMensagem.Items[1].Text = "Clique no local do ponto final da Elipse";
            }
            else if (esperaFimElipse)
            {
                paint = false;
                x = e.X;
                y = e.Y;
                esperaFimElipse = false;
                int raioX = Math.Abs(e.X - p1.X);
                int raioY = Math.Abs(e.Y - p1.Y);

                Elipse novaElipse = new Elipse(p1.X, p1.Y, raioX, raioY, corAtual);

                figuras.InserirAposFim(new NoLista<Ponto>(novaElipse, null));
                novaElipse.desenhar(novaElipse.Cor, grafico, espessura);
                stMensagem.Items[1].Text = "Clique no local do ponto inicial do círculo";
                limparEsperas();
                esperaInicioElipse = true;
            }
            else if (esperaInicioRetangulo)
            {
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioRetangulo = false;
                esperaFimRetangulo = true;
                stMensagem.Items[1].Text = "clique no ponto final do retangulo";
            }
            else if (esperaFimRetangulo)
            {
                paint = false;
                x = e.X;
                y = e.Y;
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
                figuras.InserirAposFim(new NoLista<Ponto>(novoRet, null));
                novoRet.desenhar(novoRet.Cor, grafico, espessura);
                stMensagem.Items[1].Text = "Clique no local do ponto inicial do retangulo";
                limparEsperas();
                esperaInicioRetangulo = true;
            }
            else if (esperaInicioPolilinha)
            {
                poli.adicionarPonto(new Ponto(e.X, e.Y, corAtual));
                poliPrimX = e.X;
                poliPrimY = e.Y;

                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaInicioPolilinha = false;
                esperaFimPolilinha = true;
                stMensagem.Items[1].Text = "clique no ponto final da polilinha";
                numericUpDown1.Enabled = false;
            }
            else if (esperaFimPolilinha)
            {
                //paint = false;
                poli.adicionarPonto(new Ponto(e.X, e.Y, corAtual));
                x = e.X;
                y = e.Y;
                Reta novaLinha = new Reta(p1.X, p1.Y, x, y, corAtual);
                novaLinha.desenhar(novaLinha.Cor, grafico, espessura);
                p1.X = x;
                p1.Y = y;
                stMensagem.Items[1].Text = "Dois cliques para finalizar polilinha";
                if (poliPrimX - e.X <= espessura && poliPrimX - e.X - espessura >= 0 && poliPrimY - e.Y <= espessura && poliPrimY - e.Y >= 0)
                {
                    limparEsperas();
                    stMensagem.Items[1].Text = "Polilinha finalizada!";
                    esperaInicioPolilinha = true;
                    if(!poli.EstaVazia())
                    {
                        figuras.InserirAposFim(poli);
                    }
                    numericUpDown1.Enabled = true;
                }
                else if (e.X - poliPrimX <= espessura && e.X - poliPrimX >= 0 && e.Y - poliPrimY <= espessura && e.Y - poliPrimY >= 0)
                {
                    limparEsperas();
                    stMensagem.Items[1].Text = "Polilinha finalizada!";
                    esperaInicioPolilinha = true;
                    if (!poli.EstaVazia())
                    {
                        figuras.InserirAposFim(poli);
                    }
                    numericUpDown1.Enabled = true;
                }
            }

            pbAreaDesenho.Refresh();
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
            poli = new Polilinha(0, 0, corAtual);
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da Polilinha";
            limparEsperas();
            if(esperaFimPolilinha == true)
            {
                stMensagem.Items[1].Text = "Polilinha finalizada!";
                Reta novaLinha = new Reta(poliPrimX, poliPrimY, p1.X, p1.Y, corAtual);
                novaLinha.desenhar(novaLinha.Cor, grafico, espessura);
                pbAreaDesenho.Refresh();
                limparEsperas();
                esperaInicioPolilinha = true;
                if (!poli.EstaVazia())
                {
                    figuras.InserirAposFim(poli);
                    /*foreach(Ponto p in poli.Listar())
                        figuras.InserirAposFim(p);*/
                }
                numericUpDown1.Enabled = true;
            }
            esperaInicioPolilinha = true;
        }

        private void pbAreaDesenho_DoubleClick(object sender, EventArgs e)
        {
            if(esperaFimPolilinha)
            {
                paint = false;
                stMensagem.Items[1].Text = "Polilinha finalizada!";
                Reta novaLinha = new Reta(poliPrimX, poliPrimY, p1.X, p1.Y, corAtual);
                novaLinha.desenhar(novaLinha.Cor, grafico, espessura);
                pbAreaDesenho.Refresh();
                limparEsperas();
                esperaInicioPolilinha = true;
                if (!poli.EstaVazia())
                {
                    figuras.InserirAposFim(poli);
                    /*foreach (Ponto p in poli.Listar())
                        figuras.InserirAposFim(p);*/
                }
                numericUpDown1.Enabled = true;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir tudo?", "Confirmação", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                figuras.ExcluirTodosNos();
                grafico.Clear(Color.White);
                pbAreaDesenho.Refresh();
            }
        }

        private void btnCor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
                corAtual = colorDlg.Color;
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            espessura = int.Parse(numericUpDown1.Value.ToString()) ;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dlgSalvar3.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (dlgSalvar3.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = bm.Clone(new Rectangle(0, 0, pbAreaDesenho.Width, pbAreaDesenho.Height), bm.PixelFormat);
                bit.Save(dlgSalvar3.FileName, ImageFormat.Jpeg);
                MessageBox.Show("Arquivo salvo com sucesso", "Arquivo salvo");
            }
        }

        private void btnSalvarTexto_Click(object sender, EventArgs e)
        {
            dlgSalvar3.Filter = "Text Files | *.txt";
            if (dlgSalvar3.ShowDialog() == DialogResult.OK)
            {
                figuras.Salvar(dlgSalvar3.FileName);
                MessageBox.Show("Arquivo salvo com sucesso", "Arquivo salvo");
            }
        }
    }
}
