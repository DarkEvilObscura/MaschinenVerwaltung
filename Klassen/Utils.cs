using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    class Utils
    {
        #region DataGridView
        public static void DataGridViewSetupColumnAlignment(ref DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void DataGridViewSetupColumnVisible(ref DataGridView dataGridView, bool showTyp = false)
        {
            bool[] vs = new bool[10] {
                false,      //id
                showTyp,    //Typ
                true,       //Gerätenummer
                true,       //Originalnummer
                true,       //Bemerkung
                true,       //TÜV
                true,       //Nicht Vorhanden
                false,      //Options
                true,       //Button: Bearbeiten
                true        //Button: Löschen
            };

            for (int i = 0; i < /*vs.Length*/ dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Visible = vs[i];
            }
        }

        public static void DataGridViewSetupColumnWidth(ref DataGridView dataGridView, int fontSize)
        {
            int width = dataGridView.Size.Width;

            int[] vs = new int[10] {
                0,                                  //id
                8*fontSize,                         //Typ (Default:64)
                6*fontSize,                         //Gerätenummer (Default:48)
                6*fontSize,                         //Originalnummer (Default:48)
                (int)(width * 0.65),   //Bemerkung(Default: width*0.7) 
                5*fontSize,                         //TÜV (Default:40)
                5*fontSize,                         //Nicht Vorhanden (Default:40)
                0,                                  //Options
                3*fontSize,                         //Button: Bearbeiten (Default:24)
                3*fontSize                          //Button: Löschen (Default:24)
            };

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                //dataGridView.Columns[i].Width = vs[i];
                if(i==4)
                {
                    dataGridView.Columns[i].Width = (int)(width * 0.65);
                }
                else if(i==5)
                {
                    dataGridView.Columns[i].Width = GetSize("01.0001", dataGridView.Font).Width;
                }
                else if(i==8 || i==9)
                {
                    dataGridView.Columns[i].Width = GetSize("btn", dataGridView.Font).Width;
                }
                else
                {
                    dataGridView.Columns[i].Width = GetSize(dataGridView.Columns[i].HeaderText, dataGridView.Font).Width;
                }
                //dataGridView.Columns[i].Width = (i==4) ? (int)(width * 0.65) : GetWidth(dataGridView.Columns[i].HeaderText, dataGridView.Font).Width;
            }
        }

        public static void DataGridViewSetupRowAlignment(ref DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if(dataGridView.Rows[i].Cells["Bemerkung"].Value.ToString().Length>0)
                {
                    dataGridView.Rows[i].Cells["Bemerkung"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void DataGridViewSetupAddButtons(ref DataGridView dataGridView)
        {
            DataGridViewButtonColumn buttonBearbeitenColumn = new DataGridViewButtonColumn();
            buttonBearbeitenColumn.Name = "";
            dataGridView.Columns.Insert(8, buttonBearbeitenColumn);

            DataGridViewButtonColumn buttonLöschenColumn = new DataGridViewButtonColumn();
            buttonLöschenColumn.Name = "";
            dataGridView.Columns.Insert(9, buttonLöschenColumn);
        }

        public static void DataGridViewSetupAddColor(ref DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                string xmlOptions = dataGridView.Rows[i].Cells[7].Value.ToString();
                if (xmlOptions.Length > 0)
                {
                    Options options = new Options().DeserializeOptions(xmlOptions);
                    dataGridView.Rows[i].DefaultCellStyle.ForeColor = options.ForeColor;
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = options.BackgroundColor;
                }
            }
        }

        public static void DataGridViewSetupColumnSettings(ref DataGridView dataGridView)
        {
            dataGridView.Columns["TÜV"].DefaultCellStyle.Format = "MM.yyyy";
        }

        public static void DataGridViewSetup(ref DataGridView dataGridView, int selectedIndex, bool login)
        {
            if(selectedIndex!=11 && login)
            {
                DataGridViewSetupAddButtons(ref dataGridView);
            }
            DataGridViewSetupColumnAlignment(ref dataGridView);
            DataGridViewSetupColumnWidth(ref dataGridView, (int)USettings.GetSystemFontStyle().Size);
            DataGridViewSetupRowAlignment(ref dataGridView);
            DataGridViewSetupColumnVisible(ref dataGridView, (selectedIndex==11));
            DataGridViewSetupColumnSettings(ref dataGridView);
            DataGridViewSetupAddColor(ref dataGridView);
        }
        #endregion

        public static Size GetSize(string text, Font font)
        {
            Size size = TextRenderer.MeasureText(text, font);
            return size;
        }
    }
}
