
using System;
using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    class Menü
    {
        public ToolStripMenuItem menuItem { get; private set; }

        public Menü(string name, string text, EventHandler onClickEvent)
        {
            this.menuItem = new ToolStripMenuItem(name);
            this.menuItem.Text = text;
        }

        public void Untermenü(string name, string text, EventHandler onClickEvent)
        {
            ToolStripMenuItem menuSubItem = new ToolStripMenuItem(name);
            menuSubItem.Text = text;
            menuSubItem.Click += onClickEvent;
            this.menuItem.DropDownItems.Add(menuSubItem);
        }
    }
}
