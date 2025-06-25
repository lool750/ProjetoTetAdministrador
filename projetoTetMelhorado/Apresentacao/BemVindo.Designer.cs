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
            this.txbPesquisar = new System.Windows.Forms.TextBox();
            this.btnNovoProjeto = new System.Windows.Forms.Button();
            this.flowLayoutPanelProjetos = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxUsuario = new System.Windows.Forms.PictureBox();
            this.contextMenuUsuario = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gerenciarPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsuario)).BeginInit();
            this.contextMenuUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbPesquisar
            // 
            this.txbPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txbPesquisar.Location = new System.Drawing.Point(116, 12);
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
            this.sairDToolStripMenuItem});
            this.contextMenuUsuario.Name = "contextMenuUsuario";
            this.contextMenuUsuario.Size = new System.Drawing.Size(155, 48);
            // 
            // gerenciarPerfilToolStripMenuItem
            // 
            this.gerenciarPerfilToolStripMenuItem.Name = "gerenciarPerfilToolStripMenuItem";
            this.gerenciarPerfilToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.gerenciarPerfilToolStripMenuItem.Text = "Gerenciar Perfil";
            this.gerenciarPerfilToolStripMenuItem.Click += new System.EventHandler(this.gerenciarPerfilToolStripMenuItem_Click);
            // 
            // sairDToolStripMenuItem
            // 
            this.sairDToolStripMenuItem.Name = "sairDToolStripMenuItem";
            this.sairDToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.sairDToolStripMenuItem.Text = "Sair da conta";
            this.sairDToolStripMenuItem.Click += new System.EventHandler(this.sairDToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Buscar:";
            // 
            // BemVindo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxUsuario);
            this.Controls.Add(this.flowLayoutPanelProjetos);
            this.Controls.Add(this.btnNovoProjeto);
            this.Controls.Add(this.txbPesquisar);
            this.Name = "BemVindo";
            this.Text = "BemVindo";
            this.Load += new System.EventHandler(this.BemVindo_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsuario)).EndInit();
            this.contextMenuUsuario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbPesquisar;
        private System.Windows.Forms.Button btnNovoProjeto;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjetos;
        private System.Windows.Forms.PictureBox pictureBoxUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuUsuario;
        private System.Windows.Forms.ToolStripMenuItem gerenciarPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairDToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}