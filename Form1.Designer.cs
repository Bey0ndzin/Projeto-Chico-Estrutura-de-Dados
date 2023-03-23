namespace apProjetoListaLigada
{
    partial class frmGrafico
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrafico));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.btnPonto = new System.Windows.Forms.ToolStripButton();
            this.btnReta = new System.Windows.Forms.ToolStripButton();
            this.btnCirculo = new System.Windows.Forms.ToolStripButton();
            this.btnElipse = new System.Windows.Forms.ToolStripButton();
            this.btnRetangulo = new System.Windows.Forms.ToolStripButton();
            this.btnPolilinha = new System.Windows.Forms.ToolStripButton();
            this.btnCor = new System.Windows.Forms.ToolStripButton();
            this.btnApagar = new System.Windows.Forms.ToolStripButton();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.pbAreaDesenho = new System.Windows.Forms.PictureBox();
            this.stMensagem = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.dlgSalvar = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAreaDesenho)).BeginInit();
            this.stMensagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrir,
            this.btnSalvar,
            this.btnPonto,
            this.btnReta,
            this.btnCirculo,
            this.btnElipse,
            this.btnRetangulo,
            this.btnPolilinha,
            this.btnCor,
            this.btnApagar,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAbrir
            // 
            this.btnAbrir.AutoSize = false;
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(32, 32);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = false;
            this.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(32, 32);
            this.btnSalvar.Text = "Salvar";
            // 
            // btnPonto
            // 
            this.btnPonto.AutoSize = false;
            this.btnPonto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPonto.Image = ((System.Drawing.Image)(resources.GetObject("btnPonto.Image")));
            this.btnPonto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPonto.Name = "btnPonto";
            this.btnPonto.Size = new System.Drawing.Size(32, 32);
            this.btnPonto.Text = "Ponto";
            this.btnPonto.Click += new System.EventHandler(this.btnPonto_Click);
            // 
            // btnReta
            // 
            this.btnReta.AutoSize = false;
            this.btnReta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReta.Image = ((System.Drawing.Image)(resources.GetObject("btnReta.Image")));
            this.btnReta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReta.Name = "btnReta";
            this.btnReta.Size = new System.Drawing.Size(32, 32);
            this.btnReta.Text = "Reta";
            this.btnReta.Click += new System.EventHandler(this.btnReta_Click);
            // 
            // btnCirculo
            // 
            this.btnCirculo.AutoSize = false;
            this.btnCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCirculo.Image = ((System.Drawing.Image)(resources.GetObject("btnCirculo.Image")));
            this.btnCirculo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(32, 32);
            this.btnCirculo.Text = "Circulo";
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            // 
            // btnElipse
            // 
            this.btnElipse.AutoSize = false;
            this.btnElipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElipse.Image = ((System.Drawing.Image)(resources.GetObject("btnElipse.Image")));
            this.btnElipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElipse.Name = "btnElipse";
            this.btnElipse.Size = new System.Drawing.Size(32, 32);
            this.btnElipse.Text = "Elipse";
            this.btnElipse.Click += new System.EventHandler(this.btnElipse_Click);
            // 
            // btnRetangulo
            // 
            this.btnRetangulo.AutoSize = false;
            this.btnRetangulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRetangulo.Image = ((System.Drawing.Image)(resources.GetObject("btnRetangulo.Image")));
            this.btnRetangulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRetangulo.Name = "btnRetangulo";
            this.btnRetangulo.Size = new System.Drawing.Size(32, 32);
            this.btnRetangulo.Text = "Retangulo";
            this.btnRetangulo.Click += new System.EventHandler(this.btnRetangulo_Click);
            // 
            // btnPolilinha
            // 
            this.btnPolilinha.AutoSize = false;
            this.btnPolilinha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPolilinha.Image = ((System.Drawing.Image)(resources.GetObject("btnPolilinha.Image")));
            this.btnPolilinha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPolilinha.Name = "btnPolilinha";
            this.btnPolilinha.Size = new System.Drawing.Size(32, 32);
            this.btnPolilinha.Text = "Polilinha";
            this.btnPolilinha.Click += new System.EventHandler(this.btnPolilinha_Click);
            // 
            // btnCor
            // 
            this.btnCor.AutoSize = false;
            this.btnCor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCor.Image = ((System.Drawing.Image)(resources.GetObject("btnCor.Image")));
            this.btnCor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(32, 32);
            this.btnCor.Text = "Cor";
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.AutoSize = false;
            this.btnApagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApagar.Image = ((System.Drawing.Image)(resources.GetObject("btnApagar.Image")));
            this.btnApagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(32, 32);
            this.btnApagar.Text = "Apagar";
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = false;
            this.btnSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(32, 32);
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pbAreaDesenho
            // 
            this.pbAreaDesenho.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbAreaDesenho.Location = new System.Drawing.Point(13, 39);
            this.pbAreaDesenho.Name = "pbAreaDesenho";
            this.pbAreaDesenho.Size = new System.Drawing.Size(557, 399);
            this.pbAreaDesenho.TabIndex = 1;
            this.pbAreaDesenho.TabStop = false;
            this.pbAreaDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAreaDesenho_Paint);
            this.pbAreaDesenho.DoubleClick += new System.EventHandler(this.pbAreaDesenho_DoubleClick);
            this.pbAreaDesenho.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbAreaDesenho_MouseClick);
            this.pbAreaDesenho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbAreaDesenho_MouseMove);
            // 
            // stMensagem
            // 
            this.stMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.stMensagem.Location = new System.Drawing.Point(0, 458);
            this.stMensagem.Name = "stMensagem";
            this.stMensagem.Size = new System.Drawing.Size(582, 22);
            this.stMensagem.TabIndex = 2;
            this.stMensagem.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "Mensagem:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel2.Text = "sem mensagem";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel3.Text = "Coordenada:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel4.Text = "x,y";
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // dlgSalvar
            // 
            this.dlgSalvar.FileName = "openFileDialog2";
            // 
            // frmGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(582, 480);
            this.Controls.Add(this.stMensagem);
            this.Controls.Add(this.pbAreaDesenho);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmGrafico";
            this.Text = "Desenho Gráfico";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAreaDesenho)).EndInit();
            this.stMensagem.ResumeLayout(false);
            this.stMensagem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnPonto;
        private System.Windows.Forms.ToolStripButton btnReta;
        private System.Windows.Forms.ToolStripButton btnCirculo;
        private System.Windows.Forms.ToolStripButton btnElipse;
        private System.Windows.Forms.ToolStripButton btnRetangulo;
        private System.Windows.Forms.ToolStripButton btnPolilinha;
        private System.Windows.Forms.ToolStripButton btnCor;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.PictureBox pbAreaDesenho;
        private System.Windows.Forms.StatusStrip stMensagem;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.OpenFileDialog dlgSalvar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripButton btnApagar;
    }
}

