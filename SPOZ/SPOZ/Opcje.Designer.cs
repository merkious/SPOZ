namespace SPOZ
{
    partial class Opcje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opcje));
            this.karty_opcji = new System.Windows.Forms.TabControl();
            this.karta_glowna = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_haslo_2 = new System.Windows.Forms.Label();
            this.label_stare_haslo = new System.Windows.Forms.Label();
            this.label_nowe_haslo = new System.Windows.Forms.Label();
            this.button_zmien_haslo = new System.Windows.Forms.Button();
            this.textBox_poprzednie = new System.Windows.Forms.TextBox();
            this.textBox_nowe = new System.Windows.Forms.TextBox();
            this.textBox_nowe_2 = new System.Windows.Forms.TextBox();
            this.button_spr_aktualizacje = new System.Windows.Forms.Button();
            this.uruchamiaj_z_systemem_checkbox = new System.Windows.Forms.CheckBox();
            this.karta_menadzera = new System.Windows.Forms.TabPage();
            this.button_zapisz_opcje = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_nowy_gratis = new System.Windows.Forms.Button();
            this.button_usun_gratis = new System.Windows.Forms.Button();
            this.button_edytuj_grartis = new System.Windows.Forms.Button();
            this.comboBox_gratis = new System.Windows.Forms.ComboBox();
            this.groupBox_przypisanie = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_sprzedawcy = new System.Windows.Forms.ComboBox();
            this.comboBox_sklep_sprzedawcy = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_sklep_do_DGV = new System.Windows.Forms.ComboBox();
            this.groupBox_nowy_sprzedawca = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_usun_sprzedawce = new System.Windows.Forms.Button();
            this.comboBox_sprzedawce_do_usuniecia = new System.Windows.Forms.ComboBox();
            this.button_nowy_sprzedawca = new System.Windows.Forms.Button();
            this.karty_opcji.SuspendLayout();
            this.karta_glowna.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.karta_menadzera.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_przypisanie.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_nowy_sprzedawca.SuspendLayout();
            this.SuspendLayout();
            // 
            // karty_opcji
            // 
            this.karty_opcji.Controls.Add(this.karta_glowna);
            this.karty_opcji.Controls.Add(this.karta_menadzera);
            this.karty_opcji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.karty_opcji.HotTrack = true;
            this.karty_opcji.Location = new System.Drawing.Point(0, 0);
            this.karty_opcji.Name = "karty_opcji";
            this.karty_opcji.SelectedIndex = 0;
            this.karty_opcji.Size = new System.Drawing.Size(654, 411);
            this.karty_opcji.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.karty_opcji.TabIndex = 0;
            // 
            // karta_glowna
            // 
            this.karta_glowna.Controls.Add(this.groupBox3);
            this.karta_glowna.Controls.Add(this.button_spr_aktualizacje);
            this.karta_glowna.Controls.Add(this.uruchamiaj_z_systemem_checkbox);
            this.karta_glowna.Location = new System.Drawing.Point(4, 22);
            this.karta_glowna.Name = "karta_glowna";
            this.karta_glowna.Padding = new System.Windows.Forms.Padding(3);
            this.karta_glowna.Size = new System.Drawing.Size(646, 385);
            this.karta_glowna.TabIndex = 0;
            this.karta_glowna.Text = "Główne";
            this.karta_glowna.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.label_haslo_2);
            this.groupBox3.Controls.Add(this.label_stare_haslo);
            this.groupBox3.Controls.Add(this.label_nowe_haslo);
            this.groupBox3.Controls.Add(this.button_zmien_haslo);
            this.groupBox3.Controls.Add(this.textBox_poprzednie);
            this.groupBox3.Controls.Add(this.textBox_nowe);
            this.groupBox3.Controls.Add(this.textBox_nowe_2);
            this.groupBox3.Location = new System.Drawing.Point(200, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 224);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zmień hasło";
            // 
            // label_haslo_2
            // 
            this.label_haslo_2.AutoSize = true;
            this.label_haslo_2.Location = new System.Drawing.Point(71, 133);
            this.label_haslo_2.Name = "label_haslo_2";
            this.label_haslo_2.Size = new System.Drawing.Size(104, 13);
            this.label_haslo_2.TabIndex = 4;
            this.label_haslo_2.Text = "Powtórz nowe hasło";
            // 
            // label_stare_haslo
            // 
            this.label_stare_haslo.AutoSize = true;
            this.label_stare_haslo.Location = new System.Drawing.Point(78, 43);
            this.label_stare_haslo.Name = "label_stare_haslo";
            this.label_stare_haslo.Size = new System.Drawing.Size(90, 13);
            this.label_stare_haslo.TabIndex = 0;
            this.label_stare_haslo.Text = "Poprzednie hasło";
            // 
            // label_nowe_haslo
            // 
            this.label_nowe_haslo.AutoSize = true;
            this.label_nowe_haslo.Location = new System.Drawing.Point(91, 90);
            this.label_nowe_haslo.Name = "label_nowe_haslo";
            this.label_nowe_haslo.Size = new System.Drawing.Size(65, 13);
            this.label_nowe_haslo.TabIndex = 2;
            this.label_nowe_haslo.Text = "Nowe hasło";
            // 
            // button_zmien_haslo
            // 
            this.button_zmien_haslo.Location = new System.Drawing.Point(86, 174);
            this.button_zmien_haslo.Name = "button_zmien_haslo";
            this.button_zmien_haslo.Size = new System.Drawing.Size(75, 23);
            this.button_zmien_haslo.TabIndex = 6;
            this.button_zmien_haslo.Text = "Zmień hasło";
            this.button_zmien_haslo.UseVisualStyleBackColor = true;
            this.button_zmien_haslo.Click += new System.EventHandler(this.Button_zmien_haslo_Click);
            // 
            // textBox_poprzednie
            // 
            this.textBox_poprzednie.Location = new System.Drawing.Point(60, 61);
            this.textBox_poprzednie.Name = "textBox_poprzednie";
            this.textBox_poprzednie.PasswordChar = '#';
            this.textBox_poprzednie.Size = new System.Drawing.Size(129, 20);
            this.textBox_poprzednie.TabIndex = 1;
            // 
            // textBox_nowe
            // 
            this.textBox_nowe.Location = new System.Drawing.Point(60, 107);
            this.textBox_nowe.Name = "textBox_nowe";
            this.textBox_nowe.PasswordChar = '#';
            this.textBox_nowe.Size = new System.Drawing.Size(129, 20);
            this.textBox_nowe.TabIndex = 3;
            // 
            // textBox_nowe_2
            // 
            this.textBox_nowe_2.Location = new System.Drawing.Point(60, 150);
            this.textBox_nowe_2.Name = "textBox_nowe_2";
            this.textBox_nowe_2.PasswordChar = '#';
            this.textBox_nowe_2.Size = new System.Drawing.Size(129, 20);
            this.textBox_nowe_2.TabIndex = 5;
            // 
            // button_spr_aktualizacje
            // 
            this.button_spr_aktualizacje.Location = new System.Drawing.Point(252, 59);
            this.button_spr_aktualizacje.Name = "button_spr_aktualizacje";
            this.button_spr_aktualizacje.Size = new System.Drawing.Size(143, 39);
            this.button_spr_aktualizacje.TabIndex = 1;
            this.button_spr_aktualizacje.Text = "Sprawdź aktualizację";
            this.button_spr_aktualizacje.UseVisualStyleBackColor = true;
            this.button_spr_aktualizacje.Click += new System.EventHandler(this.Button_spr_aktualizacje_Click);
            // 
            // uruchamiaj_z_systemem_checkbox
            // 
            this.uruchamiaj_z_systemem_checkbox.AutoSize = true;
            this.uruchamiaj_z_systemem_checkbox.Location = new System.Drawing.Point(207, 29);
            this.uruchamiaj_z_systemem_checkbox.Name = "uruchamiaj_z_systemem_checkbox";
            this.uruchamiaj_z_systemem_checkbox.Size = new System.Drawing.Size(237, 17);
            this.uruchamiaj_z_systemem_checkbox.TabIndex = 0;
            this.uruchamiaj_z_systemem_checkbox.Text = "Uruchamiaj program wraz ze startem systemu";
            this.uruchamiaj_z_systemem_checkbox.UseVisualStyleBackColor = true;
            this.uruchamiaj_z_systemem_checkbox.CheckedChanged += new System.EventHandler(this.Uruchamiaj_z_systemem_checkbox_CheckedChanged);
            // 
            // karta_menadzera
            // 
            this.karta_menadzera.BackColor = System.Drawing.Color.White;
            this.karta_menadzera.Controls.Add(this.button_zapisz_opcje);
            this.karta_menadzera.Controls.Add(this.groupBox2);
            this.karta_menadzera.Controls.Add(this.groupBox_przypisanie);
            this.karta_menadzera.Controls.Add(this.groupBox1);
            this.karta_menadzera.Controls.Add(this.groupBox_nowy_sprzedawca);
            this.karta_menadzera.Location = new System.Drawing.Point(4, 22);
            this.karta_menadzera.Name = "karta_menadzera";
            this.karta_menadzera.Size = new System.Drawing.Size(646, 385);
            this.karta_menadzera.TabIndex = 2;
            this.karta_menadzera.Text = "Menadżer";
            // 
            // button_zapisz_opcje
            // 
            this.button_zapisz_opcje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_zapisz_opcje.Location = new System.Drawing.Point(283, 339);
            this.button_zapisz_opcje.Name = "button_zapisz_opcje";
            this.button_zapisz_opcje.Size = new System.Drawing.Size(80, 30);
            this.button_zapisz_opcje.TabIndex = 6;
            this.button_zapisz_opcje.Text = "Zapisz";
            this.button_zapisz_opcje.UseVisualStyleBackColor = true;
            this.button_zapisz_opcje.Click += new System.EventHandler(this.button_zapisz_opcje_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.button_nowy_gratis);
            this.groupBox2.Controls.Add(this.button_usun_gratis);
            this.groupBox2.Controls.Add(this.button_edytuj_grartis);
            this.groupBox2.Controls.Add(this.comboBox_gratis);
            this.groupBox2.Location = new System.Drawing.Point(338, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gratisy";
            // 
            // button_nowy_gratis
            // 
            this.button_nowy_gratis.Location = new System.Drawing.Point(109, 28);
            this.button_nowy_gratis.Name = "button_nowy_gratis";
            this.button_nowy_gratis.Size = new System.Drawing.Size(75, 23);
            this.button_nowy_gratis.TabIndex = 6;
            this.button_nowy_gratis.Text = "Stwórz";
            this.button_nowy_gratis.UseVisualStyleBackColor = true;
            this.button_nowy_gratis.Click += new System.EventHandler(this.button_stworz_gratis_Click);
            // 
            // button_usun_gratis
            // 
            this.button_usun_gratis.Enabled = false;
            this.button_usun_gratis.Location = new System.Drawing.Point(58, 99);
            this.button_usun_gratis.Name = "button_usun_gratis";
            this.button_usun_gratis.Size = new System.Drawing.Size(75, 23);
            this.button_usun_gratis.TabIndex = 5;
            this.button_usun_gratis.Text = "Usuń";
            this.button_usun_gratis.UseVisualStyleBackColor = true;
            this.button_usun_gratis.Click += new System.EventHandler(this.button_usun_gratis_Click);
            // 
            // button_edytuj_grartis
            // 
            this.button_edytuj_grartis.Enabled = false;
            this.button_edytuj_grartis.Location = new System.Drawing.Point(159, 99);
            this.button_edytuj_grartis.Name = "button_edytuj_grartis";
            this.button_edytuj_grartis.Size = new System.Drawing.Size(75, 23);
            this.button_edytuj_grartis.TabIndex = 4;
            this.button_edytuj_grartis.Text = "Edytuj";
            this.button_edytuj_grartis.UseVisualStyleBackColor = true;
            this.button_edytuj_grartis.Click += new System.EventHandler(this.button_edytuj_gratis_Click);
            // 
            // comboBox_gratis
            // 
            this.comboBox_gratis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gratis.FormattingEnabled = true;
            this.comboBox_gratis.Location = new System.Drawing.Point(10, 73);
            this.comboBox_gratis.Name = "comboBox_gratis";
            this.comboBox_gratis.Size = new System.Drawing.Size(273, 21);
            this.comboBox_gratis.TabIndex = 2;
            this.comboBox_gratis.TextChanged += new System.EventHandler(this.comboBox_gratis_TextChanged);
            this.comboBox_gratis.Click += new System.EventHandler(this.comboBox_gratis_Click);
            // 
            // groupBox_przypisanie
            // 
            this.groupBox_przypisanie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_przypisanie.Controls.Add(this.label5);
            this.groupBox_przypisanie.Controls.Add(this.label6);
            this.groupBox_przypisanie.Controls.Add(this.comboBox_sprzedawcy);
            this.groupBox_przypisanie.Controls.Add(this.comboBox_sklep_sprzedawcy);
            this.groupBox_przypisanie.Location = new System.Drawing.Point(17, 42);
            this.groupBox_przypisanie.Name = "groupBox_przypisanie";
            this.groupBox_przypisanie.Size = new System.Drawing.Size(293, 138);
            this.groupBox_przypisanie.TabIndex = 0;
            this.groupBox_przypisanie.TabStop = false;
            this.groupBox_przypisanie.Text = "Przypisz sprzedawcę do wybranego sklepu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Wybierz sklep";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Wybierz sprzedawcę";
            // 
            // comboBox_sprzedawcy
            // 
            this.comboBox_sprzedawcy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sprzedawcy.FormattingEnabled = true;
            this.comboBox_sprzedawcy.Location = new System.Drawing.Point(10, 44);
            this.comboBox_sprzedawcy.Name = "comboBox_sprzedawcy";
            this.comboBox_sprzedawcy.Size = new System.Drawing.Size(273, 21);
            this.comboBox_sprzedawcy.TabIndex = 1;
            this.comboBox_sprzedawcy.TextChanged += new System.EventHandler(this.ComboBox_sprzedawcy_TextChanged);
            // 
            // comboBox_sklep_sprzedawcy
            // 
            this.comboBox_sklep_sprzedawcy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sklep_sprzedawcy.FormattingEnabled = true;
            this.comboBox_sklep_sprzedawcy.Location = new System.Drawing.Point(10, 92);
            this.comboBox_sklep_sprzedawcy.Name = "comboBox_sklep_sprzedawcy";
            this.comboBox_sklep_sprzedawcy.Size = new System.Drawing.Size(273, 21);
            this.comboBox_sklep_sprzedawcy.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_sklep_do_DGV);
            this.groupBox1.Location = new System.Drawing.Point(338, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Przełącz się między sklepami";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Wybierz sklep";
            // 
            // comboBox_sklep_do_DGV
            // 
            this.comboBox_sklep_do_DGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sklep_do_DGV.FormattingEnabled = true;
            this.comboBox_sklep_do_DGV.Location = new System.Drawing.Point(10, 56);
            this.comboBox_sklep_do_DGV.Name = "comboBox_sklep_do_DGV";
            this.comboBox_sklep_do_DGV.Size = new System.Drawing.Size(273, 21);
            this.comboBox_sklep_do_DGV.TabIndex = 1;
            // 
            // groupBox_nowy_sprzedawca
            // 
            this.groupBox_nowy_sprzedawca.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_nowy_sprzedawca.Controls.Add(this.label2);
            this.groupBox_nowy_sprzedawca.Controls.Add(this.button_usun_sprzedawce);
            this.groupBox_nowy_sprzedawca.Controls.Add(this.comboBox_sprzedawce_do_usuniecia);
            this.groupBox_nowy_sprzedawca.Controls.Add(this.button_nowy_sprzedawca);
            this.groupBox_nowy_sprzedawca.Location = new System.Drawing.Point(15, 210);
            this.groupBox_nowy_sprzedawca.Name = "groupBox_nowy_sprzedawca";
            this.groupBox_nowy_sprzedawca.Size = new System.Drawing.Size(293, 114);
            this.groupBox_nowy_sprzedawca.TabIndex = 1;
            this.groupBox_nowy_sprzedawca.TabStop = false;
            this.groupBox_nowy_sprzedawca.Text = "Zarządzaj sprzedawcami";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wybierz sprzedawcę do usunięcia";
            // 
            // button_usun_sprzedawce
            // 
            this.button_usun_sprzedawce.Location = new System.Drawing.Point(159, 68);
            this.button_usun_sprzedawce.Name = "button_usun_sprzedawce";
            this.button_usun_sprzedawce.Size = new System.Drawing.Size(75, 23);
            this.button_usun_sprzedawce.TabIndex = 3;
            this.button_usun_sprzedawce.Text = "Usuń";
            this.button_usun_sprzedawce.UseVisualStyleBackColor = true;
            this.button_usun_sprzedawce.Click += new System.EventHandler(this.button_usun_sprzedawce_Click);
            // 
            // comboBox_sprzedawce_do_usuniecia
            // 
            this.comboBox_sprzedawce_do_usuniecia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sprzedawce_do_usuniecia.FormattingEnabled = true;
            this.comboBox_sprzedawce_do_usuniecia.Location = new System.Drawing.Point(113, 41);
            this.comboBox_sprzedawce_do_usuniecia.Name = "comboBox_sprzedawce_do_usuniecia";
            this.comboBox_sprzedawce_do_usuniecia.Size = new System.Drawing.Size(165, 21);
            this.comboBox_sprzedawce_do_usuniecia.TabIndex = 2;
            // 
            // button_nowy_sprzedawca
            // 
            this.button_nowy_sprzedawca.Location = new System.Drawing.Point(11, 41);
            this.button_nowy_sprzedawca.Name = "button_nowy_sprzedawca";
            this.button_nowy_sprzedawca.Size = new System.Drawing.Size(75, 36);
            this.button_nowy_sprzedawca.TabIndex = 0;
            this.button_nowy_sprzedawca.Text = "Dodaj nowego";
            this.button_nowy_sprzedawca.UseVisualStyleBackColor = true;
            this.button_nowy_sprzedawca.Click += new System.EventHandler(this.Button_nowy_sprzedawca_Click);
            // 
            // Opcje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 411);
            this.Controls.Add(this.karty_opcji);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Opcje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opcje";
            this.Load += new System.EventHandler(this.Opcje_Load);
            this.karty_opcji.ResumeLayout(false);
            this.karta_glowna.ResumeLayout(false);
            this.karta_glowna.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.karta_menadzera.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox_przypisanie.ResumeLayout(false);
            this.groupBox_przypisanie.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_nowy_sprzedawca.ResumeLayout(false);
            this.groupBox_nowy_sprzedawca.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl karty_opcji;
        private System.Windows.Forms.TabPage karta_glowna;
        private System.Windows.Forms.TabPage karta_menadzera;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_haslo_2;
        private System.Windows.Forms.Label label_stare_haslo;
        private System.Windows.Forms.Label label_nowe_haslo;
        private System.Windows.Forms.Button button_zmien_haslo;
        private System.Windows.Forms.TextBox textBox_poprzednie;
        private System.Windows.Forms.TextBox textBox_nowe;
        private System.Windows.Forms.TextBox textBox_nowe_2;
        private System.Windows.Forms.CheckBox uruchamiaj_z_systemem_checkbox;
        private System.Windows.Forms.Button button_zapisz_opcje;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox_przypisanie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_sprzedawcy;
        private System.Windows.Forms.ComboBox comboBox_sklep_sprzedawcy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_sklep_do_DGV;
        private System.Windows.Forms.GroupBox groupBox_nowy_sprzedawca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_usun_sprzedawce;
        private System.Windows.Forms.ComboBox comboBox_sprzedawce_do_usuniecia;
        private System.Windows.Forms.Button button_nowy_sprzedawca;
        private System.Windows.Forms.Button button_nowy_gratis;
        private System.Windows.Forms.Button button_usun_gratis;
        private System.Windows.Forms.Button button_edytuj_grartis;
        public System.Windows.Forms.ComboBox comboBox_gratis;
        public System.Windows.Forms.Button button_spr_aktualizacje;
    }
}