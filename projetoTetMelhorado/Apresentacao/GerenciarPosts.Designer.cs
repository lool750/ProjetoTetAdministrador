namespace projetoTetMelhorado.Apresentacao
{
    partial class GerenciarPosts
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
            this.flowLayoutPanelPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPosts
            // 
            this.flowLayoutPanelPosts.AutoScroll = true;
            this.flowLayoutPanelPosts.Location = new System.Drawing.Point(41, 31);
            this.flowLayoutPanelPosts.Name = "flowLayoutPanelPosts";
            this.flowLayoutPanelPosts.Size = new System.Drawing.Size(598, 320);
            this.flowLayoutPanelPosts.TabIndex = 0;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(550, 376);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(89, 35);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // GerenciarPosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.flowLayoutPanelPosts);
            this.Name = "GerenciarPosts";
            this.Text = "GerenciarPosts";
            this.Load += new System.EventHandler(this.GerenciarPosts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPosts;
        private System.Windows.Forms.Button btnVoltar;
    }
}