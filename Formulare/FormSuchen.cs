using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    public partial class FormSuchen : Form
    {
        DataSet dataSet;
        //DataTable table;
        DatenbankVerwaltung datenbankVerwaltung;

        Font systemFont;

        public enum TextBoxEvent
        {
            Leave,
            Enter
        }

        public FormSuchen(ref DatenbankVerwaltung verwaltung)
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, this.dataGridViewSuchergebnisse, new object[] { true });

            datenbankVerwaltung = verwaltung;
        }

        private void FormSuchen_Load(object sender, EventArgs e)
        {
            textBoxSuchen.Enter += new EventHandler(TextBoxSuchen_Enter);
            textBoxSuchen.Leave += new EventHandler(TextBoxSuchen_Leave);

            comboBoxSuchkriterium.SelectedIndex = 0;

            this.dataSet = new DataSet();

            Font font = USettings.GetSystemFontStyle();
            this.systemFont = font;
            this.comboBoxSuchkriterium.Font = font;
            this.textBoxSuchen.Font = font;
            this.dateTimePickerTÜV1.Font = font;
            this.dateTimePickerTÜV2.Font = font;
            this.labelFarbe.Font = font;
            this.buttonSuchen.Font = font;
            this.dataGridViewSuchergebnisse.Font = font;
            this.toolStripStatusLabelTreffer.Font = font;
        }

        private void TextBoxSuchen_Leave(object sender, EventArgs e)
        {
            SetDefault(ref textBoxSuchen, TextBoxEvent.Leave);
        }

        private void TextBoxSuchen_Enter(object sender, EventArgs e)
        {
            SetDefault(ref textBoxSuchen, TextBoxEvent.Enter);
        }

        private void buttonSuchen_Click(object sender, EventArgs e)
        {
            this.dataGridViewSuchergebnisse.DataSource = null;
            this.dataGridViewSuchergebnisse.Rows.Clear();
            this.dataGridViewSuchergebnisse.Columns.Clear();

            DataTable tableSuchergebnisse = new Tabelle().SetHeader("Suchergebnisse");
            switch (comboBoxSuchkriterium.SelectedIndex)
            {
                case 0: //Gerätenummer
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(textBoxSuchen.Text.ToUpper(), DatenbankVerwaltung.SuchKategorie.Gerätenummer);
                    break;
                case 1: //Originalnummer
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(textBoxSuchen.Text.ToUpper(), DatenbankVerwaltung.SuchKategorie.Originalnummer);
                    break;
                case 2: //Bemerkung
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(textBoxSuchen.Text.ToUpper(), DatenbankVerwaltung.SuchKategorie.Bemerkung); //Suchen(textBoxSuchen.Text.ToUpper(), false, false, true);
                    break;
                case 3: //Mit TÜV-Datum
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(dateTimePickerTÜV1.Value);
                    break;
                case 4: //Mit TÜV-Datum (von - bis)
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(dateTimePickerTÜV1.Value, dateTimePickerTÜV2.Value);
                    break;
                case 5: //Ohne TÜV-Datum
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(true, false);
                    break;
                case 6: //Nicht mehr vorhanden
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(false, true);
                    break;
                case 7: //Schriftfarbe
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(pictureBoxFarbe.BackColor, true, false);
                    break;
                case 8: //Hintergrundfarbe
                    tableSuchergebnisse = this.datenbankVerwaltung.Suchen(pictureBoxFarbe.BackColor, false, true);
                    break;
            }

            if (this.dataSet.Tables.Count > 0)
            {
                this.dataSet.Tables.RemoveAt(0);
            }
            this.dataSet.Tables.Add(tableSuchergebnisse);
            BindDataGridView();

            if(this.dataGridViewSuchergebnisse.Rows.Count>0)
            {
                for (int i = 0; i < this.dataGridViewSuchergebnisse.Rows.Count; i++)
                {
                    Options options = new Options();
                    options = options.DeserializeOptions(dataGridViewSuchergebnisse.Rows[i].Cells[7].Value.ToString());
                    this.dataGridViewSuchergebnisse.Rows[i].DefaultCellStyle.ForeColor = options.ForeColor;
                    this.dataGridViewSuchergebnisse.Rows[i].DefaultCellStyle.BackColor = options.BackgroundColor;
                }
            }

            toolStripStatusLabelTreffer.Text = (this.dataGridViewSuchergebnisse.Rows.Count > 0 ? this.dataGridViewSuchergebnisse.Rows.Count.ToString() + " Treffer ! 😎" : "0 Treffer ! ☹");
        }

        private void BindDataGridView()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = this.dataSet.Tables["Suchergebnisse"];
            this.dataGridViewSuchergebnisse.DataSource = bindingSource;
            this.dataGridViewSuchergebnisse.Columns[0].Visible = false;
            this.dataGridViewSuchergebnisse.Columns[7].Visible = false;
        }
        
        private void comboBoxSuchkriterium_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSuchen.Visible = false;
            dateTimePickerTÜV1.Visible = false;
            dateTimePickerTÜV2.Visible = false;
            pictureBoxFarbe.Visible = false;
            labelFarbe.Visible = false;
            switch(comboBoxSuchkriterium.SelectedIndex)
            {
                case 0: //Gerätenummer
                    textBoxSuchen.Visible = true;
                    break;
                case 1: //Originalnummer
                    textBoxSuchen.Visible = true;
                    break;
                case 2: //Bemerkung
                    textBoxSuchen.Visible = true;
                    break;
                case 3: //Mit TÜV-Datum
                    dateTimePickerTÜV1.Visible = true;
                    break;
                case 4: //Mit TÜV-Datum (von - bis)
                    dateTimePickerTÜV1.Visible = true;
                    dateTimePickerTÜV2.Visible = true;
                    break;
                //case 5: //Ohne TÜV-Datum
                    //break;
                //case 6: //Nicht mehr vorhanden
                    //break;
                case 7: //Schriftfarbe
                    pictureBoxFarbe.Visible = true;
                    labelFarbe.Visible = true;
                    pictureBoxFarbe.SendToBack();
                    break;
                case 8: //Hintergrundfarbe
                    pictureBoxFarbe.Visible = true;
                    labelFarbe.Visible = true;
                    pictureBoxFarbe.SendToBack();
                    break;
            }
        }

        private void pictureBoxFarbe_Click(object sender, EventArgs e)
        {
            ShowColorDialog();
        }

        private void labelFarbe_Click(object sender, EventArgs e)
        {
            ShowColorDialog();
        }

        private void SetDefault(ref TextBox textBox, TextBoxEvent textBoxEvent)
        {
            if(textBoxEvent == TextBoxEvent.Enter)
            {
                if(textBox.Text == "Suchbegriff")
                {
                    textBox.Text = "";
                    textBox.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                    textBox.ForeColor = Color.Black;
                }
                return;
            }
            if(textBoxEvent == TextBoxEvent.Leave)
            {
                if(textBox.Text == "")
                {
                    textBox.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Italic);
                    textBox.ForeColor = Color.Gray;
                    textBox.Text = "Suchbegriff";
                }
            }
        }

        private void ShowColorDialog()
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Color Background = colorDialog.Color;
                int complementary = Color.White.ToArgb() - Background.ToArgb();
                pictureBoxFarbe.BackColor = Background;
                labelFarbe.BackColor = pictureBoxFarbe.BackColor;
                labelFarbe.ForeColor = Color.FromArgb(complementary);
            }
        }
    }
}