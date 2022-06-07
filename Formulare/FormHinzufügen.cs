using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    public partial class FormHinzufügen : Form
    {
        DatenbankVerwaltung verwaltung;
        DataSet dataSet;
        DataGridView form1DataGridView;

        List<Datensatz> datensätze;

        int rowIndex = 0;

        public FormHinzufügen(ref DatenbankVerwaltung verwaltung, ref DataSet dataSet, ref DataGridView form1DataGridView)
        {
            InitializeComponent();
            this.verwaltung = verwaltung;
            this.dataSet = dataSet;
            this.form1DataGridView = form1DataGridView;
        }

        private void FormHinzufügen_Load(object sender, EventArgs e)
        {
            this.datensätze = new List<Datensatz>();
            Font font = USettings.GetSystemFontStyle();
            this.dataGridView.Font = font;
            monthCalendar.Font = font;
            //buttonAbbrechen.Font = font;
            //buttonSpeichern.Font = font;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            if(grid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn && e.RowIndex >=0)
            {
                if (e.ColumnIndex == 4)
                {
                    if (this.dataGridView.Rows[0].Cells[4].IsInEditMode)
                    {
                        monthCalendar.Visible = true;
                    }
                }
                return;
            }

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    ColorDialog dialog = new ColorDialog();
                    DialogResult c = dialog.ShowDialog(Owner);
                    if(c == DialogResult.OK)
                    {
                        this.dataGridView.CurrentRow.DefaultCellStyle.ForeColor = dialog.Color;
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    ColorDialog dialog = new ColorDialog();
                    DialogResult c = dialog.ShowDialog(Owner);
                    if (c == DialogResult.OK)
                    {
                        this.dataGridView.CurrentRow.DefaultCellStyle.BackColor = dialog.Color;
                    }
                }
            }
        }

        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView.Rows)
            {
                string typ = (item.Cells[0].Value!=null) ? item.Cells[0].Value.ToString() : string.Empty;
                string gerätenummer = (item.Cells[1].Value!=null) ? item.Cells[1].Value.ToString() : string.Empty;
                string originalnummer = (item.Cells[2].Value!=null) ? item.Cells[2].Value.ToString() : string.Empty;
                string bemerkung = (item.Cells[3].Value != null) ? item.Cells[3].Value.ToString() : string.Empty;
                DateTime tüv = (item.Cells[4].Value != null) ? DateTime.Parse(item.Cells[4].Value.ToString()) : DateTime.MinValue;
                tüv = new DateTime(tüv.Year, tüv.Month, 1);
                DataGridViewCheckBoxCell chkNichtVorhanden = item.Cells[5] as DataGridViewCheckBoxCell;
                bool nichtVorhanden = (chkNichtVorhanden.Value == null) ? false : true;
                Options options = new Options();
                options.BackgroundColor = this.dataGridView.CurrentRow.DefaultCellStyle.BackColor;
                options.ForeColor = this.dataGridView.CurrentRow.DefaultCellStyle.ForeColor;

                if(options.BackgroundColor == options.ForeColor)
                {
                    options.BackgroundColor = Color.White;
                    options.ForeColor = Color.Black;
                }

                if(typ==string.Empty && gerätenummer==string.Empty && originalnummer == string.Empty && bemerkung == string.Empty && tüv == DateTime.MinValue && nichtVorhanden==false)
                {
                    continue;
                }
                else
                {
                    Datensatz datensatz = new Datensatz(0, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, options);
                    this.datensätze.Add(datensatz);
                }
            }

            foreach (Datensatz item in this.datensätze)
            {
                if (item.Typ == string.Empty && item.Gerätenummer == string.Empty && item.Originalnummer == string.Empty && item.Bemerkung == string.Empty && item.TÜV == DateTime.MinValue && item.NichtVorhanden == false)
                {
                    continue;
                }
                else
                {
                    //this.dataSet.Tables[0].Rows.Add(item.Id);
                    this.verwaltung.Insert(item);
                }
            }
            //this.dataSet.AcceptChanges();
            ActiveForm.Close();
        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void FormHinzufügen_Resize(object sender, EventArgs e)
        {
            Rectangle rectangle = this.dataGridView.GetCellDisplayRectangle(4, this.rowIndex, false);
            monthCalendar.Location = new Point(rectangle.X, rectangle.Y + rectangle.Height);
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.dataGridView.Rows[this.rowIndex].Cells[4].Value = monthCalendar.SelectionRange.Start;
            this.dataGridView.EndEdit();
            monthCalendar.Visible = false;
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 4)
            {
                this.rowIndex = e.RowIndex;
                Rectangle rectangle = this.dataGridView.GetCellDisplayRectangle(4, e.RowIndex, false);
                monthCalendar.Location = new Point(rectangle.X, rectangle.Y + rectangle.Height);
                monthCalendar.Visible = true;
            }
        }

        private void dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 4)
            {
                monthCalendar.Visible = false;
            }
        }
    }
}