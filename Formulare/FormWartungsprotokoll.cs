using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    public partial class FormWartungsprotokoll : Form
    {
        Datensatz oldDatensatz;
        public Datensatz NewDatensatz { get; private set; }
        bool login;

        string wartungsprotokoll;

        bool textChanged = false;

        bool init = true;

        Font wartungsprotokollFont;

        public FormWartungsprotokoll(Datensatz datensatz, bool login)
        {
            InitializeComponent();
            this.oldDatensatz = datensatz;
            this.login = login;
            this.wartungsprotokollFont = USettings.GetWartungsprotokollFontStyle();
        }

        private void FormWartungsprotokoll_Load(object sender, EventArgs e)
        {
            this.wartungsprotokoll = this.oldDatensatz.Wartungsprotokoll;
            
            richTextBox.Text = this.wartungsprotokoll;
            richTextBox.Font = this.wartungsprotokollFont;
            richTextBox.ReadOnly = !this.login;

            toolStripStatusLabelDatensatz.Text = $"Typ: {this.oldDatensatz.Typ} | Gerätenummer: {this.oldDatensatz.Gerätenummer} | Originalnummer: {this.oldDatensatz.Originalnummer}";
            
            toolStripStatusLabelNoLogon.Visible = !this.login;
            
            this.init = false;
        }

        private void schriftartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.ShowEffects = false;
            dialog.ShowColor = false;

            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                this.init = true;
                this.richTextBox.Font = dialog.Font;
                this.wartungsprotokollFont = dialog.Font;
                USettings.SetWartungsprotokollFontStyle(dialog.Font.Name, dialog.Font.Style, dialog.Font.Size);
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!this.textChanged && !this.init)
            {
                textChanged = true;
                this.init = false;
            }
        }

        private void FormWartungsprotokoll_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.textChanged)
            {
                DialogResult result = MessageBox.Show("Möchten Sie die Änderung am Wartungsprotokoll speichern ?", "MaschinenVerwaltung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    this.NewDatensatz = new Datensatz(this.oldDatensatz.Id, this.oldDatensatz.Typ, this.oldDatensatz.Gerätenummer, this.oldDatensatz.Originalnummer, this.oldDatensatz.Bemerkung, this.oldDatensatz.TÜV, this.oldDatensatz.NichtVorhanden, this.oldDatensatz.Options, richTextBox.Text);
                }
                else
                {
                    this.NewDatensatz = null;
                }
            }
        }
    }
}
