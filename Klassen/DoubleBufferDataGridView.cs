using System.Windows.Forms;

namespace MaschinenVerwaltung
{
    class DoubleBufferDataGridView : DataGridView
    {
        public DoubleBufferDataGridView()
        {
            
            DoubleBuffered = true;
        }

        public new bool DoubleBuffered
        {
            get
            {
                return base.DoubleBuffered;
            }
            set
            {
                base.DoubleBuffered = value;
            }
        }
    }
}
