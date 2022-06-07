using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Data;

namespace MaschinenVerwaltung
{
    public class Datenbank
    {
        string connectionString;
        SQLiteConnectionStringBuilder sQLiteConnectionStringBuilder;
        SQLiteConnection sQLiteConnection;
        SQLiteCommand sQLiteCommand;

        public List<string> listDatensatzTypen { get; private set; }
        public List<Datensatz> listDatensatz { get; set; }
        public List<Datensatz> listDatensatzTÜV { get; set; }

        public Datenbank(string filePath)
        {
            this.sQLiteConnectionStringBuilder = new SQLiteConnectionStringBuilder();
            this.sQLiteConnectionStringBuilder.DataSource = filePath;
            this.sQLiteConnectionStringBuilder.ReadOnly = false;
            this.connectionString = this.sQLiteConnectionStringBuilder.ConnectionString;
            this.listDatensatzTypen = new List<string>();
            this.listDatensatz = new List<Datensatz>();
            this.listDatensatzTÜV = new List<Datensatz>();
        }

        public void Open()
        {
            this.sQLiteConnection = new SQLiteConnection(this.connectionString);
            this.sQLiteConnection.Open();
        }

        public void GetAllDatasets()
        {
            string sqlQuery = "SELECT * FROM Maschinen;";
            this.sQLiteCommand = new SQLiteCommand(sqlQuery, this.sQLiteConnection);
            this.sQLiteCommand.CommandText = sqlQuery;
            SQLiteDataReader reader = this.sQLiteCommand.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string typ = reader.GetString(1);
                string gerätenummer = reader.GetString(2);
                string originalnummer = reader.GetString(3);
                string bemerkung = reader.GetString(4);
                DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                bool nichtVorhanden = (reader.GetInt32(6) == 0 ? false : true);
                //Options options = new Options(reader.GetString(7));

                Datensatz datensatz = new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden , null);
                listDatensatz.Add(datensatz);                
            }
        }

        public void GetTÜVGeräte()
        {
            string sqlQuery1 = "SELECT * FROM Maschinen WHERE (length(TÜV)>0) AND (CAST(substr(TÜV, 4) AS INTEGER) < CAST(strftime('%Y', 'now') AS INTEGER));";
            string sqlQuery2 = "SELECT * FROM Maschinen WHERE (length(TÜV)>0) AND (CAST(substr(TÜV, 4) AS INTEGER) = CAST(strftime('%Y', 'now') AS INTEGER)) AND (CAST(substr(TÜV, 1,2) AS INTEGER) <= CAST(strftime('%m', 'now') AS INTEGER));";
            List<Datensatz> elements = new List<Datensatz>();
            this.sQLiteCommand = new SQLiteCommand(sqlQuery1, this.sQLiteConnection);
            this.sQLiteCommand.CommandText = sqlQuery1;
            SQLiteDataReader reader = this.sQLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string typ = reader.GetString(1);
                string gerätenummer = reader.GetString(2);
                string originalnummer = reader.GetString(3);
                string bemerkung = reader.GetString(4);
                DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                bool nichtVorhanden = (reader.GetInt32(6) == 0 ? false : true);
                //string options = reader.GetString(7);
                //Options options = new Options(reader.GetString(7));

                Datensatz datensatz = new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, null);
                elements.Add(datensatz);
            }
            this.sQLiteCommand = new SQLiteCommand(sqlQuery2, this.sQLiteConnection);
            this.sQLiteCommand.CommandText = sqlQuery2;
            reader = this.sQLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string typ = reader.GetString(1);
                string gerätenummer = reader.GetString(2);
                string originalnummer = reader.GetString(3);
                string bemerkung = reader.GetString(4);
                DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                bool nichtVorhanden = (reader.GetInt32(6) == 0 ? false : true);
                //string options = reader.GetString(7);
                //Options options = new Options(reader.GetString(7));

                Datensatz datensatz = new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, null);
                elements.Add(datensatz);
            }
            this.listDatensatzTÜV = elements.OrderBy(id => id.Id).ToList<Datensatz>();
        }

        //public List<string> Query(string sqlQuery)
        //{
        //    List<string> elements = new List<string>();
        //    this.sQLiteCommand = new SQLiteCommand(sqlQuery, this.sQLiteConnection);
        //    this.sQLiteCommand.CommandText = sqlQuery;
        //    SQLiteDataReader reader = this.sQLiteCommand.ExecuteReader();
        //    while(reader.Read())
        //    {
        //        //elements.Add 
        //    }
        //    return elements;
        //}

        public void EditDataset(int lstIndex, string typ, string gerätenummer, string originalnummer, string tüv)
        {
            this.sQLiteCommand = new SQLiteCommand(this.sQLiteConnection);
            this.sQLiteCommand.CommandText = "UPDATE Maschinen SET Typ = \"@param1\", Gerätenummer = \"@param2\", Originalnummer = \"@param3\", TÜV = \"@param4\" WHERE id = @param5;";
            this.sQLiteCommand.Parameters.Add("@param1", System.Data.DbType.AnsiString).Value = typ;
            this.sQLiteCommand.Parameters.Add("@param2", System.Data.DbType.AnsiString).Value = gerätenummer;
            this.sQLiteCommand.Parameters.Add("@param3", System.Data.DbType.AnsiString).Value = originalnummer;
            this.sQLiteCommand.Parameters.Add("@param4", System.Data.DbType.AnsiString).Value = tüv;
            this.sQLiteCommand.Parameters.Add("@param5", System.Data.DbType.Int16).Value = lstIndex + 1;
        }

        public void RemoveDataset(int i)
        {

        }

        public void GetAllTypes()
        {
            this.sQLiteCommand = new SQLiteCommand(this.sQLiteConnection);
            this.sQLiteCommand.CommandText = "SELECT DISTINCT(Typ) FROM Maschinen ORDER BY Typ asc";
            SQLiteDataReader reader = sQLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                this.listDatensatzTypen.Add(reader.GetString(0));
            }
        }

        public void COMMIT()
        {
            this.sQLiteCommand = new SQLiteCommand(this.sQLiteConnection);
            foreach (Datensatz lstDatensatz in this.listDatensatz)
            {
                this.sQLiteCommand.CommandText = "SELECT * FROM Maschinen WHERE id = @params1;";
                this.sQLiteCommand.Parameters.Add("@params1", System.Data.DbType.Int32).Value = lstDatensatz.Id;
                SQLiteDataReader reader = this.sQLiteCommand.ExecuteReader();

                bool commit = false;
                Datensatz dbDatensatz = null;
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string typ = reader.GetString(1);
                    string gerätenummer = reader.GetString(2);
                    string originalnummer = reader.GetString(3);
                    string bemerkung = reader.GetString(4);
                    DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                    bool nichtVorhanden = (reader.GetInt32(6) == 0 ? false : true);
                    //Options options = new Options(reader.GetString(7));

                    dbDatensatz = new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, null);
                }
                if (lstDatensatz.Typ != dbDatensatz.Typ || lstDatensatz.Gerätenummer != dbDatensatz.Gerätenummer || lstDatensatz.Originalnummer != dbDatensatz.Originalnummer || lstDatensatz.Bemerkung != dbDatensatz.Bemerkung || lstDatensatz.TÜV != dbDatensatz.TÜV || lstDatensatz.NichtVorhanden != dbDatensatz.NichtVorhanden || lstDatensatz.Options != dbDatensatz.Options)
                {
                    commit = true;
                }
                if (commit)
                {

                }
            }
        }

        public void Close()
        {
            this.sQLiteConnection.Close();
        }

        public List<Datensatz> GetListData()
        {
            return this.listDatensatz;
        }

        public void GetDataTable(ref System.Windows.Forms.DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("Typ", typeof(string));
            dataTable.Columns.Add("Gerätenummer", typeof(string));
            dataTable.Columns.Add("Originalnummer", typeof(string));
            dataTable.Columns.Add("Bemerkung", typeof(string));
            dataTable.Columns.Add("TÜV", typeof(DateTime));
            dataTable.Columns.Add("Nicht vorhanden", typeof(bool));

            foreach (Datensatz item in this.listDatensatz)
            {
                dataTable.Rows.Add(item.Id, item.Typ, item.Gerätenummer, item.Originalnummer, item.Bemerkung, item.TÜV, item.NichtVorhanden);
            }
            dataGridView.DataSource = dataTable;
        }
    }
}
