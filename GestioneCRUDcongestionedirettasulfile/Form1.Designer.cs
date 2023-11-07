namespace GestioneCRUDcongestionedirettasulfile
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.articoli = new System.Windows.Forms.ListBox();
            this.mostraprod_btn = new System.Windows.Forms.Button();
            this.fileprod_btn = new System.Windows.Forms.Button();
            this.canclogica_btn = new System.Windows.Forms.Button();
            this.Modifican_btn = new System.Windows.Forms.Button();
            this.Modificap_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ricercanome_box = new System.Windows.Forms.TextBox();
            this.modnome_box = new System.Windows.Forms.TextBox();
            this.modprezzo_box = new System.Windows.Forms.TextBox();
            this.Prezzo_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Nome_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recupera_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.cancfisica_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // articoli
            // 
            this.articoli.BackColor = System.Drawing.SystemColors.Window;
            this.articoli.ForeColor = System.Drawing.SystemColors.WindowText;
            this.articoli.FormattingEnabled = true;
            this.articoli.Location = new System.Drawing.Point(465, 12);
            this.articoli.Name = "articoli";
            this.articoli.Size = new System.Drawing.Size(323, 342);
            this.articoli.TabIndex = 14;
            // 
            // mostraprod_btn
            // 
            this.mostraprod_btn.Location = new System.Drawing.Point(356, 286);
            this.mostraprod_btn.Name = "mostraprod_btn";
            this.mostraprod_btn.Size = new System.Drawing.Size(89, 37);
            this.mostraprod_btn.TabIndex = 29;
            this.mostraprod_btn.Text = "mostra prodotti nel file";
            this.mostraprod_btn.UseVisualStyleBackColor = true;
            this.mostraprod_btn.Click += new System.EventHandler(this.mostraprod_btn_Click);
            // 
            // fileprod_btn
            // 
            this.fileprod_btn.Location = new System.Drawing.Point(112, 62);
            this.fileprod_btn.Name = "fileprod_btn";
            this.fileprod_btn.Size = new System.Drawing.Size(82, 21);
            this.fileprod_btn.TabIndex = 28;
            this.fileprod_btn.Text = "Aggiungi";
            this.fileprod_btn.UseVisualStyleBackColor = true;
            this.fileprod_btn.Click += new System.EventHandler(this.fileprod_btn_Click);
            // 
            // canclogica_btn
            // 
            this.canclogica_btn.Location = new System.Drawing.Point(342, 104);
            this.canclogica_btn.Name = "canclogica_btn";
            this.canclogica_btn.Size = new System.Drawing.Size(85, 40);
            this.canclogica_btn.TabIndex = 43;
            this.canclogica_btn.Text = "cancellazione logica";
            this.canclogica_btn.UseVisualStyleBackColor = true;
            this.canclogica_btn.Click += new System.EventHandler(this.canclogica_btn_Click);
            // 
            // Modifican_btn
            // 
            this.Modifican_btn.Location = new System.Drawing.Point(155, 239);
            this.Modifican_btn.Name = "Modifican_btn";
            this.Modifican_btn.Size = new System.Drawing.Size(78, 28);
            this.Modifican_btn.TabIndex = 42;
            this.Modifican_btn.Text = "modifica";
            this.Modifican_btn.UseVisualStyleBackColor = true;
            this.Modifican_btn.Click += new System.EventHandler(this.Modifican_btn_Click);
            // 
            // Modificap_btn
            // 
            this.Modificap_btn.Location = new System.Drawing.Point(155, 278);
            this.Modificap_btn.Name = "Modificap_btn";
            this.Modificap_btn.Size = new System.Drawing.Size(78, 28);
            this.Modificap_btn.TabIndex = 41;
            this.Modificap_btn.Text = "modifica";
            this.Modificap_btn.UseVisualStyleBackColor = true;
            this.Modificap_btn.Click += new System.EventHandler(this.Modificap_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 40;
            this.label6.Text = "RICERCA \r\nNOME";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "MODIFICA NOME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "MODIFICA PREZZO";
            // 
            // ricercanome_box
            // 
            this.ricercanome_box.Location = new System.Drawing.Point(73, 179);
            this.ricercanome_box.Name = "ricercanome_box";
            this.ricercanome_box.Size = new System.Drawing.Size(97, 20);
            this.ricercanome_box.TabIndex = 36;
            // 
            // modnome_box
            // 
            this.modnome_box.Location = new System.Drawing.Point(39, 247);
            this.modnome_box.Name = "modnome_box";
            this.modnome_box.Size = new System.Drawing.Size(97, 20);
            this.modnome_box.TabIndex = 35;
            // 
            // modprezzo_box
            // 
            this.modprezzo_box.Location = new System.Drawing.Point(39, 286);
            this.modprezzo_box.Name = "modprezzo_box";
            this.modprezzo_box.Size = new System.Drawing.Size(97, 20);
            this.modprezzo_box.TabIndex = 34;
            // 
            // Prezzo_box
            // 
            this.Prezzo_box.Location = new System.Drawing.Point(175, 36);
            this.Prezzo_box.Name = "Prezzo_box";
            this.Prezzo_box.Size = new System.Drawing.Size(97, 20);
            this.Prezzo_box.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "PREZZO";
            // 
            // Nome_box
            // 
            this.Nome_box.Location = new System.Drawing.Point(34, 36);
            this.Nome_box.Name = "Nome_box";
            this.Nome_box.Size = new System.Drawing.Size(97, 20);
            this.Nome_box.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "NOME";
            // 
            // recupera_btn
            // 
            this.recupera_btn.Location = new System.Drawing.Point(223, 121);
            this.recupera_btn.Name = "recupera_btn";
            this.recupera_btn.Size = new System.Drawing.Size(85, 37);
            this.recupera_btn.TabIndex = 44;
            this.recupera_btn.Text = "recupera prodotto";
            this.recupera_btn.UseVisualStyleBackColor = true;
            this.recupera_btn.Click += new System.EventHandler(this.recupera_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.Location = new System.Drawing.Point(342, 20);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(85, 40);
            this.reset_btn.TabIndex = 45;
            this.reset_btn.Text = "reset file";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // cancfisica_btn
            // 
            this.cancfisica_btn.Location = new System.Drawing.Point(342, 150);
            this.cancfisica_btn.Name = "cancfisica_btn";
            this.cancfisica_btn.Size = new System.Drawing.Size(85, 39);
            this.cancfisica_btn.TabIndex = 47;
            this.cancfisica_btn.Text = "cancellazione fisica";
            this.cancfisica_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancfisica_btn);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.recupera_btn);
            this.Controls.Add(this.canclogica_btn);
            this.Controls.Add(this.Modifican_btn);
            this.Controls.Add(this.Modificap_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ricercanome_box);
            this.Controls.Add(this.modnome_box);
            this.Controls.Add(this.modprezzo_box);
            this.Controls.Add(this.Prezzo_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nome_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mostraprod_btn);
            this.Controls.Add(this.fileprod_btn);
            this.Controls.Add(this.articoli);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox articoli;
        private System.Windows.Forms.Button mostraprod_btn;
        private System.Windows.Forms.Button fileprod_btn;
        private System.Windows.Forms.Button canclogica_btn;
        private System.Windows.Forms.Button Modifican_btn;
        private System.Windows.Forms.Button Modificap_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ricercanome_box;
        private System.Windows.Forms.TextBox modnome_box;
        private System.Windows.Forms.TextBox modprezzo_box;
        private System.Windows.Forms.TextBox Prezzo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Nome_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button recupera_btn;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button cancfisica_btn;
    }
}

