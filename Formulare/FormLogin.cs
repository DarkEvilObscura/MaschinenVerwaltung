using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;

namespace MaschinenVerwaltung
{
    public partial class FormLogin : Form
    {
        SHA256 sha256Hash;

        Font systemFont;

        public bool Login { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
            this.systemFont = USettings.GetSystemFontStyle();
            //labelPasswort.Font = this.systemFont;
            //maskedTextBox.Font = this.systemFont;
            sha256Hash = SHA256.Create();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(maskedTextBox.Text.Length>0)
            {
                string pw = ComputeSHA256(maskedTextBox.Text);
                if (pw == "33b514d313ac0630efbe3067574cf2ad147bd27cc6fe9d0b965f1d3b8c3707f8")
                {
                    this.Login = true;
                    USettings.SetLogonStatus(checkBoxPasswortSpeichern.Checked);
                    ActiveForm.Close();
                }
                else
                {
                    MessageBox.Show("Das eingegebene Passwort stimmt nicht überein", "MaschinenVerwaltung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ComputeSHA256(string password)
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
