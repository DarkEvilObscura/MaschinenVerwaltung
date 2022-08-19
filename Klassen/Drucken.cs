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

        public Drucken(string typ, List<Datensatz> datensätze)
        {
            printDocument.PrintPage += PrintDocument_PrintPage;

            this.title = typ;
            this.datensätze = datensätze;

            Rectangle pageBoundsRectangle = new Rectangle(0, 0, 100, 200);
            Rectangle marginRectangle = new Rectangle(5, 5, 95, 195);

            Prepare();
        }

        private void Prepare()
        {
            Size sTyp = (this.title == "TÜV" ? Utils.GetSize("   Typ   ", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular)) : new Size());
            Size sGerätenummer = Utils.GetSize("Gerätenummer", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));
            Size sOriginalnummer = Utils.GetSize("Originalnummer", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));
            Size sBemerkung = Utils.GetSize("       Bemerkung       ", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));
            Size sTüv = Utils.GetSize("   TÜV   ", new Font(new FontFamily("Calibri"), 20f, FontStyle.Regular));


            listHeaders.Add(new Tuple<string, Size>("   Typ   ", sTyp));
            listHeaders.Add(new Tuple<string, Size>("Gerätenummer", sGerätenummer));
            listHeaders.Add(new Tuple<string, Size>("Originalnummer", sOriginalnummer));
            listHeaders.Add(new Tuple<string, Size>("       Bemerkung       ", sBemerkung));
            listHeaders.Add(new Tuple<string, Size>("   TÜV   ", sTüv));

            foreach (Tuple<string, Size> item in listHeaders)
            {
                this.maxWidth += (!item.Item2.IsEmpty ? item.Item2.Width : 0);
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
                e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(offsetX, offsetY, item.Item2.Width, item.Item2.Height));
                e.Graphics.FillRectangle(Brushes.LightGray, new RectangleF(offsetX + 0.5f, offsetY + 0.5f, item.Item2.Width - 1, item.Item2.Height - 1));
                e.Graphics.DrawString(item.Item1, new Font(FontFamily.GenericSansSerif, 16f), Brushes.Black, new PointF(offsetX, offsetY));

                offsetX += item.Item2.Width;
            }
        }

        private void PrintList(PrintPageEventArgs e)
        {
            int offsetX = 25;
            int offsetY = 100;

            bool colorized;

            int i;

            for (int j = this.datensatzIndex; j < this.datensätze.Count; j++, this.datensatzIndex++)
            {
                if (offsetY == 1080)
                {
                    e.HasMorePages = true;
                    return;
                }

                //offsetX = 25;
                offsetY += 35;

                colorized = (this.datensätze[j].Options != null);

                i = 1;

                if (colorized)
                {
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.datensätze[j].Options.BackgroundColor)), new Rectangle(offsetX, offsetY, maxWidth, 35));
                    e.Graphics.FillRectangle(new SolidBrush(this.datensätze[j].Options.BackgroundColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
                }

                e.Graphics.DrawString(this.datensätze[j].Gerätenummer, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Bold), (colorized ? new SolidBrush(this.datensätze[j].Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));
                offsetX += listHeaders[i].Item2.Width;
                i++;
                e.Graphics.DrawString(this.datensätze[j].Originalnummer, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), (colorized ? new SolidBrush(this.datensätze[j].Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));
                offsetX += listHeaders[i].Item2.Width;
                i++;

                if (this.datensätze[j].Bemerkung.Length > 0)
                {
                    e.Graphics.DrawString(this.datensätze[j].Bemerkung.Trim(), new Font(FontFamily.GenericSansSerif, 11f, FontStyle.Regular), (colorized ? new SolidBrush(this.datensätze[j].Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));
                }
                offsetX += listHeaders[i].Item2.Width;

                e.Graphics.DrawString(this.datensätze[j].TÜV.ToString("MM.yyyy"), new Font(FontFamily.GenericSansSerif, 14f, FontStyle.Regular), (colorized ? new SolidBrush(this.datensätze[j].Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));

                offsetX = 25;
            }


            //foreach (Datensatz item in this.datensätze)
            //{
                

                

            //    offsetX = 25;
            //    offsetY += 35;

            //    colorized = (item.Options != null);

            //    i = 1;

            //    if (colorized)
            //    {
            //        e.Graphics.DrawRectangle(new Pen(new SolidBrush(item.Options.BackgroundColor)), new Rectangle(offsetX, offsetY, maxWidth, 35));
            //        e.Graphics.FillRectangle(new SolidBrush(item.Options.BackgroundColor), new Rectangle(offsetX, offsetY, maxWidth, 35));
            //    }

            //    e.Graphics.DrawString(item.Gerätenummer, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Bold), (colorized ? new SolidBrush(item.Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));
            //    offsetX += listHeaders[i].Item2.Width;
            //    i++;
            //    e.Graphics.DrawString(item.Originalnummer, new Font(FontFamily.GenericSansSerif, 18f, FontStyle.Regular), (colorized ? new SolidBrush(item.Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));
            //    offsetX += listHeaders[i].Item2.Width;
            //    i++;

            //    if (item.Bemerkung.Length > 0)
            //    {
            //        e.Graphics.DrawString(item.Bemerkung.Trim(), new Font(FontFamily.GenericSansSerif, 11f, FontStyle.Regular), (colorized ? new SolidBrush(item.Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));
            //    }
            //    offsetX += listHeaders[i].Item2.Width;
                
            //    e.Graphics.DrawString(item.TÜV.ToString("MM.yyyy"), new Font(FontFamily.GenericSansSerif, 14f, FontStyle.Regular), (colorized ? new SolidBrush(item.Options.ForeColor) : Brushes.Black), new PointF(offsetX, offsetY));

            //    Trace.WriteLine(String.Format("offsetY: {0}", offsetY));
            //}

            //e.HasMorePages = false;

            //return e;
        }

        public void Print()
        {
            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
