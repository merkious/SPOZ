namespace SPOZ
{
    partial class Gratis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gratis));
            this.button_gratis = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_rabat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_cena_gratisu = new System.Windows.Forms.TextBox();
            this.textBox_cena_po_rabacie = new System.Windows.Forms.TextBox();
            this.textBox_nazwa_gratisu = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_gratis
            // 
            this.button_gratis.Location = new System.Drawing.Point(60, 208);
            this.button_gratis.Name = "button_gratis";
            this.button_gratis.Size = new System.Drawing.Size(75, 23);
            this.button_gratis.TabIndex = 8;
            this.button_gratis.Text = "Zapisz gratis";
            this.button_gratis.UseVisualStyleBackColor = true;
            this.button_gratis.Click += new System.EventHandler(this.button_gratis_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cena po rabacie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rabat";
            // 
            // textBox_rabat
            // 
            this.textBox_rabat.Location = new System.Drawing.Point(47, 152);
            this.textBox_rabat.Name = "textBox_rabat";
            this.textBox_rabat.ReadOnly = true;
            this.textBox_rabat.Size = new System.Drawing.Size(100, 20);
            this.textBox_rabat.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cena";
            // 
            // textBox_cena_gratisu
            // 
            this.textBox_cena_gratisu.Location = new System.Drawing.Point(47, 74);
            this.textBox_cena_gratisu.Name = "textBox_cena_gratisu";
            this.textBox_cena_gratisu.Size = new System.Drawing.Size(100, 20);
            this.textBox_cena_gratisu.TabIndex = 3;
            this.textBox_cena_gratisu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_cena_gratisu_KeyUp);
            // 
            // textBox_cena_po_rabacie
            // 
            this.textBox_cena_po_rabacie.Location = new System.Drawing.Point(47, 113);
            this.textBox_cena_po_rabacie.Name = "textBox_cena_po_rabacie";
            this.textBox_cena_po_rabacie.Size = new System.Drawing.Size(100, 20);
            this.textBox_cena_po_rabacie.TabIndex = 5;
            this.textBox_cena_po_rabacie.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_cena_po_rabacie_KeyUp);
            // 
            // textBox_nazwa_gratisu
            // 
            this.textBox_nazwa_gratisu.Location = new System.Drawing.Point(47, 35);
            this.textBox_nazwa_gratisu.Name = "textBox_nazwa_gratisu";
            this.textBox_nazwa_gratisu.Size = new System.Drawing.Size(100, 20);
            this.textBox_nazwa_gratisu.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(64, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Aktywny";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // Gratis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 243);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_gratis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_rabat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_cena_gratisu);
            this.Controls.Add(this.textBox_cena_po_rabacie);
            this.Controls.Add(this.textBox_nazwa_gratisu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gratis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Now gratis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gratis_FormClosed);
            this.Load += new System.EventHandler(this.Gratis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_gratis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_rabat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_cena_gratisu;
        private System.Windows.Forms.TextBox textBox_cena_po_rabacie;
        private System.Windows.Forms.TextBox textBox_nazwa_gratisu;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}