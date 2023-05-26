using System;
using System.Data;

namespace MaschinenVerwaltung
{
    public class Tabelle
    {
        public Tabelle()
        {

        }

        public DataTable SetHeader(string tableName)
        {
            string[] columnHeader = new string[8] { "id", "Typ", "Geräte\nnummer", "Original\nnummer", "Bemerkung", "TÜV", /*"Nicht\nvorhanden"*/ "n.V.", "options" };
            DataTable table = new DataTable(tableName);
            for (int i = 0; i < columnHeader.Length; i++)
            {
                DataColumn column;
                if (i == 0) //id
                {
                    column = new DataColumn(columnHeader[i], typeof(int));
                }
                else if (i == 5) //TÜV
                {
                    column = new DataColumn(columnHeader[i], typeof(DateTime));
                }
                else if (i == 6) //Nicht vorhanden
                {
                    column = new DataColumn(columnHeader[i], typeof(bool));
                }
                else //Typ, Gerätenummer, Originalnummer, Bemerkung
                {
                    column = new DataColumn(columnHeader[i], typeof(string));
                }
                table.Columns.Add(column);
            }

            return table;
        }

        public DataTable SetRow(DataTable table, Datensatz datensatz)
        {
            DataRow dataRow = table.NewRow();
            dataRow["id"] = datensatz.Id;
            dataRow["Typ"] = datensatz.Typ;
            dataRow["Geräte\nnummer"] = datensatz.Gerätenummer;
            dataRow["Original\nnummer"] = datensatz.Originalnummer;
            dataRow["Bemerkung"] = datensatz.Bemerkung;
            dataRow["TÜV"] = datensatz.TÜV;
            //dataRow["Nicht\nvorhanden"] = datensatz.NichtVorhanden;
            dataRow["n.V."] = datensatz.NichtVorhanden;
            dataRow["options"] = datensatz.Options.SerializeOptions(datensatz.Options);

            table.Rows.Add(dataRow);
            return table;
        }
    }
}
