namespace SPOZ
{
    partial class Generowanie_Faktury_Firma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generowanie_Faktury_Firma));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nazwa_firmy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_miejscowosc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox_kod_pocztowy = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_adres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_nip = new System.Windows.Forms.TextBox();
            this.button_zapisz = new System.Windows.Forms.Button();
            this.button_anuluj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa Firmy";
            // 
            // textBox_nazwa_firmy
            // 
            this.textBox_nazwa_firmy.Location = new System.Drawing.Point(16, 30);
            this.textBox_nazwa_firmy.Name = "textBox_nazwa_firmy";
            this.textBox_nazwa_firmy.Size = new System.Drawing.Size(246, 20);
            this.textBox_nazwa_firmy.TabIndex = 1;
            this.textBox_nazwa_firmy.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Miejscowość";
            // 
            // textBox_miejscowosc
            // 
            this.textBox_miejscowosc.Location = new System.Drawing.Point(16, 74);
            this.textBox_miejscowosc.Name = "textBox_miejscowosc";
            this.textBox_miejscowosc.Size = new System.Drawing.Size(246, 20);
            this.textBox_miejscowosc.TabIndex = 3;
            this.textBox_miejscowosc.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kod pocztowy";
            // 
            // maskedTextBox_kod_pocztowy
            // 
            this.maskedTextBox_kod_pocztowy.Location = new System.Drawing.Point(16, 118);
            this.maskedTextBox_kod_pocztowy.Mask = "00-000";
            this.maskedTextBox_kod_pocztowy.Name = "maskedTextBox_kod_pocztowy";
            this.maskedTextBox_kod_pocztowy.Size = new System.Drawing.Size(46, 20);
            this.maskedTextBox_kod_pocztowy.TabIndex = 5;
            this.maskedTextBox_kod_pocztowy.TextChanged += new System.EventHandler(this.maskedTextBox_kod_pocztowy_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Adres Firmy";
            // 
            // textBox_adres
            // 
            this.textBox_adres.Location = new System.Drawing.Point(16, 162);
            this.textBox_adres.Name = "textBox_adres";
            this.textBox_adres.Size = new System.Drawing.Size(246, 20);
            this.textBox_adres.TabIndex = 7;
            this.textBox_adres.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "NIP";
            // 
            // textBox_nip
            // 
            this.textBox_nip.Location = new System.Drawing.Point(16, 206);
            this.textBox_nip.Name = "textBox_nip";
            this.textBox_nip.Size = new System.Drawing.Size(246, 20);
            this.textBox_nip.TabIndex = 9;
            this.textBox_nip.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // button_zapisz
            // 
            this.button_zapisz.Location = new System.Drawing.Point(15, 232);
            this.button_zapisz.Name = "button_zapisz";
            this.button_zapisz.Size = new System.Drawing.Size(75, 23);
            this.button_zapisz.TabIndex = 13;
            this.button_zapisz.Text = "Zapisz";
            this.button_zapisz.UseVisualStyleBackColor = true;
            this.button_zapisz.Click += new System.EventHandler(this.button_zapisz_Click);
            // 
            // button_anuluj
            // 
            this.button_anuluj.Location = new System.Drawing.Point(187, 232);
            this.button_anuluj.Name = "button_anuluj";
            this.button_anuluj.Size = new System.Drawing.Size(75, 23);
            this.button_anuluj.TabIndex = 14;
            this.button_anuluj.Text = "Anuluj";
            this.button_anuluj.UseVisualStyleBackColor = true;
            this.button_anuluj.Click += new System.EventHandler(this.button_anuluj_Click);
            // 
            // Generowanie_Faktury_Firma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 261);
            this.Controls.Add(this.button_anuluj);
            this.Controls.Add(this.button_zapisz);
            this.Controls.Add(this.textBox_nip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_adres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedTextBox_kod_pocztowy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_miejscowosc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nazwa_firmy);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Generowanie_Faktury_Firma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Faktura dla Firmy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nazwa_firmy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_miejscowosc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_kod_pocztowy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_adres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_nip;
        private System.Windows.Forms.Button button_zapisz;
        private System.Windows.Forms.Button button_anuluj;
    }
}