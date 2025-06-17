namespace projetoTetMelhorado.Apresentacao
{
    partial class NovoProjeto
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
            this.txbNovoProjeto = new System.Windows.Forms.TextBox();
            this.txbDescricao = new System.Windows.Forms.TextBox();
            this.txbValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnCancelarNP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbNovoProjeto
            // 
            this.txbNovoProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNovoProjeto.Location = new System.Drawing.Point(96, 67);
            this.txbNovoProjeto.Name = "txbNovoProjeto";
            this.txbNovoProjeto.Size = new System.Drawing.Size(342, 29);
            this.txbNovoProjeto.TabIndex = 0;
            this.txbNovoProjeto.TextChanged += new System.EventHandler(this.txbNovoProjeto_TextChanged);
            // 
            // txbDescricao
            // 
            this.txbDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescricao.Location = new System.Drawing.Point(96, 127);
            this.txbDescricao.Name = "txbDescricao";
            this.txbDescricao.Size = new System.Drawing.Size(342, 29);
            this.txbDescricao.TabIndex = 1;
            this.txbDescricao.TextChanged += new System.EventHandler(this.txbDescricao_TextChanged);
            // 
            // txbValor
            // 
            this.txbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbValor.Location = new System.Drawing.Point(96, 187);
            this.txbValor.Name = "txbValor";
            this.txbValor.Size = new System.Drawing.Size(342, 29);
            this.txbValor.TabIndex = 2;
            this.txbValor.TextChanged += new System.EventHandler(this.txbValor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.Location = new System.Drawing.Point(170, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = " Nome do projeto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = " Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = " Valor";
            // 
            // btnCriar
            // 
            this.btnCriar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.btnCriar.Location = new System.Drawing.Point(165, 247);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(170, 50);
            this.btnCriar.TabIndex = 6;
            this.btnCriar.Text = " CRIAR";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // btnCancelarNP
            // 
            this.btnCancelarNP.Location = new System.Drawing.Point(208, 321);
            this.btnCancelarNP.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarNP.Name = "btnCancelarNP";
            this.btnCancelarNP.Size = new System.Drawing.Size(99, 32);
            this.btnCancelarNP.TabIndex = 7;
            this.btnCancelarNP.Text = "Cancelar";
            this.btnCancelarNP.UseVisualStyleBackColor = true;
            this.btnCancelarNP.Click += new System.EventHandler(this.btnCancelarNP_Click);
            // 
            // NovoProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 364);
            this.Controls.Add(this.btnCancelarNP);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbValor);
            this.Controls.Add(this.txbDescricao);
            this.Controls.Add(this.txbNovoProjeto);
            this.Name = "NovoProjeto";
            this.Text = "NovoProjeto";
            this.Load += new System.EventHandler(this.NovoProjeto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbNovoProjeto;
        private System.Windows.Forms.TextBox txbDescricao;
        private System.Windows.Forms.TextBox txbValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button btnCancelarNP;
    }
}