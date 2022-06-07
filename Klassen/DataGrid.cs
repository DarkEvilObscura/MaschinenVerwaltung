using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    class DataGrid
    {
        DataGridView gridView;
        Datenbank datenbank;

        public enum HeaderType
        {
            TextBox,
            Button,
            ComboBox,
            CheckBox
        }

        public DataGrid()
        {

        }

        public DataGrid(ref DataGridView gridView)
        {
            this.gridView = gridView;
        }

        
        public DataGrid(ref DataGridView gridView, ref Datenbank datenbank)
        {
            this.gridView = gridView;
            this.datenbank = datenbank;
        }

        public void SetHeader(params DataGridViewColumn[] columns)
        {
            foreach (DataGridViewColumn item in columns)
            {
                this.gridView.Columns.Add(item);
            }
        }

        public DataTable SetHeader2(string tableName)
        {
            string[] columnHeader = new string[7] { "id", "Typ", "Gerätenummer", "Originalnummer", "Bemerkung", "TÜV", "Nicht vorhanden" };
            DataTable table = new DataTable(tableName);
            for (int i = 0; i < columnHeader.Length; i++)
            {
                DataColumn column;
                if (i==0)
                {
                    column = new DataColumn(columnHeader[i], typeof(int));
                }
                else if(i==5)
                {
                    column = new DataColumn(columnHeader[i], typeof(DateTime));
                }
                else if(i==6)
                {
                    column = new DataColumn(columnHeader[i], typeof(bool));
                }
                else
                {
                    column = new DataColumn(columnHeader[i], typeof(string));
                }
                table.Columns.Add(column);
            }

            return table;
        }

        public Datensatz GetRow(int id)
        {
            MessageBox.Show(this.gridView.Rows[id].Selected.ToString());
            return null;
        }
        /*
        public void SetRow2(ref DataTable table, int id, string typ, string gerätenummer, string originalnummer, string bemerkung, DateTime tüv, bool nichtvorhanden)
        {
            DataRow dataRow = table.NewRow();
            dataRow["id"] = id;
            dataRow["Typ"] = typ;
            dataRow["Gerätenummer"] = gerätenummer;
            dataRow["Originalnummer"] = originalnummer;
            dataRow["Bemerkung"] = bemerkung;
            dataRow["TÜV"] = tüv;
            dataRow["Nicht vorhanden"] = nichtvorhanden;

            table.Rows.Add(dataRow);
        }
        */

        public DataTable SetRow2(DataTable table, int id, string typ, string gerätenummer, string originalnummer, string bemerkung, DateTime tüv, bool nichtvorhanden)
        {
            DataRow dataRow = table.NewRow();
            dataRow["id"] = id;
            dataRow["Typ"] = typ;
            dataRow["Gerätenummer"] = gerätenummer;
            dataRow["Originalnummer"] = originalnummer;
            dataRow["Bemerkung"] = bemerkung;
            dataRow["TÜV"] = tüv;
            dataRow["Nicht vorhanden"] = nichtvorhanden;

            table.Rows.Add(dataRow);
            return table;
        }

        public DataTable SetRow2(DataTable table, Datensatz datensatz)
        {
            DataRow dataRow = table.NewRow();
            dataRow["id"] = datensatz.Id;
            dataRow["Typ"] = datensatz.Typ;
            dataRow["Gerätenummer"] = datensatz.Gerätenummer;
            dataRow["Originalnummer"] = datensatz.Originalnummer;
            dataRow["Bemerkung"] = datensatz.Bemerkung;
            dataRow["TÜV"] = datensatz.TÜV;
            dataRow["Nicht vorhanden"] = datensatz.NichtVorhanden;

            table.Rows.Add(dataRow);
            return table;
        }

        //public void SetRow2(ref DataTable table, Datensatz datensatz)
        //{
        //    DataRow dataRow = table.NewRow();
        //    dataRow["id"] = datensatz.Id;
        //    dataRow["Typ"] = datensatz.Typ;
        //    dataRow["Gerätenummer"] = datensatz.Gerätenummer;
        //    dataRow["Originalnummer"] = datensatz.Originalnummer;
        //    dataRow["Bemerkung"] = datensatz.Bemerkung;
        //    dataRow["TÜV"] = datensatz.TÜV;
        //    dataRow["Nicht vorhanden"] = datensatz.NichtVorhanden;

        //    table.Rows.Add(dataRow);
        //}

        //public DataTable EditRow(DataTable table, int id) //(int id, Datensatz datensatz)
        //{
        //    foreach (DataRow item in table.Rows)
        //    {
        //        if(Convert.ToInt32(item[0]) == id)
        //        {
        //            item[1] = this.
        //        }
        //    }

        //    /*
        //    int rowindex = this.gridView.CurrentCell.RowIndex;
        //    this.gridView.Rows[rowindex].Cells[1].Value = this.datenbank.listDatensatz[id].Typ;
        //    this.gridView.Rows[rowindex].Cells[2].Value = this.datenbank.listDatensatz[id].Gerätenummer;
        //    this.gridView.Rows[rowindex].Cells[3].Value = this.datenbank.listDatensatz[id].Originalnummer;
        //    this.gridView.Rows[rowindex].Cells[4].Value = this.datenbank.listDatensatz[id].Bemerkung;
        //    this.gridView.Rows[rowindex].Cells[5].Value = this.datenbank.listDatensatz[id].TÜV.ToString();
        //    this.gridView.Rows[rowindex].Cells[6].Value = this.datenbank.listDatensatz[id].NichtVorhanden;
        //    this.gridView.Rows[rowindex].Cells[1].Style.ForeColor = this.datenbank.listDatensatz[id].Options.ForeColor;
        //    this.gridView.Rows[rowindex].Cells[1].Style.BackColor = this.datenbank.listDatensatz[id].Options.BackgroundColor;
        //    */
        //}

        public DataGridViewColumn DefineHeader(string headerText, int width, HeaderType headerType, bool date = false)
        {
            DataGridViewColumn column = null;
            switch(headerType)
            {
                case HeaderType.TextBox:
                    DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
                    textBoxColumn.HeaderText = headerText;
                    textBoxColumn.Width = width;
                    if (date)
                    {
                        textBoxColumn.DefaultCellStyle.Format = "MM.yyyy";
                    }
                    column = textBoxColumn;
                    break;
                case HeaderType.Button:
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = headerText;
                    buttonColumn.Width = width;
                    column = buttonColumn;
                    break;
                case HeaderType.ComboBox:
                    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                    comboBoxColumn.HeaderText = headerText;
                    comboBoxColumn.Width = width;
                    column = comboBoxColumn;
                    break;
                case HeaderType.CheckBox:
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = headerText;
                    checkBoxColumn.Width = width;
                    column = checkBoxColumn;
                    break;
            }
            return column;
        }

        public DataGridViewTextBoxCell DefineTextBox(string text)
        {
            DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
            textBoxCell.Value = text;
            return textBoxCell;
        }

        public DataGridViewButtonCell DefineButton(string buttonText)
        {
            DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
            buttonCell.Value = buttonText;
            return buttonCell;
        }

        public DataGridViewComboBoxCell DefineComboBox(params string[] comboBoxItems)
        {
            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
            foreach (string item in comboBoxItems)
            {
                comboBoxCell.Items.Add(item);
            }
            return comboBoxCell;
        }

        public DataGridViewCheckBoxCell DefineCheckBox()
        {
            DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
            return checkBoxCell;
        }
    }
}
