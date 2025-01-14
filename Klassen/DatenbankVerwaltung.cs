﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace MaschinenVerwaltung
{
    public class DatenbankVerwaltung
    {
        SQLiteConnectionStringBuilder sqLiteConnectionStringBuilder;
        SQLiteConnection sqLiteConnection;
        SQLiteCommand sqLiteCommand;

        string databaseFileName = string.Empty;

        ConnectionState state = ConnectionState.Closed;

        public enum SuchKategorie
        {
            Gerätenummer,
            Originalnummer,
            Bemerkung
        }

        public DatenbankVerwaltung()
        {
            
        }

        public bool CreateDatabaseFile(string databaseFileName)
        {
            bool exists = File.Exists(databaseFileName);
            if (!exists)
            {
                SQLiteConnection.CreateFile(databaseFileName);
                CreateTable(databaseFileName);
                CreateHistoryTableWithTrigger(databaseFileName);
            }
            return exists;
        }

        public void Open(string databaseFileName)
        {
            if(this.state==ConnectionState.Closed)
            {
                this.databaseFileName = databaseFileName;

                this.sqLiteConnection = new SQLiteConnection();
                this.sqLiteCommand = new SQLiteCommand();
                this.sqLiteConnectionStringBuilder = new SQLiteConnectionStringBuilder();
                this.sqLiteConnectionStringBuilder.DataSource = databaseFileName;
                this.sqLiteConnectionStringBuilder.ReadOnly = false;

                this.sqLiteConnection.ConnectionString = this.sqLiteConnectionStringBuilder.ConnectionString;

                this.sqLiteConnection.Open();
                this.state = this.sqLiteConnection.State;
            }
        }

        public void Close()
        {
            if(this.state==ConnectionState.Open)
            {
                this.sqLiteConnection.Close();
                this.state = this.sqLiteConnection.State;
            }
        }

        #region DDL-Methoden
        private void CreateTable(string databaseFileName)
        {
            Open(databaseFileName);
            string queryTable = "CREATE TABLE \"Maschinen\" (\"id\" INTEGER, \"Typ\" TEXT NOT NULL, \"Gerätenummer\" TEXT, \"Originalnummer\" TEXT, \"Bemerkung\" TEXT, \"TÜV\" TEXT,\"NichtVorhanden\" INTEGER, PRIMARY KEY(\"id\" AUTOINCREMENT));";
            string[] typen = new string[11] { "4070", "5190", "6080", "7081", "8080", "Art.S", "Breva", "Centura", "Prima Advance", "S3", "S4" };
            this.sqLiteCommand = new SQLiteCommand(queryTable, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.ExecuteNonQuery();
            string queryView = string.Empty;
            foreach (string item in typen)
            {
                queryView = $"CREATE VIEW [{item}] AS SELECT * FROM Maschinen WHERE Typ = \"{item}\" ORDER BY id asc;";
                this.sqLiteCommand = new SQLiteCommand(queryView, this.sqLiteConnection);
                this.sqLiteCommand.CommandType = CommandType.Text;
                this.sqLiteCommand.ExecuteNonQuery();
            }
            queryView = $"CREATE VIEW [TÜV] AS SELECT * FROM Maschinen WHERE DATE(TÜV) < DATE('now') ORDER BY id asc;";
            this.sqLiteCommand = new SQLiteCommand(queryView, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.ExecuteNonQuery();

            Close();
        }

        private void CreateHistoryTableWithTrigger(string databaseFileName)
        {
            Open(databaseFileName);
            string queryTable = "CREATE TABLE \"History\" (\"id\" INTEGER, \"oldTyp\" TEXT, \"newTyp\" TEXT, \"oldGerätenummer\" TEXT, \"newGerätenummer\" TEXT, \"oldOriginalnummer\" TEXT, \"newOriginalnummer\" TEXT, \"oldBemerkung\" TEXT, \"newBemerkung\" TEXT, \"oldTÜV\" TEXT, \"newTÜV\" TEXT, \"oldNichtVorhanden\" INTEGER, \"newNichtVorhanden\" INTEGER, \"oldoptions\" TEXT, \"newoptions\" TEXT, \"timestamp\" TEXT, \"user_action\" TEXT);";

            string queryInsertTrigger = "CREATE TRIGGER TR_Insert AFTER INSERT ON Maschinen BEGIN INSERT INTO History(id, newTyp, newGerätenummer, newOriginalnummer, newBemerkung, newTÜV, newNichtVorhanden, newoptions, timestamp, user_action) VALUES(NEW.id, NEW.Typ, NEW.Gerätenummer, NEW.Originalnummer, NEW.Bemerkung, NEW.TÜV, NEW.NichtVorhanden, NEW.options, strftime('%d.%m.%Y %H:%M:%S', 'now'), \"INSERT\"); END";
            string queryUpdateTrigger = "CREATE TRIGGER TR_Update AFTER UPDATE ON Maschinen BEGIN INSERT INTO History(id, oldTyp, newTyp, oldGerätenummer, newGerätenummer, oldOriginalnummer, newOriginalnummer, oldBemerkung, newBemerkung, oldTÜV, newTÜV, oldNichtVorhanden, newNichtVorhanden, oldoptions, newoptions, timestamp, user_action) VALUES(OLD.id, OLD.Typ, NEW.Typ, OLD.Gerätenummer, NEW.Gerätenummer, OLD.Originalnummer, NEW.Originalnummer, OLD.Bemerkung, NEW.Bemerkung, OLD.TÜV, NEW.TÜV, OLD.NichtVorhanden, NEW.NichtVorhanden, OLD.options, NEW.options, strftime('%d.%m.%Y %H:%M:%S', 'now'), \"UPDATE\"); END";
            string queryDeleteTrigger = "CREATE TRIGGER TR_Delete AFTER DELETE ON Maschinen BEGIN INSERT INTO History(id, oldTyp, oldGerätenummer, oldOriginalnummer, oldBemerkung, oldTÜV, oldNichtVorhanden, oldoptions, timestamp, user_action) VALUES(OLD.id, OLD.Typ, OLD.Gerätenummer, OLD.Originalnummer, OLD.Bemerkung, OLD.TÜV, OLD.NichtVorhanden, OLD.options, strftime('%d.%m.%Y %H:%M:%S', 'now'), \"DELETE\"); END;";

            this.sqLiteCommand = new SQLiteCommand(queryTable, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.ExecuteNonQuery();

            this.sqLiteCommand = new SQLiteCommand(queryInsertTrigger, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.ExecuteNonQuery();

            this.sqLiteCommand = new SQLiteCommand(queryUpdateTrigger, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.ExecuteNonQuery();

            this.sqLiteCommand = new SQLiteCommand(queryDeleteTrigger, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.ExecuteNonQuery();
            Close();
        }
        #endregion

        #region DML-Methoden
        public int Insert(Datensatz datensatz)
        {
            string queryInsert = "INSERT INTO Maschinen(Typ, Gerätenummer, Originalnummer, Bemerkung, TÜV, NichtVorhanden, options) VALUES (@typ, @gerätenummer, @originalnummer, @bemerkung, @tüv, @nichtVorhanden, @options);";
            this.sqLiteCommand = new SQLiteCommand(queryInsert, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.Parameters.AddWithValue("@typ", datensatz.Typ);
            this.sqLiteCommand.Parameters.AddWithValue("@gerätenummer", datensatz.Gerätenummer);
            this.sqLiteCommand.Parameters.AddWithValue("@originalnummer", datensatz.Originalnummer);
            this.sqLiteCommand.Parameters.AddWithValue("@bemerkung", datensatz.Bemerkung);
            this.sqLiteCommand.Parameters.AddWithValue("@tüv", datensatz.TÜV.Date.ToString("yyyy-MM-01"));
            this.sqLiteCommand.Parameters.AddWithValue("@nichtVorhanden", (datensatz.NichtVorhanden) ? "1" : "0");
            this.sqLiteCommand.Parameters.AddWithValue("@options", new Options().SerializeOptions(datensatz.Options));

            return this.sqLiteCommand.ExecuteNonQuery();
        }

        public int Update(Datensatz altDatensatz, Datensatz neuDatensatz)
        {
            if(neuDatensatz!=null)
            {
                string updates = string.Empty;
                if (altDatensatz.Typ != neuDatensatz.Typ)
                {
                    updates += $"Typ=\"{neuDatensatz.Typ}\"";
                }
                if (altDatensatz.Gerätenummer != neuDatensatz.Gerätenummer)
                {
                    updates += (updates.Length == 0 ? string.Empty : ", ") + $"Gerätenummer=\"{neuDatensatz.Gerätenummer}\"";
                }
                if (altDatensatz.Originalnummer != neuDatensatz.Originalnummer)
                {
                    updates += (updates.Length == 0 ? string.Empty : ", ") + $"Originalnummer=\"{neuDatensatz.Originalnummer}\"";
                }
                if (altDatensatz.Bemerkung != neuDatensatz.Bemerkung)
                {
                    updates += (updates.Length == 0 ? string.Empty : ", ") + $"Bemerkung=\"{neuDatensatz.Bemerkung}\"";
                }
                if (altDatensatz.TÜV != neuDatensatz.TÜV)
                {
                    //updates += (updates.Length == 0 ? string.Empty : ", ") + $"TÜV=\"{neuDatensatz.TÜV.Date}\"";
                    //updates += (updates.Length == 0 ? string.Empty : ", ") + $"TÜV = strftime('%Y-%m-01', '{neuDatensatz.TÜV.Date.Year}-{neuDatensatz.TÜV.Date.Month}-01')";
                    //string tüv = string.Format("TÜV=\"{0}\"", neuDatensatz.TÜV.Date.ToString("yyyy-MM-01"));
                    updates += (updates.Length == 0 ? string.Empty : ", ") + $"TÜV=\"{neuDatensatz.TÜV.Date.ToString("yyyy-MM-01")}\"";
                }
                if (altDatensatz.NichtVorhanden != neuDatensatz.NichtVorhanden)
                {
                    updates += (updates.Length == 0 ? string.Empty : ", ") + $"NichtVorhanden=\"{Convert.ToInt32(neuDatensatz.NichtVorhanden)}\"";
                }
                if (altDatensatz.Options.ForeColor != neuDatensatz.Options.ForeColor || altDatensatz.Options.BackgroundColor != neuDatensatz.Options.BackgroundColor)
                {
                    string xml = new Options().SerializeOptions(neuDatensatz.Options).Replace("\"", "\"\"");
                    updates += (updates.Length == 0 ? string.Empty : ", ") + $"options=\"{xml}\"";
                }

                if (updates != string.Empty)
                {
                    //string queryUpdate = $"UPDATE Maschinen SET {updates} WHERE id=" + altDatensatz.Id.ToString();
                    string queryUpdate = $"UPDATE Maschinen SET {updates} WHERE id=@id;";
                    this.sqLiteCommand = new SQLiteCommand(queryUpdate, this.sqLiteConnection);
                    this.sqLiteCommand.CommandType = CommandType.Text;
                    this.sqLiteCommand.Parameters.AddWithValue("@id", DbType.AnsiString).Value = altDatensatz.Id.ToString();
                    return this.sqLiteCommand.ExecuteNonQuery();
                }
            }
            return 0;
        }
        
        public int Delete(Datensatz datensatz)
        {
            string queryDelete = "DELETE FROM Maschinen WHERE id=@id;";
            this.sqLiteCommand = new SQLiteCommand(queryDelete, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            this.sqLiteCommand.Parameters.AddWithValue("@id", DbType.AnsiString).Value = datensatz.Id;
            //this.sqLiteCommand.Parameters.AddWithValue("@typ", DbType.AnsiString).Value = datensatz.Typ;
            //this.sqLiteCommand.Parameters.AddWithValue("@gerätenummer", DbType.AnsiString).Value = datensatz.Gerätenummer;
            //this.sqLiteCommand.Parameters.AddWithValue("@originalnummer", DbType.AnsiString).Value = (datensatz.Originalnummer.Length > 0) ? datensatz.Originalnummer : string.Empty;

            return this.sqLiteCommand.ExecuteNonQuery();
        }
        #endregion

        #region DQL-Methoden
        public DataTable GetMaschinen(string maschinenTyp)
        {
            DataTable table = new Tabelle().SetHeader((maschinenTyp=="*") ? "Maschinen" : maschinenTyp);

            string queryMaschinen = "SELECT * FROM Maschinen " + (maschinenTyp == "*" ? "ORDER BY Typ" : $"WHERE Typ=\"{maschinenTyp}\" ORDER BY Gerätenummer") + " asc";
            this.sqLiteCommand = new SQLiteCommand(queryMaschinen, this.sqLiteConnection);
            List<Datensatz> listDatensätze = ExecReader();
            table.Merge(ConvertListToTable(listDatensätze, "Maschinen"));

            return table;
        }

        public DataTable GetTÜVGeräte()
        {
            DataTable table = new Tabelle().SetHeader("TÜVMaschinen");

            string queryTÜV = "SELECT * FROM TÜV;";
            this.sqLiteCommand = new SQLiteCommand(queryTÜV, this.sqLiteConnection);
            List<Datensatz> listDatensätze = ExecReader();
            return ConvertListToTable(listDatensätze, "TÜVMaschinen");
        }

        public Datensatz GetSingleDatensatz(int datensatzId)
        {
            string query = "SELECT * FROM Maschinen WHERE id=@id;";
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);
            this.sqLiteCommand.Parameters.AddWithValue("@id", datensatzId);


            this.sqLiteCommand.CommandType = CommandType.Text;
            //this.sqLiteCommand.Parameters.AddWithValue("@id", datensatzId);
            SQLiteDataReader reader = this.sqLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string typ = reader.GetString(1);
                string gerätenummer = reader.GetString(2);
                string originalnummer = reader.GetString(3);
                string bemerkung = reader.GetString(4);
                //DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                DateTime tüv;
                try
                {
                    tüv = DateTime.Parse(reader.GetString(5));
                }
                catch (InvalidCastException)
                {
                    tüv = DateTime.MinValue;
                }
                bool nichtVorhanden = Convert.ToBoolean(reader.GetValue(6)); //Convert.ToBoolean(reader.GetInt32(6));
                string xmlOptions = reader.GetString(7);

                Options options = new Options();
                if (xmlOptions.Length > 0)
                {
                    options = options.DeserializeOptions(xmlOptions);
                }
                else
                {
                    options.BackgroundColor = Color.White;
                    options.ForeColor = Color.Black;
                }

                return new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, options);
            }
            return null;
        }

        public int GetAnzahlDatensätze()
        {
            string query = "SELECT COUNT(*) FROM Maschinen;";
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);
            this.sqLiteCommand.CommandType = CommandType.Text;
            SQLiteDataReader reader = this.sqLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }

        public DataTable Suchen(string suchText, SuchKategorie kategorie)
        {
            //DataTable tableSuchergebnisse = new Tabelle().SetHeader("Suchergebnisse");
            string k = string.Empty;
            if(kategorie==SuchKategorie.Gerätenummer)
            {
                k = "Gerätenummer";
            }
            else if(kategorie==SuchKategorie.Originalnummer)
            {
                k = "Originalnummer";
            }
            else if(kategorie==SuchKategorie.Bemerkung)
            {
                k = "Bemerkung";
            }
            string query = $"SELECT * FROM Maschinen WHERE {k} LIKE '%{suchText}%'";
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);
            //this.sqLiteCommand.CommandType = CommandType.Text;
            List<Datensatz> datensätze = ExecReader();
            return ConvertListToTable(datensätze, "Suchergebnisse");


                //SQLiteDataReader reader = this.sqLiteCommand.ExecuteReader();
                //while (reader.Read())
                //{
                //    int id = reader.GetInt32(0);
                //    string typ = reader.GetString(1);
                //    string gerätenummer = reader.GetString(2);
                //    string originalnummer = reader.GetString(3);
                //    string bemerkung = reader.GetString(4);
                //    DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                //    bool nichtVorhanden = Convert.ToBoolean(reader.GetValue(6)); //Convert.ToBoolean(reader.GetInt32(6));
                //    string xmlOptions = reader.GetString(7);

            //    Options options = new Options();
            //    if (xmlOptions.Length > 0)
            //    {
            //        options = options.DeserializeOptions(xmlOptions);
            //    }
            //    else
            //    {
            //        options.BackgroundColor = Color.White;
            //        options.ForeColor = Color.Black;
            //    }

            //    Datensatz datensatz = new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, options);
            //    tableSuchergebnisse = new Tabelle().SetRow(tableSuchergebnisse, datensatz);
            //}

            //return tableSuchergebnisse;
        }

        public DataTable Suchen(DateTime tüv)
        {
            string query = string.Format("SELECT * FROM Maschinen WHERE TÜV=\"{0}-{1}-{2}\"", tüv.Year, tüv.Month, "01");
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);

            List<Datensatz> datensätze = ExecReader();
            return ConvertListToTable(datensätze, "Suchergebnisse");
        }

        public DataTable Suchen(DateTime tüvVon, DateTime tüvBis)
        {
            string query = string.Format("SELECT * FROM Maschinen WHERE TÜV BETWEEEN DATE('{0}-{1}-{2}') AND DATE('{3}-{4}-{5}');", tüvVon.Year, tüvVon.Month, "01", tüvBis.Year, tüvBis.Month, "01");
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);

            List<Datensatz> datensätze = ExecReader();
            return ConvertListToTable(datensätze, "Suchergebnisse");
        }

        public DataTable Suchen(bool ohneTÜV, bool nichtVorhanden)
        {
            string query = string.Empty;
            if(ohneTÜV)
            {
                query = "SELECT * FROM Maschinen WHERE TÜV = DATE('0001-01-01');";
            }
            else if(nichtVorhanden)
            {
                query = "SELECT * FROM Maschinen WHERE NichtVorhanden=1;";
            }
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);
            List<Datensatz> datensätze = ExecReader();
            return ConvertListToTable(datensätze, "Suchergebnisse");
        }

        public DataTable Suchen(Color color, bool foreColor, bool backgroundColor)
        {
            string query = "SELECT * FROM Maschinen WHERE length(options)>0;";
            this.sqLiteCommand = new SQLiteCommand(query, this.sqLiteConnection);
            List<Datensatz> datensätze = ExecReader();
            List<Datensatz> listColorDatensätze = new List<Datensatz>();
            if (foreColor)
            {
                foreach (Datensatz item in datensätze)
                {
                    if(item.Options.ForeColor == color)
                    {
                        listColorDatensätze.Add(item);
                    }
                }
            }
            else if(backgroundColor)
            {
                foreach (Datensatz item in datensätze)
                {
                    if(item.Options.BackgroundColor == color)
                    {
                        listColorDatensätze.Add(item);
                    }
                }
            }
            return ConvertListToTable(listColorDatensätze, "Suchergebnisse");
        }
        #endregion

        private List<Datensatz> ExecReader()
        {
            List<Datensatz> listDatensätze = new List<Datensatz>();

            this.sqLiteCommand.CommandType = CommandType.Text;
            SQLiteDataReader reader = this.sqLiteCommand.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string typ = reader.GetString(1);
                string gerätenummer = reader.GetString(2);
                string originalnummer = reader.GetString(3);
                string bemerkung = reader.GetString(4);
                DateTime tüv;
                try
                {
                    tüv = DateTime.Parse(reader.GetString(5));
                }
                catch (InvalidCastException)
                {
                    tüv = DateTime.MinValue;
                }
                //DateTime tüv = (reader.GetString(5).Length > 0 ? new DateTime(DateTime.Parse(reader.GetString(5)).Year, DateTime.Parse(reader.GetString(5)).Month, DateTime.Parse(reader.GetString(5)).Day) : new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day));
                bool nichtVorhanden = Convert.ToBoolean(reader.GetValue(6)); //Convert.ToBoolean(reader.GetInt32(6));
                string xmlOptions = reader.GetString(7);

                Options options = new Options();
                if (xmlOptions.Length > 0)
                {
                    options = options.DeserializeOptions(xmlOptions);
                }
                else
                {
                    options.BackgroundColor = Color.White;
                    options.ForeColor = Color.Black;
                }

                Datensatz datensatz = new Datensatz(id, typ, gerätenummer, originalnummer, bemerkung, tüv, nichtVorhanden, options);
                listDatensätze.Add(datensatz);
            }
            return listDatensätze;
        }

        private DataTable ConvertListToTable(List<Datensatz> listDatensätze, string tableName)
        {
            DataTable table = new Tabelle().SetHeader(tableName);
            foreach (Datensatz item in listDatensätze)
            {
                table = new Tabelle().SetRow(table, item);
            }
            return table;
        }
    }
}
