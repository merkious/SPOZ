namespace SPOZ
{
    partial class Doplata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doplata));
            this.textBox_kwota_doplaty = new System.Windows.Forms.TextBox();
            this.label_nr_zamowienia = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_kwota_doplaty
            // 
            this.textBox_kwota_doplaty.Location = new System.Drawing.Point(28, 22);
            this.textBox_kwota_doplaty.Name = "textBox_kwota_doplaty";
            this.textBox_kwota_doplaty.Size = new System.Drawing.Size(100, 20);
            this.textBox_kwota_doplaty.TabIndex = 0;
            this.textBox_kwota_doplaty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_kwota_doplaty_KeyPress);
            // 
            // label_nr_zamowienia
            // 
            this.label_nr_zamowienia.AutoSize = true;
            this.label_nr_zamowienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_nr_zamowienia.Location = new System.Drawing.Point(45, 3);
            this.label_nr_zamowienia.Name = "label_nr_zamowienia";
            this.label_nr_zamowienia.Size = new System.Drawing.Size(69, 16);
            this.label_nr_zamowienia.TabIndex = 8;
            this.label_nr_zamowienia.Text = "000/0000";
            this.label_nr_zamowienia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Anuluj_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Dopłata";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Doplata_Click);
            // 
            // Doplata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(157, 67);
            this.Controls.Add(this.label_nr_zamowienia);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_kwota_doplaty);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Doplata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Doplata";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_kwota_doplaty;
        private System.Windows.Forms.Label label_nr_zamowienia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}