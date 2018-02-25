namespace SPOZ
{
    partial class Logowanie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logowanie));
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.textBox_haslo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_zapomnialem_hasla = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_zapomnialem_hasla)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_mail
            // 
            this.textBox_mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_mail.Location = new System.Drawing.Point(172, 99);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(167, 13);
            this.textBox_mail.TabIndex = 0;
            // 
            // textBox_haslo
            // 
            this.textBox_haslo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_haslo.Location = new System.Drawing.Point(173, 132);
            this.textBox_haslo.Name = "textBox_haslo";
            this.textBox_haslo.PasswordChar = '#';
            this.textBox_haslo.Size = new System.Drawing.Size(167, 13);
            this.textBox_haslo.TabIndex = 1;
            this.textBox_haslo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_haslo_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(469, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(204, 167);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox_zaloguj_Click);
            // 
            // pictureBox_zapomnialem_hasla
            // 
            this.pictureBox_zapomnialem_hasla.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_zapomnialem_hasla.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_zapomnialem_hasla.Image")));
            this.pictureBox_zapomnialem_hasla.Location = new System.Drawing.Point(195, 265);
            this.pictureBox_zapomnialem_hasla.Name = "pictureBox_zapomnialem_hasla";
            this.pictureBox_zapomnialem_hasla.Size = new System.Drawing.Size(100, 33);
            this.pictureBox_zapomnialem_hasla.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_zapomnialem_hasla.TabIndex = 26;
            this.pictureBox_zapomnialem_hasla.TabStop = false;
            this.pictureBox_zapomnialem_hasla.Click += new System.EventHandler(this.PictureBox_zapomnialem_hasla_Click);
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(490, 310);
            this.Controls.Add(this.pictureBox_zapomnialem_hasla);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_mail);
            this.Controls.Add(this.textBox_haslo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logowanie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logowanie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logowanie_FormClosing);
            this.Load += new System.EventHandler(this.Logowanie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_zapomnialem_hasla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TextBox textBox_mail;
        public System.Windows.Forms.TextBox textBox_haslo;
        private System.Windows.Forms.PictureBox pictureBox_zapomnialem_hasla;
    }
}