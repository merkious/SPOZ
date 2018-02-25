namespace SPOZ
{
    partial class Raport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raport));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_od = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_do = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_drukuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drukuj raport:";
            // 
            // dateTimePicker_od
            // 
            this.dateTimePicker_od.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_od.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_od.Location = new System.Drawing.Point(16, 59);
            this.dateTimePicker_od.Name = "dateTimePicker_od";
            this.dateTimePicker_od.Size = new System.Drawing.Size(77, 20);
            this.dateTimePicker_od.TabIndex = 1;
            // 
            // dateTimePicker_do
            // 
            this.dateTimePicker_do.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_do.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_do.Location = new System.Drawing.Point(112, 59);
            this.dateTimePicker_do.Name = "dateTimePicker_do";
            this.dateTimePicker_do.Size = new System.Drawing.Size(77, 20);
            this.dateTimePicker_do.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(109, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "DO";
            // 
            // button_drukuj
            // 
            this.button_drukuj.Location = new System.Drawing.Point(67, 86);
            this.button_drukuj.Name = "button_drukuj";
            this.button_drukuj.Size = new System.Drawing.Size(75, 23);
            this.button_drukuj.TabIndex = 5;
            this.button_drukuj.Text = "Drukuj";
            this.button_drukuj.UseVisualStyleBackColor = true;
            this.button_drukuj.Click += new System.EventHandler(this.button_drukuj_Click);
            // 
            // Raport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 137);
            this.Controls.Add(this.button_drukuj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_do);
            this.Controls.Add(this.dateTimePicker_od);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Raport";
            this.Text = "Raport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_od;
        private System.Windows.Forms.DateTimePicker dateTimePicker_do;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_drukuj;
    }
}