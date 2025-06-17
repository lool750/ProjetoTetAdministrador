namespace projetoTetMelhorado.Apresentacao
{
    partial class BemVindo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BemVindo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbPesquisar = new System.Windows.Forms.TextBox();
            this.btnNovoProjeto = new System.Windows.Forms.Button();
            this.flowLayoutPanelProjetos = new System.Windows.Forms.FlowLayoutPanel();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.pictureBoxUsuario = new System.Windows.Forms.PictureBox();
            this.contextMenuUsuario = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gerenciarPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoProjetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsuario)).BeginInit();
            this.contextMenuUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txbPesquisar
            // 
            this.txbPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txbPesquisar.Location = new System.Drawing.Point(56, 12);
            this.txbPesquisar.Name = "txbPesquisar";
            this.txbPesquisar.Size = new System.Drawing.Size(543, 29);
            this.txbPesquisar.TabIndex = 3;
            this.txbPesquisar.TextChanged += new System.EventHandler(this.txbPesquisar_TextChanged);
            // 
            // btnNovoProjeto
            // 
            this.btnNovoProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnNovoProjeto.Location = new System.Drawing.Point(719, 104);
            this.btnNovoProjeto.Name = "btnNovoProjeto";
            this.btnNovoProjeto.Size = new System.Drawing.Size(97, 56);
            this.btnNovoProjeto.TabIndex = 5;
            this.btnNovoProjeto.Text = " Novo Projeto";
            this.btnNovoProjeto.UseVisualStyleBackColor = true;
            this.btnNovoProjeto.Click += new System.EventHandler(this.btnNovoProjeto_Click);
            // 
            // flowLayoutPanelProjetos
            // 
            this.flowLayoutPanelProjetos.AutoScroll = true;
            this.flowLayoutPanelProjetos.Location = new System.Drawing.Point(18, 63);
            this.flowLayoutPanelProjetos.Name = "flowLayoutPanelProjetos";
            this.flowLayoutPanelProjetos.Size = new System.Drawing.Size(695, 375);
            this.flowLayoutPanelProjetos.TabIndex = 6;
            // 
            // cbFiltro
            // 
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Items.AddRange(new object[] {
            "Mais recentes",
            "Mais antigos"});
            this.cbFiltro.Location = new System.Drawing.Point(605, 12);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(108, 28);
            this.cbFiltro.TabIndex = 7;
            this.cbFiltro.SelectedIndexChanged += new System.EventHandler(this.cbFiltro_SelectedIndexChanged);
            // 
            // pictureBoxUsuario
            // 
            this.pictureBoxUsuario.Location = new System.Drawing.Point(719, 13);
            this.pictureBoxUsuario.Name = "pictureBoxUsuario";
            this.pictureBoxUsuario.Size = new System.Drawing.Size(97, 74);
            this.pictureBoxUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUsuario.TabIndex = 10;
            this.pictureBoxUsuario.TabStop = false;
            // 
            // contextMenuUsuario
            // 
            this.contextMenuUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarPerfilToolStripMenuItem,
            this.novoProjetoToolStripMenuItem,
            this.sairDToolStripMenuItem});
            this.contextMenuUsuario.Name = "contextMenuUsuario";
            this.contextMenuUsuario.Size = new System.Drawing.Size(156, 70);
            // 
            // gerenciarPerfilToolStripMenuItem
            // 
            this.gerenciarPerfilToolStripMenuItem.Name = "gerenciarPerfilToolStripMenuItem";
            this.gerenciarPerfilToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.gerenciarPerfilToolStripMenuItem.Text = "Gerenciar Perfil";
            this.gerenciarPerfilToolStripMenuItem.Click += new System.EventHandler(this.gerenciarPerfilToolStripMenuItem_Click);
            // 
            // novoProjetoToolStripMenuItem
            // 
            this.novoProjetoToolStripMenuItem.Name = "novoProjetoToolStripMenuItem";
            this.novoProjetoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.novoProjetoToolStripMenuItem.Text = "Gerenciar Posts";
            this.novoProjetoToolStripMenuItem.Click += new System.EventHandler(this.novoProjetoToolStripMenuItem_Click);
            // 
            // sairDToolStripMenuItem
            // 
            this.sairDToolStripMenuItem.Name = "sairDToolStripMenuItem";
            this.sairDToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.sairDToolStripMenuItem.Text = "Sair da conta";
            this.sairDToolStripMenuItem.Click += new System.EventHandler(this.sairDToolStripMenuItem_Click);
            // 
            // BemVindo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.pictureBoxUsuario);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.flowLayoutPanelProjetos);
            this.Controls.Add(this.btnNovoProjeto);
            this.Controls.Add(this.txbPesquisar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BemVindo";
            this.Text = "BemVindo";
            this.Load += new System.EventHandler(this.BemVindo_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsuario)).EndInit();
            this.contextMenuUsuario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txbPesquisar;
        private System.Windows.Forms.Button btnNovoProjeto;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjetos;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.PictureBox pictureBoxUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuUsuario;
        private System.Windows.Forms.ToolStripMenuItem gerenciarPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoProjetoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairDToolStripMenuItem;
    }
}