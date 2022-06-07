
namespace MaschinenVerwaltung
{
    partial class FormBearbeiten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBearbeiten));
            this.comboBoxTyp = new System.Windows.Forms.ComboBox();
            this.textBoxGerätenummer = new System.Windows.Forms.TextBox();
            this.textBoxOriginalnummer = new System.Windows.Forms.TextBox();
            this.checkBoxTÜVDatum = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTÜV = new System.Windows.Forms.DateTimePicker();
            this.textBoxBemerkung = new System.Windows.Forms.TextBox();
            this.buttonSaveClose = new System.Windows.Forms.Button();
            this.groupBoxWeitereEinstellungen = new System.Windows.Forms.GroupBox();
            this.pictureBoxBackgroundColor = new System.Windows.Forms.PictureBox();
            this.labelHintergrundfarbe = new System.Windows.Forms.Label();
            this.pictureBoxForeColor = new System.Windows.Forms.PictureBox();
            this.labelSchriftfarbe = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.checkBoxNichtVorhanden = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxWeitereEinstellungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForeColor)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTyp
            // 
            this.comboBoxTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTyp.FormattingEnabled = true;
            this.comboBoxTyp.Items.AddRange(new object[] {
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
            "S4"});
            this.comboBoxTyp.Location = new System.Drawing.Point(12, 14);
            this.comboBoxTyp.Name = "comboBoxTyp";
            this.comboBoxTyp.Size = new System.Drawing.Size(164, 21);
            this.comboBoxTyp.TabIndex = 1;
            // 
            // textBoxGerätenummer
            // 
            this.textBoxGerätenummer.Location = new System.Drawing.Point(182, 15);
            this.textBoxGerätenummer.Name = "textBoxGerätenummer";
            this.textBoxGerätenummer.Size = new System.Drawing.Size(167, 20);
            this.textBoxGerätenummer.TabIndex = 4;
            // 
            // textBoxOriginalnummer
            // 
            this.textBoxOriginalnummer.Location = new System.Drawing.Point(355, 15);
            this.textBoxOriginalnummer.Name = "textBoxOriginalnummer";
            this.textBoxOriginalnummer.Size = new System.Drawing.Size(167, 20);
            this.textBoxOriginalnummer.TabIndex = 6;
            // 
            // checkBoxTÜVDatum
            // 
            this.checkBoxTÜVDatum.AutoSize = true;
            this.checkBoxTÜVDatum.Location = new System.Drawing.Point(11, 228);
            this.checkBoxTÜVDatum.Name = "checkBoxTÜVDatum";
            this.checkBoxTÜVDatum.Size = new System.Drawing.Size(85, 17);
            this.checkBoxTÜVDatum.TabIndex = 7;
            this.checkBoxTÜVDatum.Text = "TÜV-Datum:";
            this.checkBoxTÜVDatum.UseVisualStyleBackColor = true;
            this.checkBoxTÜVDatum.CheckedChanged += new System.EventHandler(this.checkBoxTÜVDatum_CheckedChanged);
            // 
            // dateTimePickerTÜV
            // 
            this.dateTimePickerTÜV.CustomFormat = "MM.yyyy";
            this.dateTimePickerTÜV.Enabled = false;
            this.dateTimePickerTÜV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTÜV.Location = new System.Drawing.Point(137, 226);
            this.dateTimePickerTÜV.Name = "dateTimePickerTÜV";
            this.dateTimePickerTÜV.Size = new System.Drawing.Size(98, 20);
            this.dateTimePickerTÜV.TabIndex = 9;
            // 
            // textBoxBemerkung
            // 
            this.textBoxBemerkung.Location = new System.Drawing.Point(12, 41);
            this.textBoxBemerkung.Multiline = true;
            this.textBoxBemerkung.Name = "textBoxBemerkung";
            this.textBoxBemerkung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBemerkung.Size = new System.Drawing.Size(510, 179);
            this.textBoxBemerkung.TabIndex = 10;
            // 
            // buttonSaveClose
            // 
            this.buttonSaveClose.Location = new System.Drawing.Point(383, 307);
            this.buttonSaveClose.Name = "buttonSaveClose";
            this.buttonSaveClose.Size = new System.Drawing.Size(139, 30);
            this.buttonSaveClose.TabIndex = 12;
            this.buttonSaveClose.Text = "Speichern && Schließen";
            this.buttonSaveClose.UseVisualStyleBackColor = true;
            this.buttonSaveClose.Click += new System.EventHandler(this.buttonSaveClose_Click);
            // 
            // groupBoxWeitereEinstellungen
            // 
            this.groupBoxWeitereEinstellungen.Controls.Add(this.pictureBoxBackgroundColor);
            this.groupBoxWeitereEinstellungen.Controls.Add(this.labelHintergrundfarbe);
            this.groupBoxWeitereEinstellungen.Controls.Add(this.pictureBoxForeColor);
            this.groupBoxWeitereEinstellungen.Controls.Add(this.labelSchriftfarbe);
            this.groupBoxWeitereEinstellungen.Location = new System.Drawing.Point(354, 228);
            this.groupBoxWeitereEinstellungen.Name = "groupBoxWeitereEinstellungen";
            this.groupBoxWeitereEinstellungen.Size = new System.Drawing.Size(168, 73);
            this.groupBoxWeitereEinstellungen.TabIndex = 13;
            this.groupBoxWeitereEinstellungen.TabStop = false;
            this.groupBoxWeitereEinstellungen.Text = "Weitere Einstellungen";
            // 
            // pictureBoxBackgroundColor
            // 
            this.pictureBoxBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBackgroundColor.Location = new System.Drawing.Point(121, 44);
            this.pictureBoxBackgroundColor.Name = "pictureBoxBackgroundColor";
            this.pictureBoxBackgroundColor.Size = new System.Drawing.Size(34, 23);
            this.pictureBoxBackgroundColor.TabIndex = 15;
            this.pictureBoxBackgroundColor.TabStop = false;
            this.pictureBoxBackgroundColor.Click += new System.EventHandler(this.pictureBoxBackgroundColor_Click);
            // 
            // labelHintergrundfarbe
            // 
            this.labelHintergrundfarbe.AutoSize = true;
            this.labelHintergrundfarbe.Location = new System.Drawing.Point(26, 48);
            this.labelHintergrundfarbe.Name = "labelHintergrundfarbe";
            this.labelHintergrundfarbe.Size = new System.Drawing.Size(89, 13);
            this.labelHintergrundfarbe.TabIndex = 14;
            this.labelHintergrundfarbe.Text = "Hintergrundfarbe:";
            // 
            // pictureBoxForeColor
            // 
            this.pictureBoxForeColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxForeColor.Location = new System.Drawing.Point(121, 12);
            this.pictureBoxForeColor.Name = "pictureBoxForeColor";
            this.pictureBoxForeColor.Size = new System.Drawing.Size(34, 26);
            this.pictureBoxForeColor.TabIndex = 13;
            this.pictureBoxForeColor.TabStop = false;
            this.pictureBoxForeColor.Click += new System.EventHandler(this.pictureBoxForeColor_Click);
            // 
            // labelSchriftfarbe
            // 
            this.labelSchriftfarbe.AutoSize = true;
            this.labelSchriftfarbe.Location = new System.Drawing.Point(51, 18);
            this.labelSchriftfarbe.Name = "labelSchriftfarbe";
            this.labelSchriftfarbe.Size = new System.Drawing.Size(64, 13);
            this.labelSchriftfarbe.TabIndex = 12;
            this.labelSchriftfarbe.Text = "Schriftfarbe:";
            // 
            // checkBoxNichtVorhanden
            // 
            this.checkBoxNichtVorhanden.AutoSize = true;
            this.checkBoxNichtVorhanden.Location = new System.Drawing.Point(12, 315);
            this.checkBoxNichtVorhanden.Name = "checkBoxNichtVorhanden";
            this.checkBoxNichtVorhanden.Size = new System.Drawing.Size(191, 17);
            this.checkBoxNichtVorhanden.TabIndex = 14;
            this.checkBoxNichtVorhanden.Text = "Maschine ist nicht mehr vorhanden";
            this.checkBoxNichtVorhanden.UseVisualStyleBackColor = true;
            this.checkBoxNichtVorhanden.CheckedChanged += new System.EventHandler(this.checkBoxNichtVorhanden_CheckedChanged);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Beschreibung:";
            // 
            // FormBearbeiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 341);
            this.Controls.Add(this.checkBoxNichtVorhanden);
            this.Controls.Add(this.groupBoxWeitereEinstellungen);
            this.Controls.Add(this.buttonSaveClose);
            this.Controls.Add(this.textBoxBemerkung);
            this.Controls.Add(this.dateTimePickerTÜV);
            this.Controls.Add(this.checkBoxTÜVDatum);
            this.Controls.Add(this.textBoxOriginalnummer);
            this.Controls.Add(this.textBoxGerätenummer);
            this.Controls.Add(this.comboBoxTyp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormBearbeiten";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daten bearbeiten";
            this.Load += new System.EventHandler(this.FormBearbeiten_Load);
            this.groupBoxWeitereEinstellungen.ResumeLayout(false);
            this.groupBoxWeitereEinstellungen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForeColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTyp;
        private System.Windows.Forms.TextBox textBoxGerätenummer;
        private System.Windows.Forms.TextBox textBoxOriginalnummer;
        private System.Windows.Forms.CheckBox checkBoxTÜVDatum;
        private System.Windows.Forms.DateTimePicker dateTimePickerTÜV;
        private System.Windows.Forms.TextBox textBoxBemerkung;
        private System.Windows.Forms.Button buttonSaveClose;
        private System.Windows.Forms.GroupBox groupBoxWeitereEinstellungen;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundColor;
        private System.Windows.Forms.Label labelHintergrundfarbe;
        private System.Windows.Forms.PictureBox pictureBoxForeColor;
        private System.Windows.Forms.Label labelSchriftfarbe;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckBox checkBoxNichtVorhanden;
        private System.Windows.Forms.ToolTip toolTip;
    }
}