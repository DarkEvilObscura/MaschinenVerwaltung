
namespace MaschinenVerwaltung
{
    partial class FormSuchen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuchen));
            this.buttonSuchen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSuchen = new System.Windows.Forms.TextBox();
            this.comboBoxSuchkriterium = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTÜV1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTÜV2 = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxFarbe = new System.Windows.Forms.PictureBox();
            this.labelFarbe = new System.Windows.Forms.Label();
            this.dataGridViewSuchergebnisse = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTreffer = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuchergebnisse)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSuchen
            // 
            this.buttonSuchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSuchen.Location = new System.Drawing.Point(513, 28);
            this.buttonSuchen.Name = "buttonSuchen";
            this.buttonSuchen.Size = new System.Drawing.Size(113, 25);
            this.buttonSuchen.TabIndex = 1;
            this.buttonSuchen.Text = "Suchen";
            this.buttonSuchen.UseVisualStyleBackColor = true;
            this.buttonSuchen.Click += new System.EventHandler(this.buttonSuchen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxSuchen);
            this.groupBox1.Controls.Add(this.comboBoxSuchkriterium);
            this.groupBox1.Controls.Add(this.dateTimePickerTÜV1);
            this.groupBox1.Controls.Add(this.dateTimePickerTÜV2);
            this.groupBox1.Controls.Add(this.pictureBoxFarbe);
            this.groupBox1.Controls.Add(this.labelFarbe);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suchkriterium";
            // 
            // textBoxSuchen
            // 
            this.textBoxSuchen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSuchen.Location = new System.Drawing.Point(216, 19);
            this.textBoxSuchen.Name = "textBoxSuchen";
            this.textBoxSuchen.Size = new System.Drawing.Size(273, 20);
            this.textBoxSuchen.TabIndex = 22;
            // 
            // comboBoxSuchkriterium
            // 
            this.comboBoxSuchkriterium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSuchkriterium.FormattingEnabled = true;
            this.comboBoxSuchkriterium.Items.AddRange(new object[] {
            "Gerätenummer",
            "Originalnummer",
            "Bemerkung",
            "Mit TÜV-Datum",
            "Mit TÜV-Datum (von - bis)",
            "Ohne TÜV-Datum",
            "Nicht mehr vorhanden",
            "Schriftfarbe",
            "Hintergrundfarbe"});
            this.comboBoxSuchkriterium.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSuchkriterium.Name = "comboBoxSuchkriterium";
            this.comboBoxSuchkriterium.Size = new System.Drawing.Size(204, 21);
            this.comboBoxSuchkriterium.TabIndex = 3;
            this.comboBoxSuchkriterium.SelectedIndexChanged += new System.EventHandler(this.comboBoxSuchkriterium_SelectedIndexChanged);
            // 
            // dateTimePickerTÜV1
            // 
            this.dateTimePickerTÜV1.CustomFormat = "MM.yyyy";
            this.dateTimePickerTÜV1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTÜV1.Location = new System.Drawing.Point(216, 19);
            this.dateTimePickerTÜV1.Name = "dateTimePickerTÜV1";
            this.dateTimePickerTÜV1.Size = new System.Drawing.Size(89, 20);
            this.dateTimePickerTÜV1.TabIndex = 15;
            this.dateTimePickerTÜV1.Visible = false;
            // 
            // dateTimePickerTÜV2
            // 
            this.dateTimePickerTÜV2.CustomFormat = "MM.yyyy";
            this.dateTimePickerTÜV2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTÜV2.Location = new System.Drawing.Point(331, 19);
            this.dateTimePickerTÜV2.Name = "dateTimePickerTÜV2";
            this.dateTimePickerTÜV2.Size = new System.Drawing.Size(89, 20);
            this.dateTimePickerTÜV2.TabIndex = 16;
            this.dateTimePickerTÜV2.Visible = false;
            // 
            // pictureBoxFarbe
            // 
            this.pictureBoxFarbe.BackColor = System.Drawing.Color.Black;
            this.pictureBoxFarbe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFarbe.Location = new System.Drawing.Point(216, 19);
            this.pictureBoxFarbe.Name = "pictureBoxFarbe";
            this.pictureBoxFarbe.Size = new System.Drawing.Size(204, 20);
            this.pictureBoxFarbe.TabIndex = 23;
            this.pictureBoxFarbe.TabStop = false;
            this.pictureBoxFarbe.Visible = false;
            this.pictureBoxFarbe.Click += new System.EventHandler(this.pictureBoxFarbe_Click);
            // 
            // labelFarbe
            // 
            this.labelFarbe.AutoSize = true;
            this.labelFarbe.BackColor = System.Drawing.Color.Black;
            this.labelFarbe.ForeColor = System.Drawing.Color.White;
            this.labelFarbe.Location = new System.Drawing.Point(287, 22);
            this.labelFarbe.Name = "labelFarbe";
            this.labelFarbe.Size = new System.Drawing.Size(55, 13);
            this.labelFarbe.TabIndex = 24;
            this.labelFarbe.Text = "Klick mich";
            this.labelFarbe.Visible = false;
            this.labelFarbe.Click += new System.EventHandler(this.labelFarbe_Click);
            // 
            // dataGridViewSuchergebnisse
            // 
            this.dataGridViewSuchergebnisse.AllowUserToAddRows = false;
            this.dataGridViewSuchergebnisse.AllowUserToDeleteRows = false;
            this.dataGridViewSuchergebnisse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSuchergebnisse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSuchergebnisse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuchergebnisse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSuchergebnisse.Location = new System.Drawing.Point(0, 71);
            this.dataGridViewSuchergebnisse.MultiSelect = false;
            this.dataGridViewSuchergebnisse.Name = "dataGridViewSuchergebnisse";
            this.dataGridViewSuchergebnisse.ReadOnly = true;
            this.dataGridViewSuchergebnisse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSuchergebnisse.Size = new System.Drawing.Size(638, 344);
            this.dataGridViewSuchergebnisse.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTreffer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(638, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelTreffer
            // 
            this.toolStripStatusLabelTreffer.Name = "toolStripStatusLabelTreffer";
            this.toolStripStatusLabelTreffer.Size = new System.Drawing.Size(0, 17);
            // 
            // FormSuchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 440);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewSuchergebnisse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSuchen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormSuchen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suchen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSuchen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuchergebnisse)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSuchen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTÜV2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTÜV1;
        private System.Windows.Forms.ComboBox comboBoxSuchkriterium;
        private System.Windows.Forms.TextBox textBoxSuchen;
        private System.Windows.Forms.Label labelFarbe;
        private System.Windows.Forms.PictureBox pictureBoxFarbe;
        private System.Windows.Forms.DataGridView dataGridViewSuchergebnisse;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTreffer;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}