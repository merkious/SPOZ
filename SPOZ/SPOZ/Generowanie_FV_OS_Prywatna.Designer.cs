namespace SPOZ
{
    partial class Generowanie_FV_OS_Prywatna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generowanie_FV_OS_Prywatna));
            this.label_kwota = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_zapisz = new System.Windows.Forms.Button();
            this.button_anuluj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_kwota
            // 
            this.label_kwota.AutoSize = true;
            this.label_kwota.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_kwota.Location = new System.Drawing.Point(12, 9);
            this.label_kwota.Name = "label_kwota";
            this.label_kwota.Size = new System.Drawing.Size(68, 18);
            this.label_kwota.TabIndex = 11;
            this.label_kwota.Text = "KWOTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Proszę podać podaną kwotę słownie";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 13;
            // 
            // button_zapisz
            // 
            this.button_zapisz.Location = new System.Drawing.Point(13, 91);
            this.button_zapisz.Name = "button_zapisz";
            this.button_zapisz.Size = new System.Drawing.Size(75, 23);
            this.button_zapisz.TabIndex = 14;
            this.button_zapisz.Text = "Zapisz";
            this.button_zapisz.UseVisualStyleBackColor = true;
            this.button_zapisz.Click += new System.EventHandler(this.button_zapisz_Click);
            // 
            // button_anuluj
            // 
            this.button_anuluj.Location = new System.Drawing.Point(205, 91);
            this.button_anuluj.Name = "button_anuluj";
            this.button_anuluj.Size = new System.Drawing.Size(75, 23);
            this.button_anuluj.TabIndex = 15;
            this.button_anuluj.Text = "Anuluj";
            this.button_anuluj.UseVisualStyleBackColor = true;
            this.button_anuluj.Click += new System.EventHandler(this.button_anuluj_Click);
            // 
            // Generowanie_FV_OS_Prywatna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 126);
            this.Controls.Add(this.button_anuluj);
            this.Controls.Add(this.button_zapisz);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_kwota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Generowanie_FV_OS_Prywatna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kwota słownie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_kwota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_zapisz;
        private System.Windows.Forms.Button button_anuluj;
    }
}