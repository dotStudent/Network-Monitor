using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Monitor.Forms
{
    public partial class frmHelp : Form
    {
        public frmHelp(int x, int y)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x - this.Width / 2, y - this.Height / 2);
        }
    }
}
