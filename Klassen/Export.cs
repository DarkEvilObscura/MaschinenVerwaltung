using System;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MaschinenVerwaltung
{
    class Export
    {
        private Excel.Application application;
        private Excel._Worksheet workSheet;

        private SaveFileDialog saveDialog = new SaveFileDialog();

        readonly double[] columnWidth = new double[5] { 0.92, 14.0, 13.57, 61.43, 9.0 };
        readonly double[] rowHeight = new double[3] { 15.75, 63.0, 43.50 };
        readonly double rowHeightAll = 21.0;

        readonly string[] tableHeader = new string[2] { "B2", "E2" };

        readonly string[] rowHeaderName = new string[4] { "B3", "C3", "D3", "E3" };
        readonly string[] rowHeaderValue = new string[4] { "Geräte\nNummer", "Original\nNummer", "Bemerkung", "TÜV" };
        readonly int[] rowHeaderFontSize = new int[4] { 19, 19, 20, 20 };

        readonly string[] rowCellName = new string[4] { "B4", "C4", "D4", "E4" };
        readonly int[] rowCellFontSize = new int[4] { 18, 14, 14, 16 };
        

        public Export()
        {
            this.application = new Excel.Application();
            this.application.Workbooks.Add();
            this.workSheet = (Excel._Worksheet)this.application.ActiveSheet;
        }

        public void Start()
        {
            SetColumnAlignment();
            SetRowAlignment(10);
            SetCellMerge("B2", "E2");
            SetTableHeader("Maschinen");
            SetTableBorder();
            SetRowHeader();
            SetRowBorder(true);
            SetRowBorder(false, 10);
            SaveFile();
        }

        void SetColumnAlignment()
        {
            for (int i = 0; i < columnWidth.Length; i++)
            {
                workSheet.Columns[i + 1].ColumnWidth = columnWidth[i];
            }
        }

        void SetRowAlignment(int number)
        {
            for (int i = 0; i < rowHeight.Length; i++)
            {
                workSheet.Rows[i + 1].RowHeight = rowHeight[i];
            }
            
            for (int i = rowHeight.Length+1; i <= number; i++)
            {
                workSheet.Rows[i].RowHeight = rowHeightAll;
            }
        }

        void SetCellMerge(string cell1, string cell2)
        {
            workSheet.Range[cell1, cell2].Merge();
        }

        void SetTableHeader(string tabellenTitel)
        {
            Excel.Range range = workSheet.Range[tableHeader[0], tableHeader[1]];
            range.Merge();

            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 4d;

            workSheet.get_Range(tableHeader[0], tableHeader[1]).Cells.Font.Name = "Calibri";
            workSheet.get_Range(tableHeader[0], tableHeader[1]).Cells.Font.Size = 48;
            workSheet.get_Range(tableHeader[0], tableHeader[1]).Cells.Font.Bold = true;
            workSheet.get_Range(tableHeader[0], tableHeader[1]).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workSheet.get_Range(tableHeader[0], tableHeader[1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workSheet.get_Range(tableHeader[0], tableHeader[1]).Value2 = tabellenTitel;
        }

        void SetTableBorder()
        {

        }

        void SetRowHeader()
        {
            Excel.Range range;
            for (int i = 0; i < rowHeaderValue.Length; i++)
            {
                range = workSheet.Range[rowHeaderName[i]];
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders.Weight = 4d;
                workSheet.get_Range(rowHeaderName[i]).Cells.Font.Name = "Calibri";
                workSheet.get_Range(rowHeaderName[i]).Cells.Font.Size = rowHeaderFontSize[i];
                workSheet.get_Range(rowHeaderName[i]).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                workSheet.get_Range(rowHeaderName[i]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workSheet.get_Range(rowHeaderName[i]).Value2 = rowHeaderValue[i];
            }
        }

        void SetRowBorder(bool first, int toRowNumber = 0)
        {
            Excel.Range range;
            if(first)
            {
                for (int i = 0; i < rowCellName.Length; i++)
                {
                    range = workSheet.Range[rowCellName[i]];
                    workSheet.get_Range(rowCellName[i]).Cells.Font.Name = "Calibri";
                    workSheet.get_Range(rowCellName[i]).Cells.Font.Size = rowCellFontSize[i];
                    if(i==0)
                    {
                        workSheet.get_Range(rowCellName[i]).Cells.Font.Bold = true;
                    }
                    range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.Borders.Weight = 2d;
                }
            }
            else
            {
                range = workSheet.get_Range("B5", "E" + toRowNumber.ToString());
                foreach (Excel.Range cell in range.Cells)
                {
                    cell.BorderAround2();
                }
            }
        }

        void SaveFile()
        {
            //saveDialog.Filter = "Excel-Arbeitsmappe (*.xlsx)|*.xlsx";
            //DialogResult dialogResult = saveDialog.ShowDialog();
            workSheet.SaveAs(System.Windows.Forms.Application.StartupPath + @"\MaschinenVerwaltungListe.xlsx");
            //if (dialogResult == DialogResult.OK)
            //{
            //    workSheet.SaveAs(System.Windows.Forms.Application.StartupPath + @"\MaschinenVerwaltungListe.xlsx");
            //}
            this.application.Quit();
            GC.Collect();
        }
    }
}

/*
//LISTE Thomas:
    Spalte A: Breite 0.92
    Spalte B: Breite 14
    Spalte C: Breite 13.57
    Spalte D: Breite 61.43
    Spalte E: Breite 9

    Merge:
        2B - 2E + Border 4d

    Zeilen-Höhe 1: 15.75
    Zeilen-Höhe 2: 63
    Zeilen-Höhe 3: 43.50
    Zeilen-Höhe 4-100: 21
*/

//-----------------------------------------

//workSheet.Cells[1, "A"] = "Make";
//workSheet.Cells[1, "B"] = "Color";
//workSheet.Cells[1, "C"] = "Pet name";

//-----------------------------------------

//Excel.Range range = workSheet.UsedRange;
//Excel.Range zelle = range.Cells[2, "D"];
//Excel.Borders border = zelle.Borders;

//border.LineStyle = Excel.XlLineStyle.xlContinuous;
//border.Weight = 4d;

//-----------------------------------------
/*
Excel.Range range2 = workSheet.get_Range("A4", "G9");
foreach (Excel.Range cell in range2.Cells)
{
    cell.BorderAround2(Excel.XlLineStyle.xlContinuous);
}
*/
//-----------------------------------------

//Setz die Spalte E (5) auf die Breite: 3
//workSheet.Columns[5].ColumnWidth = 0.92;

//-----------------------------------------

//workSheet.get_Range("A10", "C12").Merge();

//-----------------------------------------

/*
workSheet.Columns[1].ColumnWidth = 0.92; //Spalte A - Breite
workSheet.Rows[1].RowHeight = 15.75; //Zeile 1 - Höhe

workSheet.Columns[2].ColumnWidth = 14;
workSheet.Rows[2].RowHeight = 63.75;

workSheet.Columns[3].ColumnWidth = 13.57;
workSheet.Rows[3].RowHeight = 43.50;

workSheet.Columns[4].ColumnWidth = 61.43;
workSheet.Rows[4].RowHeight = 21;

workSheet.Columns[5].ColumnWidth = 9;
workSheet.Rows[5].RowHeight = 21;

workSheet.Rows[6].RowHeight = 21;
*/

/*
 
            Excel.Range range = workSheet.Range["B2", "E2"];
            range.Merge();

            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 4d;

            //Tabellen-Header
            workSheet.get_Range("B2", "E2").Cells.Font.Name = "Calibri";
            workSheet.get_Range("B2", "E2").Cells.Font.Size = 48;
            workSheet.get_Range("B2", "E2").Cells.Font.Bold = true;
            workSheet.get_Range("B2", "E2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workSheet.get_Range("B2", "E2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workSheet.get_Range("B2", "E2").Value2 = "Maschinen";

            //Gerätenummer-Header
            range = workSheet.Range["B3"];
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 4d;
            workSheet.get_Range("B3").Cells.Font.Name = "Calibri";
            workSheet.get_Range("B3").Cells.Font.Size = 19;
            workSheet.get_Range("B3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workSheet.get_Range("B3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workSheet.get_Range("B3").Value2 = "Geräte\nNummer";

            //Originalnummer-Header
            range = workSheet.Range["C3"];
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 4d;
            workSheet.get_Range("C3").Cells.Font.Name = "Calibri";
            workSheet.get_Range("C3").Cells.Font.Size = 19;
            workSheet.get_Range("C3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workSheet.get_Range("C3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workSheet.get_Range("C3").Value2 = "Original\nNummer";

            //Bemerkung-Header
            range = workSheet.Range["D3"];
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 4d;
            workSheet.get_Range("D3").Cells.Font.Name = "Calibri";
            workSheet.get_Range("D3").Cells.Font.Size = 20;
            workSheet.get_Range("D3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workSheet.get_Range("D3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workSheet.get_Range("D3").Value2 = "Bemerkung";

            //TÜV-Header
            range = workSheet.Range["E3"];
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 4d;
            workSheet.get_Range("E3").Cells.Font.Name = "Calibri";
            workSheet.get_Range("E3").Cells.Font.Size = 20;
            workSheet.get_Range("E3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            workSheet.get_Range("E3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            workSheet.get_Range("E3").Value2 = "TÜV";


            //Erste Eingabezeile (Gerätenummer)
            range = workSheet.Range["B4"];
            workSheet.get_Range("B4", "B9").Cells.Font.Name = "Calibri";
            workSheet.get_Range("B4", "B9").Cells.Font.Size = 18;
            workSheet.get_Range("B4", "B9").Cells.Font.Bold = true;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 2d;

            //Erste Eingabezeile (Originalnummer)
            range = workSheet.Range["C4"];
            workSheet.get_Range("C4", "C9").Cells.Font.Name = "Calibri";
            workSheet.get_Range("C4", "C9").Cells.Font.Size = 14;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 2d;

            //Erstel Eingabezeile (Bemerkung)
            range = workSheet.Range["D4"];
            workSheet.get_Range("D4", "D9").Cells.Font.Name = "Calibri";
            workSheet.get_Range("D4", "D9").Cells.Font.Size = 14;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 2d;

            //Erste Eingabezeile (TÜV)
            range = workSheet.Range["E4"];
            workSheet.get_Range("E4", "E9").Cells.Font.Name = "Calibri";
            workSheet.get_Range("E4", "E9").Cells.Font.Size = 16;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = 2d;

            //Alle anderen Eingabezeilen (Gerätenummer, Originalnummer, Bemerkung, TÜV)
            Excel.Range range2 = workSheet.get_Range("B5", "E9");
            foreach (Excel.Range cell in range2.Cells)
            {
                cell.BorderAround2(Excel.XlLineStyle.xlContinuous);
            }

            //Seitenränder: Oben, Unten, Links, Rechts
            workSheet.PageSetup.TopMargin = 2.1;
            //workSheet.PageSetup.BottomMargin = 2.0;
            workSheet.PageSetup.LeftMargin = 0.2d;
            workSheet.PageSetup.RightMargin = 0.3d;

            //Seitenränder (Kopf- Fußzeile)
            //workSheet.PageSetup.HeaderMargin = 0.8;
            //workSheet.PageSetup.FooterMargin = 0.8;


            //Excel.Borders border = zelle.Borders;
            //border.LineStyle = Excel.XlLineStyle.xlContinuous;
            //border.Weight = 4d;
 */