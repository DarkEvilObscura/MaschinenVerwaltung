
namespace MaschinenVerwaltung
{
    partial class FormHinzufügen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHinzufügen));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnTyp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnGerätenummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOriginalnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBemerkung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTÜV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNichtVorhanden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnButtonSchriftfarbe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnButtonHintergrundfarbe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonSpeichern = new System.Windows.Forms.Button();
            this.buttonAbbrechen = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTyp,
            this.ColumnGerätenummer,
            this.ColumnOriginalnummer,
            this.ColumnBemerkung,
            this.ColumnTÜV,
            this.ColumnNichtVorhanden,
            this.ColumnButtonSchriftfarbe,
            this.ColumnButtonHintergrundfarbe});
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(843, 236);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            this.dataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellLeave);
            // 
            // ColumnTyp
            // 
            this.ColumnTyp.HeaderText = "Typ";
            this.ColumnTyp.Items.AddRange(new object[] {
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
            this.ColumnTyp.Name = "ColumnTyp";
            this.ColumnTyp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTyp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnGerätenummer
            // 
            this.ColumnGerätenummer.HeaderText = "Gerätenummer";
            this.ColumnGerätenummer.Name = "ColumnGerätenummer";
            // 
            // ColumnOriginalnummer
            // 
            this.ColumnOriginalnummer.HeaderText = "Originalnummer";
            this.ColumnOriginalnummer.Name = "ColumnOriginalnummer";
            // 
            // ColumnBemerkung
            // 
            this.ColumnBemerkung.HeaderText = "Bemerkung";
            this.ColumnBemerkung.Name = "ColumnBemerkung";
            // 
            // ColumnTÜV
            // 
            dataGridViewCellStyle1.Format = "MM.yyyy";
            this.ColumnTÜV.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnTÜV.HeaderText = "TÜV";
            this.ColumnTÜV.Name = "ColumnTÜV";
            // 
            // ColumnNichtVorhanden
            // 
            this.ColumnNichtVorhanden.HeaderText = "Nicht Vorhanden";
            this.ColumnNichtVorhanden.Name = "ColumnNichtVorhanden";
            // 
            // ColumnButtonSchriftfarbe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Schriftfarbe";
            this.ColumnButtonSchriftfarbe.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnButtonSchriftfarbe.HeaderText = "";
            this.ColumnButtonSchriftfarbe.Name = "ColumnButtonSchriftfarbe";
            this.ColumnButtonSchriftfarbe.Text = "";
            // 
            // ColumnButtonHintergrundfarbe
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Hintergrundfarbe";
            this.ColumnButtonHintergrundfarbe.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnButtonHintergrundfarbe.HeaderText = "";
            this.ColumnButtonHintergrundfarbe.Name = "ColumnButtonHintergrundfarbe";
            // 
            // buttonSpeichern
            // 
            this.buttonSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSpeichern.Location = new System.Drawing.Point(738, 242);
            this.buttonSpeichern.Name = "buttonSpeichern";
            this.buttonSpeichern.Size = new System.Drawing.Size(93, 24);
            this.buttonSpeichern.TabIndex = 1;
            this.buttonSpeichern.Text = "Speichern";
            this.buttonSpeichern.UseVisualStyleBackColor = true;
            this.buttonSpeichern.Click += new System.EventHandler(this.buttonSpeichern_Click);
            // 
            // buttonAbbrechen
            // 
            this.buttonAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbbrechen.Location = new System.Drawing.Point(639, 243);
            this.buttonAbbrechen.Name = "buttonAbbrechen";
            this.buttonAbbrechen.Size = new System.Drawing.Size(93, 23);
            this.buttonAbbrechen.TabIndex = 2;
            this.buttonAbbrechen.Text = "Abbrechen";
            this.buttonAbbrechen.UseVisualStyleBackColor = true;
            this.buttonAbbrechen.Click += new System.EventHandler(this.buttonAbbrechen_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(260, 65);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 3;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // FormHinzufügen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 274);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.buttonAbbrechen);
            this.Controls.Add(this.buttonSpeichern);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormHinzufügen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maschine hinzufügen";
            this.Load += new System.EventHandler(this.FormHinzufügen_Load);
            this.Resize += new System.EventHandler(this.FormHinzufügen_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSpeichern;
        private System.Windows.Forms.Button buttonAbbrechen;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGerätenummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOriginalnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBemerkung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTÜV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnNichtVorhanden;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnButtonSchriftfarbe;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnButtonHintergrundfarbe;
        private System.Windows.Forms.MonthCalendar monthCalendar;
    }
}