namespace SPOZ
{
    partial class Zmiana_hasla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zmiana_hasla));
            this.button_zmien_haslo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nowe_haslo = new System.Windows.Forms.TextBox();
            this.textBox_nowe_haslo_2 = new System.Windows.Forms.TextBox();
            this.textBox_kod_z_maila = new System.Windows.Forms.TextBox();
            this.label_kod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_zmien_haslo
            // 
            this.button_zmien_haslo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_zmien_haslo.Location = new System.Drawing.Point(63, 148);
            this.button_zmien_haslo.Name = "button_zmien_haslo";
            this.button_zmien_haslo.Size = new System.Drawing.Size(75, 23);
            this.button_zmien_haslo.TabIndex = 5;
            this.button_zmien_haslo.Text = "Zmień";
            this.button_zmien_haslo.UseVisualStyleBackColor = true;
            this.button_zmien_haslo.Click += new System.EventHandler(this.button_zmien_haslo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Powtórz nowe hasło";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nowe hasło";
            // 
            // textBox_nowe_haslo
            // 
            this.textBox_nowe_haslo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_nowe_haslo.Location = new System.Drawing.Point(25, 65);
            this.textBox_nowe_haslo.Name = "textBox_nowe_haslo";
            this.textBox_nowe_haslo.PasswordChar = '#';
            this.textBox_nowe_haslo.Size = new System.Drawing.Size(150, 20);
            this.textBox_nowe_haslo.TabIndex = 8;
            // 
            // textBox_nowe_haslo_2
            // 
            this.textBox_nowe_haslo_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_nowe_haslo_2.Location = new System.Drawing.Point(25, 105);
            this.textBox_nowe_haslo_2.Name = "textBox_nowe_haslo_2";
            this.textBox_nowe_haslo_2.PasswordChar = '#';
            this.textBox_nowe_haslo_2.Size = new System.Drawing.Size(150, 20);
            this.textBox_nowe_haslo_2.TabIndex = 9;
            // 
            // textBox_kod_z_maila
            // 
            this.textBox_kod_z_maila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_kod_z_maila.Location = new System.Drawing.Point(25, 26);
            this.textBox_kod_z_maila.Name = "textBox_kod_z_maila";
            this.textBox_kod_z_maila.Size = new System.Drawing.Size(150, 20);
            this.textBox_kod_z_maila.TabIndex = 11;
            // 
            // label_kod
            // 
            this.label_kod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_kod.AutoSize = true;
            this.label_kod.Location = new System.Drawing.Point(42, 11);
            this.label_kod.Name = "label_kod";
            this.label_kod.Size = new System.Drawing.Size(119, 13);
            this.label_kod.TabIndex = 12;
            this.label_kod.Text = "Kod z wiadomości email";
            // 
            // Zmiana_hasla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 183);
            this.Controls.Add(this.label_kod);
            this.Controls.Add(this.textBox_kod_z_maila);
            this.Controls.Add(this.textBox_nowe_haslo_2);
            this.Controls.Add(this.textBox_nowe_haslo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_zmien_haslo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Zmiana_hasla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wymagana zmiana hasła";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Zmiana_hasla_przy_1_logowaniu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_zmien_haslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nowe_haslo;
        private System.Windows.Forms.TextBox textBox_nowe_haslo_2;
        private System.Windows.Forms.TextBox textBox_kod_z_maila;
        private System.Windows.Forms.Label label_kod;
    }
}