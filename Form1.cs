using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    public partial class Form1 : Form
    {
        DatenbankVerwaltung dbVerwaltung;
        DataSet dataSet;

        string[] typen = new string[11] { "4070", "5190", "6080", "7081", "8080", "Art.S", "Breva", "Centura", "Prima Advance", "S3", "S4" };

        string currentTable = string.Empty;

        bool login = false;

        Font systemFont;

        public Form1()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, this.dataGridView, new object[] { true });
            //DoubleBufferDataGridView doubleBufferData = new DoubleBufferDataGridView();
            //doubleBufferData.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            //this.dataGridView.CellContentClick += new DataGridViewCellEventHandler(dataGridView_CellContentClick);
            this.dataSet = new DataSet();

            Font font = USettings.GetSystemFontStyle();
            this.systemFont = font;
            this.menuStrip.Font = this.systemFont;
            this.toolStripComboBoxMaschinenListe.Font = this.systemFont;
            this.toolStripButtonMaschineHinzufügen.Font = this.systemFont;
            this.toolStripButtonMaschineSuchen.Font = this.systemFont;
            this.toolStripButtonRefresh.Font = this.systemFont;
            this.dataGridView.Font = this.systemFont;

            if (USettings.GetLogonStatus())
            {
                this.login = true;
                this.toolStripButtonMaschineHinzufügen.Enabled = true;
                this.loginToolStripMenuItem.Text = "Ausloggen";
                this.toolStripStatusLabelEingeloggt.Image = Properties.Resources.shield_key_green;
                this.toolStripStatusLabelEingeloggt.Text = "Eingeloggt";
            }
            else
            {
                this.toolStripButtonMaschineHinzufügen.Enabled = false;
                this.toolStripStatusLabelEingeloggt.Image = Properties.Resources.shield_key_red;
                this.toolStripStatusLabelEingeloggt.Text = "Nicht eingeloggt";
            }

            LoadDatabase();
            InitTables();

            toolStripComboBoxMaschinenListe.SelectedIndex = 0;
            this.currentTable = toolStripComboBoxMaschinenListe.Items[toolStripComboBoxMaschinenListe.SelectedIndex].ToString();

            //this.dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            this.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);

            //Properties.Resources.theme_dark.Tag = "theme_dark";
            //Properties.Resources.theme_light.Tag = "theme_light";
            //this.toolStripButtonDayNightMode.Tag = "theme_light";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //AskToSave();
        }

        private void LoadDatabase()
        {
            string file = Application.StartupPath + @"\Maschinen.db";
            bool dbExists = File.Exists(file);

            if(dbExists)
            {
                this.dbVerwaltung = new DatenbankVerwaltung();
                this.dbVerwaltung.Open(file);
            }
            else
            {
                MessageBox.Show("Fehler:\nDie Datei: Maschinen.db konnte nicht gefunden werden !\n\nDas Programm wird beendet.", "MaschinenVerwaltung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void InitTables()
        {
            DataTable table = new Tabelle().SetHeader("Maschinen");
            table = this.dbVerwaltung.GetMaschinen("*"); //Tabelle wird benötigt zum suchen, nicht löschen !
            this.dataSet.Tables.Add(table);
            foreach (string item in this.typen)
            {
                table = new Tabelle().SetHeader(item);
                table = this.dbVerwaltung.GetMaschinen(item);
                this.dataSet.Tables.Add(table);
            }
            table = new Tabelle().SetHeader("TÜVMaschinen");
            table = this.dbVerwaltung.GetTÜVGeräte();
            this.dataSet.Tables.Add(table);
        }

        private void RefreshTables()
        {
            this.dataSet.Tables.Clear();
            this.dataSet.Clear();
            DataTable table;
            foreach (string item in this.typen)
            {
                table = new Tabelle().SetHeader(item);
                table = this.dbVerwaltung.GetMaschinen(item);
                this.dataSet.Tables.Add(table);
            }
            table = new Tabelle().SetHeader("TÜVMaschinen");
            table = this.dbVerwaltung.GetTÜVGeräte();
            this.dataSet.Tables.Add(table);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int rowindex = this.dataGridView.CurrentCell.RowIndex;
                int datensatzId = (int)this.dataGridView.Rows[rowindex].Cells[0].Value;
                Datensatz datensatz = this.dbVerwaltung.GetSingleDatensatz(datensatzId);

                if (e.ColumnIndex == 8) //Wartungsprotokoll
                {
                    FormWartungsprotokoll formWartungsprotokoll = new FormWartungsprotokoll(datensatz, this.login);
                    formWartungsprotokoll.ShowDialog();
                    if (formWartungsprotokoll.NewDatensatz != null)
                    {
                        dbVerwaltung.Update(datensatz, formWartungsprotokoll.NewDatensatz);
                    }
                }
                else if (e.ColumnIndex == 9) //Bearbeiten
                {
                    FormBearbeiten formBearbeiten = new FormBearbeiten(datensatz);
                    formBearbeiten.ShowDialog();
                    if (formBearbeiten.BearbeiteterDatensatz != null)
                    {
                        this.dbVerwaltung.Update(datensatz, formBearbeiten.BearbeiteterDatensatz);
                        RefreshButton();
                    }
                }
                else if(e.ColumnIndex == 10) //Löschen
                {
                    DialogResult msg = MessageBox.Show("Möchten Sie diese Maschine wirklich löschen ?\n\nTyp: " + datensatz.Typ + "\nGerätenummer: " + datensatz.Gerätenummer + "\nOriginalnummer: " + datensatz.Originalnummer + "\nBemerkung: " + datensatz.Bemerkung + "\nTÜV:" + datensatz.TÜV, "Maschine löschen ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        int result = this.dbVerwaltung.Delete(datensatz);
                        if (result == 1)
                        {
                            RefreshButton();
                        }
                        else if (result == 0)
                        {
                            MessageBox.Show("Fehler!\nDie Maschine konnte nicht gelöscht werden", "MaschinenVerwaltung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BindDataGridView(string tableName)
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();
            this.dataGridView.Columns.Clear();
            BindingSource bindingSource = new BindingSource();
            tableName = (tableName == "Nur TÜV-Abgelaufene Maschinen") ? "TÜVMaschinen" : tableName;
            bindingSource.DataSource = this.dataSet.Tables[tableName];
            this.dataGridView.DataSource = bindingSource;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void toolStripComboBoxMaschinenListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaschineListe_SelectedIndexChanged();
        }

        private void MaschineListe_SelectedIndexChanged()
        {
            UpdateDataGridView();
            this.currentTable = toolStripComboBoxMaschinenListe.Items[toolStripComboBoxMaschinenListe.SelectedIndex].ToString();

            Utils.DataGridViewSetupColumnAlignment(ref this.dataGridView);
            Utils.DataGridViewSetupColumnWidth(ref this.dataGridView, (int)USettings.GetSystemFontStyle().Size);
            Utils.DataGridViewSetupColumnVisible(ref this.dataGridView, (toolStripComboBoxMaschinenListe.SelectedIndex == 11), this.login);
        }

        private void maschineSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSuchen formSuchen = new FormSuchen(ref this.dbVerwaltung);
            formSuchen.ShowDialog();
        }

        private void Quit()
        {
            this.dbVerwaltung.Close();
            Application.Exit();
        }

        private void UpdateDataGridView()
        {
            int index = toolStripComboBoxMaschinenListe.SelectedIndex;
            string text = toolStripComboBoxMaschinenListe.Items[index].ToString();
            BindDataGridView(this.dataSet.Tables[(index==11? "TÜVMaschinen" : text)].TableName);
            Utils.DataGridViewSetup(ref dataGridView, toolStripComboBoxMaschinenListe.SelectedIndex, this.login);
            toolStripStatusLabel_AnzahlMaschinen.Text = $"Anzahl {(index == 11 ? "aller TÜV-" : "der ")}Maschinen: " + this.dataSet.Tables[(index == 11 ? "TÜVMaschinen" : text)].Rows.Count.ToString() + " Stück";
        }

        private void AskToSave()
        {
            DialogResult msg = MessageBox.Show("Möchten Sie speichern, bevor die Anwendung geschlossen wird ?", "MaschinenVerwaltung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(msg==DialogResult.Yes)
            {
                //TODO: Alles speichern (UserSettings, Datenbank)

                this.dbVerwaltung.Close();
            }
        }

        private void alleListenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            export.Start();
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.datenbank.COMMIT();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormInfo().ShowDialog();
        }

        private void schriftartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.ShowEffects = false;
            dialog.ShowColor = false;

            dialog.Font = this.systemFont; //USettings.GetSystemFontStyle();

            DialogResult dialogResult = dialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                USettings.SetSystemFontStyle(dialog.Font.Name, dialog.Font.Style, dialog.Font.Size);
                this.systemFont = dialog.Font;

                this.menuStrip.Font = this.systemFont; //dialog.Font;
                this.toolStripComboBoxMaschinenListe.Font = this.systemFont; //dialog.Font;
                this.toolStripButtonMaschineHinzufügen.Font = this.systemFont; //dialog.Font;
                this.toolStripButtonMaschineSuchen.Font = this.systemFont; //dialog.Font;
                this.toolStripButtonRefresh.Font = this.systemFont; //dialog.Font;
                this.dataGridView.Font = this.systemFont; //dialog.Font;
            }
        }

        private void toolStripButtonMaschineSuchen_Click(object sender, EventArgs e)
        {
            //FormSuchen formSuchen = new FormSuchen(this.dataSet.Tables[0]);
            FormSuchen formSuchen = new FormSuchen(ref this.dbVerwaltung);
            formSuchen.ShowDialog();
        }

        private void toolStripButtonMaschineHinzufügen_Click(object sender, EventArgs e)
        {
            FormHinzufügen formHinzufügen = new FormHinzufügen(ref this.dbVerwaltung, ref this.dataSet, ref this.dataGridView);
            formHinzufügen.ShowDialog();
            UpdateDataGridView();
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                int w = 16; //int w = (e.ColumnIndex == 8) ? Properties.Resources.edit.Width : Properties.Resources.delete.Width;
                int h = 16; //int h = (e.ColumnIndex == 8) ? Properties.Resources.edit.Height : Properties.Resources.delete.Height;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                switch (e.ColumnIndex)
                {
                    case 8:
                        e.Graphics.DrawImage(Properties.Resources.notebook, new Rectangle(x, y, w, h));
                        break;
                    case 9:
                        e.Graphics.DrawImage(Properties.Resources.edit, new Rectangle(x, y, w, h));
                        break;
                    case 10:
                        e.Graphics.DrawImage(Properties.Resources.delete, new Rectangle(x, y, w, h));
                        break;
                }
                e.Handled = true;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshButton();
        }

        private void RefreshButton()
        {
            RefreshTables();
            BindDataGridView(this.currentTable);
            Utils.DataGridViewSetup(ref dataGridView, toolStripComboBoxMaschinenListe.SelectedIndex, this.login);
            this.dataGridView.Invalidate();
            this.dataGridView.Update();
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //DataGridView Bug:
            //http://connect.microsoft.com/VisualStudio/feedback/details/120007/datagridview-sort-looses-cell-backcolor

            /*
            Thank you for your bug report. The behavior you notice is by design.
            Sorting a databound grid causes all rows to be recreated (called a ListChangedType.Reset).
            This causes your formatting to be lost. You need to use the DataBindingComplete event to apply
            styles and check for the ListChangedType.Reset to know when to apply your styling. Alternatively
            you can use the CellFormatting event. Ideally all your formatting can be done inside the
            CellFormatting since it is applied dynamically.
             */

            switch (e.ListChangedType)
            {
                case System.ComponentModel.ListChangedType.Reset:
                case System.ComponentModel.ListChangedType.ItemAdded:
                case System.ComponentModel.ListChangedType.ItemChanged:
                    foreach (DataGridViewRow item in this.dataGridView.Rows)
                    {
                        int datensatzId = (int)this.dataGridView.Rows[item.Index].Cells[0].Value;
                        Datensatz datensatz = this.dbVerwaltung.GetSingleDatensatz(datensatzId);
                        this.dataGridView.Rows[item.Index].DefaultCellStyle.BackColor = datensatz.Options.BackgroundColor;
                        this.dataGridView.Rows[item.Index].DefaultCellStyle.ForeColor = datensatz.Options.ForeColor;
                    }
                    break;
            }
        }

        private void dataGridView_Resize(object sender, EventArgs e)
        {
            if(this.dataGridView.Columns.Count>0)
            {
                Utils.DataGridViewSetupColumnAlignment(ref this.dataGridView);
                Utils.DataGridViewSetupColumnWidth(ref this.dataGridView, (int)USettings.GetSystemFontStyle().Size);
                Utils.DataGridViewSetupColumnVisible(ref this.dataGridView, (toolStripComboBoxMaschinenListe.SelectedIndex == 11), this.login);
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.loginToolStripMenuItem.Text == "Ausloggen")
            {
                DialogResult dialog = MessageBox.Show("Möchten Sie sich wirklich vom System abmelden ?", "MaschinenVerwaltung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.Yes)
                {
                    this.login = false;
                    USettings.SetLogonStatus(false);
                    this.loginToolStripMenuItem.Text = "Login";
                    this.toolStripButtonMaschineHinzufügen.Enabled = false;
                    this.toolStripStatusLabelEingeloggt.Image = Properties.Resources.shield_key_red;
                    this.toolStripStatusLabelEingeloggt.Text = "Ausgeloggt";
                }
            }
            else
            {
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
                this.login = formLogin.Login;
                if (this.login)
                {
                    this.toolStripButtonMaschineHinzufügen.Enabled = true;
                    this.loginToolStripMenuItem.Text = "Ausloggen";
                    this.toolStripStatusLabelEingeloggt.Image = Properties.Resources.shield_key_green;
                    this.toolStripStatusLabelEingeloggt.Text = "Eingeloggt";
                }
            }
            RefreshButton();
        }

        private void toolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", toolStripTextBoxSearch.Text);
        }

        //private void toolStripButtonDayNightMode_Click(object sender, EventArgs e)
        //{
        //    string tag = this.toolStripButtonDayNightMode.Tag.ToString();

        //    if (tag == "theme_light")
        //    {
        //        this.toolStripButtonDayNightMode.Image = Properties.Resources.theme_light; //Icon wechseln
        //        this.toolStripButtonDayNightMode.Tag = "theme_dark";

        //        this.menuStrip.BackColor = Color.FromArgb(30, 30, 30);
        //        foreach (ToolStripItem item in this.menuStrip.Items)
        //        {
        //            item.ForeColor = Color.White;
        //        }
        //        this.toolStrip1.BackColor = Color.FromArgb(30, 30, 30);
        //        toolStripComboBoxMaschinenListe.BackColor = Color.FromArgb(30, 30, 30);

        //        this.dataGridView.BackgroundColor = Color.FromArgb(18, 18, 18);


        //        this.statusStrip.BackColor = Color.FromArgb(30, 30, 30);
        //        this.toolStripStatusLabel_AnzahlMaschinen.ForeColor = Color.White;
        //        this.toolStripStatusLabelEingeloggt.ForeColor = Color.White;

        //        return;
        //    }
        //    else if(tag == "theme_dark")
        //    {
        //        this.toolStripButtonDayNightMode.Image = Properties.Resources.theme_dark;
        //        this.toolStripButtonDayNightMode.Tag = "theme_light";

        //        this.menuStrip.BackColor = SystemColors.Control;
        //        foreach (ToolStripItem item in this.menuStrip.Items)
        //        {
        //            item.ForeColor = Color.Black;
        //        }
        //        this.toolStrip1.BackColor = SystemColors.Control;
        //        toolStripComboBoxMaschinenListe.BackColor = SystemColors.Control;
        //        this.dataGridView.BackgroundColor = SystemColors.AppWorkspace;
        //        this.dataGridView.GridColor = SystemColors.ControlDark;
        //    }
        //}
    }
}