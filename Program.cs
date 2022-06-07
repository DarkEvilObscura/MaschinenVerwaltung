using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ok;
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            System.Threading.Mutex m = new System.Threading.Mutex(true, appName, out ok);

            if (!ok)
            {
                MessageBox.Show("Es läuft bereits eine Instanz von MaschinenVerwaltung !", "MaschinenVerwaltung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            GC.KeepAlive(m);                // important!
        }
    }
}
