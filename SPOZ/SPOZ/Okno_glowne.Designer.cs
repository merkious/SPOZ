namespace SPOZ
{
    partial class Okno_glowne
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Okno_glowne));
            this.dateTimePicker_od = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_do = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_nowe_zk = new System.Windows.Forms.Button();
            this.dataGridView_zamowienia = new System.Windows.Forms.DataGridView();
            this.textBox_szukaj_zk = new System.Windows.Forms.TextBox();
            this.pasek_menu = new System.Windows.Forms.MenuStrip();
            this.raportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raportKwotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raportRealizacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_nierozliczone = new System.Windows.Forms.CheckBox();
            this.checkBox_rozliczone = new System.Windows.Forms.CheckBox();
            this.label_wybrny_sklep = new System.Windows.Forms.Label();
            this.timer_status_polaczenia = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Pasek_statusu = new System.Windows.Forms.StatusStrip();
            this.pictureBox_status_polaczenie_z_baza_g = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox_status_polaczenie_z_baza_r = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_status_polaczenia_z_baza = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_wersja = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_wyloguj = new System.Windows.Forms.Label();
            this.label_uzytkownik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zamowienia)).BeginInit();
            this.pasek_menu.SuspendLayout();
            this.Pasek_statusu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_od
            // 
            this.dateTimePicker_od.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_od.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_od.Location = new System.Drawing.Point(171, 39);
            this.dateTimePicker_od.Name = "dateTimePicker_od";
            this.dateTimePicker_od.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_od.TabIndex = 0;
            this.dateTimePicker_od.Value = new System.DateTime(1994, 1, 14, 0, 0, 0, 0);
            this.dateTimePicker_od.CloseUp += new System.EventHandler(this.DateTimePicker_od_CloseUp);
            // 
            // dateTimePicker_do
            // 
            this.dateTimePicker_do.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_do.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_do.Location = new System.Drawing.Point(171, 75);
            this.dateTimePicker_do.Name = "dateTimePicker_do";
            this.dateTimePicker_do.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_do.TabIndex = 1;
            this.dateTimePicker_do.CloseUp += new System.EventHandler(this.DateTimePicker_do_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "OD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "DO";
            // 
            // button_nowe_zk
            // 
            this.button_nowe_zk.Location = new System.Drawing.Point(19, 42);
            this.button_nowe_zk.Name = "button_nowe_zk";
            this.button_nowe_zk.Size = new System.Drawing.Size(96, 51);
            this.button_nowe_zk.TabIndex = 5;
            this.button_nowe_zk.Text = "Nowe zamówienie";
            this.button_nowe_zk.UseVisualStyleBackColor = true;
            this.button_nowe_zk.Click += new System.EventHandler(this.Button_nowe_zk_Click);
            // 
            // dataGridView_zamowienia
            // 
            this.dataGridView_zamowienia.AllowUserToAddRows = false;
            this.dataGridView_zamowienia.AllowUserToDeleteRows = false;
            this.dataGridView_zamowienia.AllowUserToResizeColumns = false;
            this.dataGridView_zamowienia.AllowUserToResizeRows = false;
            this.dataGridView_zamowienia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_zamowienia.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_zamowienia.ColumnHeadersHeight = 46;
            this.dataGridView_zamowienia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_zamowienia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_zamowienia.Location = new System.Drawing.Point(12, 101);
            this.dataGridView_zamowienia.Name = "dataGridView_zamowienia";
            this.dataGridView_zamowienia.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_zamowienia.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_zamowienia.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_zamowienia.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_zamowienia.Size = new System.Drawing.Size(1190, 359);
            this.dataGridView_zamowienia.TabIndex = 6;
            this.dataGridView_zamowienia.TabStop = false;
            this.dataGridView_zamowienia.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_zamowienia_ColumnHeaderMouseClick);
            this.dataGridView_zamowienia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView_zamowienia_MouseClick);
            // 
            // textBox_szukaj_zk
            // 
            this.textBox_szukaj_zk.Location = new System.Drawing.Point(398, 45);
            this.textBox_szukaj_zk.Name = "textBox_szukaj_zk";
            this.textBox_szukaj_zk.Size = new System.Drawing.Size(133, 20);
            this.textBox_szukaj_zk.TabIndex = 7;
            this.textBox_szukaj_zk.Enter += new System.EventHandler(this.TextBox_szukaj_zk_Enter);
            this.textBox_szukaj_zk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_szukaj_zk_KeyUp);
            // 
            // pasek_menu
            // 
            this.pasek_menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pasek_menu.BackgroundImage")));
            this.pasek_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pasek_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raportToolStripMenuItem,
            this.opcjeToolStripMenuItem});
            this.pasek_menu.Location = new System.Drawing.Point(0, 0);
            this.pasek_menu.Name = "pasek_menu";
            this.pasek_menu.Size = new System.Drawing.Size(1214, 24);
            this.pasek_menu.TabIndex = 10;
            this.pasek_menu.Text = "menuStrip1";
            // 
            // raportToolStripMenuItem
            // 
            this.raportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raportKwotToolStripMenuItem,
            this.raportRealizacjiToolStripMenuItem});
            this.raportToolStripMenuItem.Name = "raportToolStripMenuItem";
            this.raportToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.raportToolStripMenuItem.Text = "Stwórz raport";
            this.raportToolStripMenuItem.Click += new System.EventHandler(this.RaportToolStripMenuItem_Click);
            // 
            // raportKwotToolStripMenuItem
            // 
            this.raportKwotToolStripMenuItem.Name = "raportKwotToolStripMenuItem";
            this.raportKwotToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.raportKwotToolStripMenuItem.Text = "Raport kwot";
            this.raportKwotToolStripMenuItem.Click += new System.EventHandler(this.RaportKwotToolStripMenuItem_Click);
            // 
            // raportRealizacjiToolStripMenuItem
            // 
            this.raportRealizacjiToolStripMenuItem.Name = "raportRealizacjiToolStripMenuItem";
            this.raportRealizacjiToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.raportRealizacjiToolStripMenuItem.Text = "Raport realizacji";
            this.raportRealizacjiToolStripMenuItem.Click += new System.EventHandler(this.RaportRealizacjiToolStripMenuItem_Click_1);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            this.opcjeToolStripMenuItem.Click += new System.EventHandler(this.OpcjeToolStripMenuItem_Click);
            // 
            // checkBox_nierozliczone
            // 
            this.checkBox_nierozliczone.AutoSize = true;
            this.checkBox_nierozliczone.Location = new System.Drawing.Point(275, 68);
            this.checkBox_nierozliczone.Name = "checkBox_nierozliczone";
            this.checkBox_nierozliczone.Size = new System.Drawing.Size(89, 17);
            this.checkBox_nierozliczone.TabIndex = 13;
            this.checkBox_nierozliczone.Text = "Nierozliczone";
            this.checkBox_nierozliczone.UseVisualStyleBackColor = true;
            this.checkBox_nierozliczone.CheckedChanged += new System.EventHandler(this.CheckBox_nierozliczone_CheckedChanged);
            // 
            // checkBox_rozliczone
            // 
            this.checkBox_rozliczone.AutoSize = true;
            this.checkBox_rozliczone.Location = new System.Drawing.Point(275, 45);
            this.checkBox_rozliczone.Name = "checkBox_rozliczone";
            this.checkBox_rozliczone.Size = new System.Drawing.Size(78, 17);
            this.checkBox_rozliczone.TabIndex = 12;
            this.checkBox_rozliczone.Text = "Rozliczone";
            this.checkBox_rozliczone.UseVisualStyleBackColor = true;
            this.checkBox_rozliczone.CheckedChanged += new System.EventHandler(this.CheckBox_rozliczone_CheckedChanged);
            // 
            // label_wybrny_sklep
            // 
            this.label_wybrny_sklep.AutoSize = true;
            this.label_wybrny_sklep.BackColor = System.Drawing.SystemColors.Control;
            this.label_wybrny_sklep.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_wybrny_sklep.Location = new System.Drawing.Point(583, 72);
            this.label_wybrny_sklep.Name = "label_wybrny_sklep";
            this.label_wybrny_sklep.Size = new System.Drawing.Size(102, 17);
            this.label_wybrny_sklep.TabIndex = 14;
            this.label_wybrny_sklep.Text = "Wybrany sklep: ";
            // 
            // timer_status_polaczenia
            // 
            this.timer_status_polaczenia.Enabled = true;
            this.timer_status_polaczenia.Interval = 30000;
            this.timer_status_polaczenia.Tick += new System.EventHandler(this.Timer_status_polaczenia_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(436, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Szukaj";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(173, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data przyjęcia";
            // 
            // Pasek_statusu
            // 
            this.Pasek_statusu.BackColor = System.Drawing.Color.LightGray;
            this.Pasek_statusu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureBox_status_polaczenie_z_baza_g,
            this.pictureBox_status_polaczenie_z_baza_r,
            this.label_status_polaczenia_z_baza,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1,
            this.label_wersja});
            this.Pasek_statusu.Location = new System.Drawing.Point(0, 463);
            this.Pasek_statusu.Name = "Pasek_statusu";
            this.Pasek_statusu.Size = new System.Drawing.Size(1214, 22);
            this.Pasek_statusu.SizingGrip = false;
            this.Pasek_statusu.TabIndex = 20;
            this.Pasek_statusu.Text = "statusStrip1";
            // 
            // pictureBox_status_polaczenie_z_baza_g
            // 
            this.pictureBox_status_polaczenie_z_baza_g.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pictureBox_status_polaczenie_z_baza_g.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox_status_polaczenie_z_baza_g.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_status_polaczenie_z_baza_g.Image")));
            this.pictureBox_status_polaczenie_z_baza_g.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.pictureBox_status_polaczenie_z_baza_g.Name = "pictureBox_status_polaczenie_z_baza_g";
            this.pictureBox_status_polaczenie_z_baza_g.Size = new System.Drawing.Size(16, 17);
            // 
            // pictureBox_status_polaczenie_z_baza_r
            // 
            this.pictureBox_status_polaczenie_z_baza_r.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pictureBox_status_polaczenie_z_baza_r.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox_status_polaczenie_z_baza_r.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_status_polaczenie_z_baza_r.Image")));
            this.pictureBox_status_polaczenie_z_baza_r.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.pictureBox_status_polaczenie_z_baza_r.Name = "pictureBox_status_polaczenie_z_baza_r";
            this.pictureBox_status_polaczenie_z_baza_r.Size = new System.Drawing.Size(16, 17);
            this.pictureBox_status_polaczenie_z_baza_r.Visible = false;
            // 
            // label_status_polaczenia_z_baza
            // 
            this.label_status_polaczenia_z_baza.ForeColor = System.Drawing.Color.Black;
            this.label_status_polaczenia_z_baza.Name = "label_status_polaczenia_z_baza";
            this.label_status_polaczenia_z_baza.Size = new System.Drawing.Size(186, 17);
            this.label_status_polaczenia_z_baza.Text = "Połączenie z bazą jest prawidłowe.";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(831, 17);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "Copyright © by ODR";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(124, 17);
            this.toolStripStatusLabel1.Text = "                                      |";
            // 
            // label_wersja
            // 
            this.label_wersja.ForeColor = System.Drawing.Color.Black;
            this.label_wersja.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_wersja.Name = "label_wersja";
            this.label_wersja.Size = new System.Drawing.Size(42, 17);
            this.label_wersja.Text = "Wersja";
            this.label_wersja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_wersja.Click += new System.EventHandler(this.Wersja_Click);
            // 
            // label_wyloguj
            // 
            this.label_wyloguj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_wyloguj.AutoSize = true;
            this.label_wyloguj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_wyloguj.Location = new System.Drawing.Point(1145, 3);
            this.label_wyloguj.Name = "label_wyloguj";
            this.label_wyloguj.Size = new System.Drawing.Size(57, 16);
            this.label_wyloguj.TabIndex = 21;
            this.label_wyloguj.Text = "Wyloguj";
            this.label_wyloguj.Click += new System.EventHandler(this.Label_wyloguj_Click);
            // 
            // label_uzytkownik
            // 
            this.label_uzytkownik.AutoSize = true;
            this.label_uzytkownik.BackColor = System.Drawing.SystemColors.Control;
            this.label_uzytkownik.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_uzytkownik.Location = new System.Drawing.Point(583, 36);
            this.label_uzytkownik.Name = "label_uzytkownik";
            this.label_uzytkownik.Size = new System.Drawing.Size(159, 17);
            this.label_uzytkownik.TabIndex = 22;
            this.label_uzytkownik.Text = "Użytkownik: admin admin";
            // 
            // Okno_glowne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 485);
            this.Controls.Add(this.label_uzytkownik);
            this.Controls.Add(this.label_wyloguj);
            this.Controls.Add(this.Pasek_statusu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_szukaj_zk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_wybrny_sklep);
            this.Controls.Add(this.checkBox_nierozliczone);
            this.Controls.Add(this.checkBox_rozliczone);
            this.Controls.Add(this.dataGridView_zamowienia);
            this.Controls.Add(this.button_nowe_zk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_do);
            this.Controls.Add(this.dateTimePicker_od);
            this.Controls.Add(this.pasek_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.pasek_menu;
            this.MinimumSize = new System.Drawing.Size(1230, 300);
            this.Name = "Okno_glowne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Zamówień Salon Firmowy";
            this.Activated += new System.EventHandler(this.Okno_glowne_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Okno_glowne_FormClosing);
            this.Load += new System.EventHandler(this.Okno_glowne_Load);
            this.Shown += new System.EventHandler(this.Okno_glowne_Shown);
            this.SizeChanged += new System.EventHandler(this.Okno_glowne_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zamowienia)).EndInit();
            this.pasek_menu.ResumeLayout(false);
            this.pasek_menu.PerformLayout();
            this.Pasek_statusu.ResumeLayout(false);
            this.Pasek_statusu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_nowe_zk;
        private System.Windows.Forms.TextBox textBox_szukaj_zk;
        private System.Windows.Forms.MenuStrip pasek_menu;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_nierozliczone;
        private System.Windows.Forms.CheckBox checkBox_rozliczone;
        private System.Windows.Forms.Timer timer_status_polaczenia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem raportToolStripMenuItem;
        private System.Windows.Forms.StatusStrip Pasek_statusu;
        private System.Windows.Forms.ToolStripStatusLabel label_status_polaczenia_z_baza;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel label_wersja;
        private System.Windows.Forms.ToolStripStatusLabel pictureBox_status_polaczenie_z_baza_g;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.DateTimePicker dateTimePicker_od;
        public System.Windows.Forms.DateTimePicker dateTimePicker_do;
        public System.Windows.Forms.DataGridView dataGridView_zamowienia;
        private System.Windows.Forms.Label label_wyloguj;
        public System.Windows.Forms.Label label_uzytkownik;
        public System.Windows.Forms.Label label_wybrny_sklep;
        private System.Windows.Forms.ToolStripStatusLabel pictureBox_status_polaczenie_z_baza_r;
        private System.Windows.Forms.ToolStripMenuItem raportKwotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raportRealizacjiToolStripMenuItem;
    }
}