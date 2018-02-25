namespace SPOZ
{
    partial class Aktualizacja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aktualizacja));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Tak = new System.Windows.Forms.Button();
            this.Nie = new System.Windows.Forms.Button();
            this.Szczegoly = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.postep_pobierania = new System.Windows.Forms.ProgressBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pelna_lista_zmian = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 185);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(450, 104);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "Nie udało się połączyć z serwerem.";
            // 
            // Tak
            // 
            this.Tak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Tak.Location = new System.Drawing.Point(194, 117);
            this.Tak.Name = "Tak";
            this.Tak.Size = new System.Drawing.Size(75, 23);
            this.Tak.TabIndex = 1;
            this.Tak.Text = "Tak";
            this.Tak.UseVisualStyleBackColor = true;
            this.Tak.Click += new System.EventHandler(this.Tak_Click);
            // 
            // Nie
            // 
            this.Nie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Nie.Location = new System.Drawing.Point(275, 117);
            this.Nie.Name = "Nie";
            this.Nie.Size = new System.Drawing.Size(75, 23);
            this.Nie.TabIndex = 2;
            this.Nie.Text = "Nie";
            this.Nie.UseVisualStyleBackColor = true;
            this.Nie.Click += new System.EventHandler(this.Nie_Click);
            // 
            // Szczegoly
            // 
            this.Szczegoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Szczegoly.Location = new System.Drawing.Point(356, 117);
            this.Szczegoly.Name = "Szczegoly";
            this.Szczegoly.Size = new System.Drawing.Size(106, 23);
            this.Szczegoly.TabIndex = 3;
            this.Szczegoly.Text = "Pokaż szczegóły";
            this.Szczegoly.UseVisualStyleBackColor = true;
            this.Szczegoly.Click += new System.EventHandler(this.Szczegoly_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // postep_pobierania
            // 
            this.postep_pobierania.Location = new System.Drawing.Point(12, 154);
            this.postep_pobierania.Name = "postep_pobierania";
            this.postep_pobierania.Size = new System.Drawing.Size(450, 25);
            this.postep_pobierania.TabIndex = 4;
            this.postep_pobierania.Visible = false;
            // 
            // pelna_lista_zmian
            // 
            this.pelna_lista_zmian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pelna_lista_zmian.Location = new System.Drawing.Point(327, 291);
            this.pelna_lista_zmian.Name = "pelna_lista_zmian";
            this.pelna_lista_zmian.Size = new System.Drawing.Size(135, 23);
            this.pelna_lista_zmian.TabIndex = 6;
            this.pelna_lista_zmian.Text = "Zobacz pełną listę zmian";
            this.pelna_lista_zmian.UseVisualStyleBackColor = true;
            this.pelna_lista_zmian.Click += new System.EventHandler(this.Pelna_lista_zmian_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(120, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nowsza wersja tego oprogramowania jest już dostępna.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // Aktualizacja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 316);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pelna_lista_zmian);
            this.Controls.Add(this.postep_pobierania);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Szczegoly);
            this.Controls.Add(this.Nie);
            this.Controls.Add(this.Tak);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Aktualizacja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aktualizacja";
            this.Load += new System.EventHandler(this.Ladowanie_okna_Aktualizacja);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Tak;
        private System.Windows.Forms.Button Nie;
        private System.Windows.Forms.Button Szczegoly;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ProgressBar postep_pobierania;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button pelna_lista_zmian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}