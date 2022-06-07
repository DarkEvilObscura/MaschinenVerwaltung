using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    public partial class FormBearbeiten : Form
    {
        //DatenbankVerwaltung verwaltung;
        //DataTable table;
        //int rowIndex;
        //DataGridView dataGridView;

        Datensatz datensatz;

        public Datensatz BearbeiteterDatensatz { get; private set; }

        Options altOptions;

        Font systemFont;


        //public FormBearbeiten(ref DatenbankVerwaltung verwaltung, DataTable table, int rowIndex, ref DataGridView dataGridView) //(ref Datenbank datenbank, Datensatz datensatz) //(DataRow row)
        //{
        //    InitializeComponent();
        //    this.verwaltung = verwaltung;
        //    this.table = table;
        //    this.rowIndex = rowIndex;
        //    this.dataGridView = dataGridView;
        //}

        public FormBearbeiten(Datensatz datensatz)
        {
            InitializeComponent();
            this.datensatz = datensatz;
            this.BearbeiteterDatensatz = null;
        }

        private enum TextBoxEvent
        {
            Leave,
            Enter
        }

        private void FormBearbeiten_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(FormBearbeiten_FormClosing);

            textBoxGerätenummer.Enter += new EventHandler(TextBoxGerätenummer_Enter);
            textBoxGerätenummer.Leave += new EventHandler(TextBoxGerätenummer_Leave);
            textBoxOriginalnummer.Enter += new EventHandler(TextBoxOriginalnummer_Enter);
            textBoxOriginalnummer.Leave += new EventHandler(TextBoxOriginalnummer_Leave);
            textBoxBemerkung.Enter += new EventHandler(TextBoxBemerkung_Enter);
            textBoxBemerkung.Leave += new EventHandler(TextBoxBemerkung_Leave);

            #region Font-Einstellung
            Font font =  USettings.GetSystemFontStyle();
            this.systemFont = new Font(font.FontFamily, font.Size, font.Style);
            comboBoxTyp.Font = this.systemFont;
            textBoxGerätenummer.Font = this.systemFont;
            textBoxOriginalnummer.Font = this.systemFont;
            textBoxBemerkung.Font = this.systemFont;
            dateTimePickerTÜV.Font = this.systemFont;
            checkBoxTÜVDatum.Font = this.systemFont;
            checkBoxNichtVorhanden.Font = this.systemFont;
            groupBoxWeitereEinstellungen.Font = this.systemFont;
            labelSchriftfarbe.Font = this.systemFont;
            labelHintergrundfarbe.Font = this.systemFont;
            #endregion

            toolTip.SetToolTip(comboBoxTyp, "Auswahl des Maschinen-Typs");
            toolTip.SetToolTip(textBoxGerätenummer, "Die Gerätenummer der Maschine");
            toolTip.SetToolTip(textBoxOriginalnummer, "Die Originalnummer der Maschine");
            toolTip.SetToolTip(textBoxBemerkung, "Das Bemerkungsfeld der Maschine");
            toolTip.SetToolTip(dateTimePickerTÜV, "Setzen des TÜV-Datums");

            //comboBoxTyp.SelectedIndex = comboBoxTyp.FindStringExact(this.table.Rows[rowIndex].Field<string>(1));
            comboBoxTyp.SelectedIndex = comboBoxTyp.FindStringExact(this.datensatz.Typ);

            if (this.datensatz.Gerätenummer == string.Empty)
            {
                SetDefault(ref textBoxGerätenummer, TextBoxEvent.Leave);
            }
            else
            {
                textBoxGerätenummer.Text = this.datensatz.Gerätenummer;
            }
            if(this.datensatz.Originalnummer == string.Empty)
            {
                SetDefault(ref textBoxOriginalnummer, TextBoxEvent.Leave);
            }
            else
            {
                textBoxOriginalnummer.Text = this.datensatz.Originalnummer;
            }
            if(this.datensatz.Bemerkung == string.Empty)
            {
                SetDefault(ref textBoxBemerkung, TextBoxEvent.Leave);
            }
            else
            {
                textBoxBemerkung.Text = this.datensatz.Bemerkung;
            }

            DateTime tüv = this.datensatz.TÜV;

            dateTimePickerTÜV.Value = (tüv == DateTime.MinValue ? DateTime.Now : tüv);
            checkBoxTÜVDatum.Checked = (tüv > DateTime.MinValue);
            checkBoxNichtVorhanden.Checked = this.datensatz.NichtVorhanden;

            this.altOptions = this.datensatz.Options;

            pictureBoxForeColor.BackColor = this.altOptions.ForeColor;
            pictureBoxBackgroundColor.BackColor = this.altOptions.BackgroundColor;
        }

        private void FormBearbeiten_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO: Prüfen auf Veränderung, wenn Ja, Fragen ob die Veränderungen gespeichert werden sollen
        }

        private void TextBoxGerätenummer_Enter(object sender, EventArgs e)
        {
            SetDefault(ref textBoxGerätenummer, TextBoxEvent.Enter);
        }

        private void TextBoxGerätenummer_Leave(object sender, EventArgs e)
        {
            SetDefault(ref textBoxGerätenummer, TextBoxEvent.Leave);
        }

        private void TextBoxOriginalnummer_Enter(object sender, EventArgs e)
        {
            SetDefault(ref textBoxOriginalnummer, TextBoxEvent.Enter);
        }

        private void TextBoxOriginalnummer_Leave(object sender, EventArgs e)
        {
            SetDefault(ref textBoxOriginalnummer, TextBoxEvent.Leave);
        }

        private void TextBoxBemerkung_Enter(object sender, EventArgs e)
        {
            SetDefault(ref textBoxBemerkung, TextBoxEvent.Enter);
        }

        private void TextBoxBemerkung_Leave(object sender, EventArgs e)
        {
            SetDefault(ref textBoxBemerkung, TextBoxEvent.Leave);
        }

        private void SetDefault(ref TextBox textBox, TextBoxEvent textBoxEvent)
        {
            if(textBoxEvent == TextBoxEvent.Enter)
            {
                if (textBox.Text == "Gerätenummer" || textBox.Text == "Originalnummer" || textBox.Text == "Bemerkung")
                {
                    textBox.Text = "";
                    textBox.Font = new Font(this.systemFont.FontFamily, this.systemFont.Size, FontStyle.Regular);
                    textBox.ForeColor = Color.Black;
                }
                return;
            }
            if(textBoxEvent==TextBoxEvent.Leave)
            {
                if (textBox.Text == "")
                {
                    textBox.Font = new Font(this.systemFont.FontFamily, this.systemFont.Size, FontStyle.Italic);
                    textBox.ForeColor = Color.Gray;
                    switch (textBox.Name)
                    {
                        case "textBoxGerätenummer":
                            textBox.Text = "Gerätenummer";
                            break;
                        case "textBoxOriginalnummer":
                            textBox.Text = "Originalnummer";
                            break;
                        case "textBoxBemerkung":
                            textBox.Text = "Bemerkung";
                            break;
                    }
                    return;
                }
            }            
        }

        private void pictureBoxForeColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog.ShowDialog(Owner);
            if(dialogResult == DialogResult.OK)
            {
                pictureBoxForeColor.BackColor = colorDialog.Color;
            }
        }

        private void pictureBoxBackgroundColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog.ShowDialog(Owner);
            if (dialogResult == DialogResult.OK)
            {
                pictureBoxBackgroundColor.BackColor = colorDialog.Color;
            }
        }

        private void checkBoxTÜVDatum_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerTÜV.Enabled = checkBoxTÜVDatum.Checked;
        }

        private void checkBoxNichtVorhanden_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTÜVDatum.Enabled = !checkBoxNichtVorhanden.Checked;
            if(checkBoxNichtVorhanden.Checked && dateTimePickerTÜV.Enabled)
            {
                dateTimePickerTÜV.Enabled = !checkBoxNichtVorhanden.Checked;
                return;
            }
            else if(!checkBoxNichtVorhanden.Checked && checkBoxTÜVDatum.Checked)
            {
                dateTimePickerTÜV.Enabled = checkBoxTÜVDatum.Checked;
            }
        }
        
        private void buttonSaveClose_Click(object sender, EventArgs e)
        {
            Datensatz altDatensatz = new Datensatz(this.datensatz.Id, this.datensatz.Typ, this.datensatz.Gerätenummer, this.datensatz.Originalnummer, this.datensatz.Bemerkung, this.datensatz.TÜV, this.datensatz.NichtVorhanden, this.datensatz.Options);
            Datensatz neuDatensatz = EditDatensatz();
            //verwaltung.Update(altDatensatz, neuDatensatz);
            this.BearbeiteterDatensatz = neuDatensatz;
            //this.dataGridView.Rows[this.rowIndex].DefaultCellStyle.ForeColor = pictureBoxForeColor.BackColor;
            //this.dataGridView.Rows[this.rowIndex].DefaultCellStyle.BackColor = pictureBoxBackgroundColor.BackColor;

            FormBearbeiten.ActiveForm.Close();
        }

        private Datensatz EditDatensatz()
        {
            string typ = comboBoxTyp.Text;
            string gNr = (textBoxGerätenummer.Text == "Gerätenummer" ? string.Empty : textBoxGerätenummer.Text);
            string oNr = (textBoxOriginalnummer.Text == "Originalnummer" ? string.Empty : textBoxOriginalnummer.Text);
            string bemerkung = (textBoxBemerkung.Text == "Bemerkung" ? string.Empty : textBoxBemerkung.Text);
            DateTime tüv = (!checkBoxNichtVorhanden.Checked && checkBoxTÜVDatum.Checked ? dateTimePickerTÜV.Value : DateTime.MinValue);
            string tüvCustom = (tüv != DateTime.MinValue && tüv.Month < 10 ? "0" + tüv.Month.ToString() + "." + tüv.Year.ToString() : DateTime.MinValue.ToString());

            Options options = new Options();
            options.ForeColor = (pictureBoxForeColor.BackColor != Color.Black) ? pictureBoxForeColor.BackColor : Color.Black;
            options.BackgroundColor = (pictureBoxBackgroundColor.BackColor != Color.White) ? pictureBoxBackgroundColor.BackColor : Color.White;

            //return new Datensatz(this.datensatz.Id, typ, gNr, oNr, bemerkung, tüv, checkBoxNichtVorhanden.Checked, options);
            return new Datensatz(this.datensatz.Id, typ, gNr, oNr, bemerkung, DateTime.Parse(tüvCustom).Date, checkBoxNichtVorhanden.Checked, options);
        }
        
    }
}
