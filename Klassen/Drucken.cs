using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    class Drucken
    {
        static PrintDocument printDocument = new PrintDocument();

        string title = string.Empty;
        List<Datensatz> datensätze = new List<Datensatz>();

        static List<Tuple<string, Size>> listHeaders = new List<Tuple<string, Size>>();

        int maxWidth = 0;

        int datensatzIndex = 0;

        Color rowColor = Color.White;
        

        public Drucken(string typ, List<Datensatz> datensätze)
        {
            printDocument.PrintPage += PrintDocument_PrintPage;

            this.title = typ;
            this.datensätze = datensätze;

            Prepare();
        }

        private void Prepare()
        {
            Size sTyp = (this.title == "TÜV" ? Utils.GetSize("   Typ   ", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular)) : new Size());
            Size sGerätenummer = Utils.GetSize("Gerätenr.", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));
            Size sOriginalnummer = Utils.GetSize("Originalnr.", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));
            Size sBemerkung = Utils.GetSize("                Bemerkung                ", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));
            Size sTüv = Utils.GetSize("   TÜV   ", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));


            listHeaders.Add(new Tuple<string, Size>("   Typ   ", sTyp));
            listHeaders.Add(new Tuple<string, Size>("Gerätenr.", sGerätenummer));
            listHeaders.Add(new Tuple<string, Size>("Originalnr.", sOriginalnummer));
            listHeaders.Add(new Tuple<string, Size>("                Bemerkung                ", sBemerkung));
            listHeaders.Add(new Tuple<string, Size>("   TÜV   ", sTüv));

            foreach (Tuple<string, Size> item in listHeaders)
            {
                if(this.title!="TÜV" && item.Item1 == "   Typ   ")
                {
                    continue;
                }
                else
                {
                    this.maxWidth += (!item.Item2.IsEmpty ? item.Item2.Width : 0);
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.PaperSize = new PaperSize("A4", 830, 1170);

            PrintHeader(e);
            PrintList(e);
        }

        private void PrintHeader(PrintPageEventArgs e)
        {
            int offsetX = 25;
            int offsetY = 100;

            //Title
            e.Graphics.DrawString(this.title, new Font(new FontFamily("Calibri"), 40f, FontStyle.Bold), Brushes.Black, new PointF(350f, 10f));

            //Spalten
            foreach (Tuple<string, Size> item in listHeaders)
            {
                if(this.title!="TÜV" && item.Item1== "   Typ   ")
                {
                    continue;
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(offsetX, offsetY, item.Item2.Width, item.Item2.Height));
                    e.Graphics.FillRectangle(Brushes.LightGray, new RectangleF(offsetX + 0.5f, offsetY + 0.5f, item.Item2.Width - 1, item.Item2.Height - 1));
                    e.Graphics.DrawString(item.Item1, new Font(FontFamily.GenericSansSerif, 16f), Brushes.Black, new PointF(offsetX, offsetY));

                    offsetX += item.Item2.Width;
                }
            }
        }

        private void PrintRowColor(PrintPageEventArgs e, Datensatz datensatz, int offsetX, int offsetY)
        {
            bool colorized = (datensatz.Options != null);
            if (colorized)
            {
                if (datensatz.Options.ForeColorARGB == -16777216 && datensatz.Options.BackgroundColorARGB == -1)
                {
                    e.Graphics.DrawRectangle(new Pen(rowColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
                    e.Graphics.FillRectangle(new SolidBrush(rowColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(datensatz.Options.BackgroundColor)), new Rectangle(offsetX, offsetY, maxWidth, 35));
                    e.Graphics.FillRectangle(new SolidBrush(datensatz.Options.BackgroundColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
                }
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(rowColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
                e.Graphics.FillRectangle(new SolidBrush(rowColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
            }

            rowColor = (rowColor == Color.White ? Color.LightGray : Color.White);

            PrintRowContent(e, datensatz, offsetX, offsetY);
        }

        private void PrintRowContent(PrintPageEventArgs e, Datensatz datensatz, int offsetX, int offsetY)
        {
            if (this.title == "TÜV")
            {
                switch(datensatz.Typ)
                {
                    case "Centura":
                        e.Graphics.DrawString("Cent.", new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
                        break;
                    case "Prima Advance":
                        e.Graphics.DrawString("PA", new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
                        break;
                    default:
                        e.Graphics.DrawString(datensatz.Typ, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
                        break;
                }
                //e.Graphics.DrawString(datensatz.Typ, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Bold), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY));
                offsetX += listHeaders[0].Item2.Width;
            }

            e.Graphics.DrawString(datensatz.Gerätenummer, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Bold), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
            offsetX += listHeaders[1].Item2.Width;
            e.Graphics.DrawString(datensatz.Originalnummer, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
            offsetX += listHeaders[2].Item2.Width;
            if(datensatz.Bemerkung.Length>0)
            {
                Size sBemerkungstext = Utils.GetSize(datensatz.Bemerkung, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular));
                if (sBemerkungstext.Width > listHeaders[3].Item2.Width)
                {
                    string text;
                    Size sBemerkungstextAbgekürzt;
                    Size sBemerkungstextFF;
                    float percent;
                    for (int i = 0; i < datensatz.Bemerkung.Length; i++)
                    {
                        text = datensatz.Bemerkung.Substring(0, i);
                        sBemerkungstextAbgekürzt = Utils.GetSize(text, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular));
                        sBemerkungstextFF = Utils.GetSize("...", new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular));
                        percent = ((sBemerkungstextAbgekürzt.Width + sBemerkungstextFF.Width) / listHeaders[3].Item2.Width) * 100f;
                        if(percent >= 98f)
                        {
                            e.Graphics.DrawString(text + "...", new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
                            break;
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString(datensatz.Bemerkung, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
                }
            }
            offsetX += listHeaders[3].Item2.Width;
            e.Graphics.DrawString(datensatz.TÜV.ToString("MM.yyyy"), new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), new SolidBrush(datensatz.Options.ForeColor), new PointF(offsetX, offsetY + 3));
        }

        private void PrintList(PrintPageEventArgs e)
        {
            int offsetX = 25; //+ (this.title == "TÜV" ? listHeaders[0].Item2.Width : 0);
            int offsetY = 100;


            for (int j = this.datensatzIndex; j < this.datensätze.Count; j++, this.datensatzIndex++)
            {
                if (offsetY == 1080) //100 + (28*35) = 1080 -> 28 Einträge/Seite
                {
                    e.HasMorePages = true;
                    return;
                }

                offsetY += 35;

                PrintRowColor(e, this.datensätze[j], offsetX, offsetY);
            }
        }

        public void Print()
        {
            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nSchließen Sie alle Programme die auf das Dokument zugreifen.");
            }
            finally
            {
                printDocument.Dispose();
            }
        }
    }
}
