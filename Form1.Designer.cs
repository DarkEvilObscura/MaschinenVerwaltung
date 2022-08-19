namespace MaschinenVerwaltung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schriftartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aufUpdatesPrüfenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxMaschinenListe = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMaschineHinzufügen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMaschineSuchen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_AnzahlMaschinen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEingeloggt = new System.Windows.Forms.ToolStripStatusLabel();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(0, 52);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(894, 532);
            this.dataGridView.TabIndex = 11;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            this.dataGridView.Resize += new System.EventHandler(this.dataGridView_Resize);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.ansichtToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(894, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.exportierenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Image = global::MaschinenVerwaltung.Properties.Resources.key;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // exportierenToolStripMenuItem
            // 
            this.exportierenToolStripMenuItem.Enabled = false;
            this.exportierenToolStripMenuItem.Image = global::MaschinenVerwaltung.Properties.Resources.excel;
            this.exportierenToolStripMenuItem.Name = "exportierenToolStripMenuItem";
            this.exportierenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportierenToolStripMenuItem.Text = "Exportieren";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Image = global::MaschinenVerwaltung.Properties.Resources.exit;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schriftartToolStripMenuItem});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // schriftartToolStripMenuItem
            // 
            this.schriftartToolStripMenuItem.Image = global::MaschinenVerwaltung.Properties.Resources.fontsize;
            this.schriftartToolStripMenuItem.Name = "schriftartToolStripMenuItem";
            this.schriftartToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.schriftartToolStripMenuItem.Text = "Schriftart...";
            this.schriftartToolStripMenuItem.Click += new System.EventHandler(this.schriftartToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aufUpdatesPrüfenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // aufUpdatesPrüfenToolStripMenuItem
            // 
            this.aufUpdatesPrüfenToolStripMenuItem.Image = global::MaschinenVerwaltung.Properties.Resources.update;
            this.aufUpdatesPrüfenToolStripMenuItem.Name = "aufUpdatesPrüfenToolStripMenuItem";
            this.aufUpdatesPrüfenToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aufUpdatesPrüfenToolStripMenuItem.Text = "Auf Updates prüfen";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Image = global::MaschinenVerwaltung.Properties.Resources.information;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxMaschinenListe,
            this.toolStripSeparator1,
            this.toolStripButtonMaschineHinzufügen,
            this.toolStripButtonMaschineSuchen,
            this.toolStripButtonRefresh,
            this.toolStripButtonPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(894, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBoxMaschinenListe
            // 
            this.toolStripComboBoxMaschinenListe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxMaschinenListe.DropDownWidth = 175;
            this.toolStripComboBoxMaschinenListe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxMaschinenListe.Items.AddRange(new object[] {
            "4070",
            "5190",
            "6080",
            "7081",
            "8080",
            "Art.S",
            "Breva",
            "Centura",
            "Prima Advance",
            "S3",
            "S4",
            "Nur TÜV-Abgelaufene Maschinen"});
            this.toolStripComboBoxMaschinenListe.Name = "toolStripComboBoxMaschinenListe";
            this.toolStripComboBoxMaschinenListe.Size = new System.Drawing.Size(175, 25);
            this.toolStripComboBoxMaschinenListe.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxMaschinenListe_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMaschineHinzufügen
            // 
            this.toolStripButtonMaschineHinzufügen.Image = global::MaschinenVerwaltung.Properties.Resources.add;
            this.toolStripButtonMaschineHinzufügen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMaschineHinzufügen.Name = "toolStripButtonMaschineHinzufügen";
            this.toolStripButtonMaschineHinzufügen.Size = new System.Drawing.Size(141, 22);
            this.toolStripButtonMaschineHinzufügen.Text = "Maschine hinzufügen";
            this.toolStripButtonMaschineHinzufügen.Click += new System.EventHandler(this.toolStripButtonMaschineHinzufügen_Click);
            // 
            // toolStripButtonMaschineSuchen
            // 
            this.toolStripButtonMaschineSuchen.Image = global::MaschinenVerwaltung.Properties.Resources.search;
            this.toolStripButtonMaschineSuchen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMaschineSuchen.Name = "toolStripButtonMaschineSuchen";
            this.toolStripButtonMaschineSuchen.Size = new System.Drawing.Size(119, 22);
            this.toolStripButtonMaschineSuchen.Text = "Maschine suchen";
            this.toolStripButtonMaschineSuchen.Click += new System.EventHandler(this.toolStripButtonMaschineSuchen_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::MaschinenVerwaltung.Properties.Resources.refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonRefresh.Text = "Aktualisieren";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.Image = global::MaschinenVerwaltung.Properties.Resources.printer;
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(71, 22);
            this.toolStripButtonPrint.Text = "Drucken";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_AnzahlMaschinen,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelEingeloggt});
            this.statusStrip.Location = new System.Drawing.Point(0, 581);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(894, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_AnzahlMaschinen
            // 
            this.toolStripStatusLabel_AnzahlMaschinen.Name = "toolStripStatusLabel_AnzahlMaschinen";
            this.toolStripStatusLabel_AnzahlMaschinen.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(863, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabelEingeloggt
            // 
            this.toolStripStatusLabelEingeloggt.Image = global::MaschinenVerwaltung.Properties.Resources.key;
            this.toolStripStatusLabelEingeloggt.Name = "toolStripStatusLabelEingeloggt";
            this.toolStripStatusLabelEingeloggt.Size = new System.Drawing.Size(16, 17);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(894, 603);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaschinenVerwaltung";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schriftartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aufUpdatesPrüfenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMaschinenListe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMaschineHinzufügen;
        private System.Windows.Forms.ToolStripButton toolStripButtonMaschineSuchen;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_AnzahlMaschinen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEingeloggt;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
    }
}

