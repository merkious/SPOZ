namespace SPOZ
{
    partial class Kalendarzyk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kalendarzyk));
            this.dateTimePicker_data_rozliczenia = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_nr_zamowienia = new System.Windows.Forms.Label();
            this.comboBox_fv = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dateTimePicker_data_rozliczenia
            // 
            this.dateTimePicker_data_rozliczenia.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_data_rozliczenia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_data_rozliczenia.Location = new System.Drawing.Point(1, 22);
            this.dateTimePicker_data_rozliczenia.Name = "dateTimePicker_data_rozliczenia";
            this.dateTimePicker_data_rozliczenia.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker_data_rozliczenia.TabIndex = 0;
            this.dateTimePicker_data_rozliczenia.Value = new System.DateTime(2017, 10, 21, 2, 23, 35, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Rozlicz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(83, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label_nr_zamowienia
            // 
            this.label_nr_zamowienia.AutoSize = true;
            this.label_nr_zamowienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_nr_zamowienia.Location = new System.Drawing.Point(44, 3);
            this.label_nr_zamowienia.Name = "label_nr_zamowienia";
            this.label_nr_zamowienia.Size = new System.Drawing.Size(69, 16);
            this.label_nr_zamowienia.TabIndex = 5;
            this.label_nr_zamowienia.Text = "000/0000";
            this.label_nr_zamowienia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_fv
            // 
            this.comboBox_fv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fv.FormattingEnabled = true;
            this.comboBox_fv.Items.AddRange(new object[] {
            "Bez faktury",
            "FV - Os. prywatna",
            "FV - Firma"});
            this.comboBox_fv.Location = new System.Drawing.Point(1, 49);
            this.comboBox_fv.Name = "comboBox_fv";
            this.comboBox_fv.Size = new System.Drawing.Size(155, 23);
            this.comboBox_fv.TabIndex = 6;
            // 
            // Kalendarzyk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(161, 101);
            this.Controls.Add(this.comboBox_fv);
            this.Controls.Add(this.label_nr_zamowienia);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker_data_rozliczenia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Kalendarzyk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kalendarzyk";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_data_rozliczenia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_nr_zamowienia;
        private System.Windows.Forms.ComboBox comboBox_fv;
    }
}