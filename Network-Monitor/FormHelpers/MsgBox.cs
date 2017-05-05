using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Monitor.FormHelpers
{
    public partial class MsgBox : Form
    {
        //MsgBox shows new or disappeard hosts
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MsgBox(int x, int y)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x - this.Width / 2, y - this.Height / 2);
            textBox1.Text = FormsHelper.MsgBoxMessage;
            FormsHelper.MessageBoxVisible = true;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text != FormsHelper.MsgBoxMessage && FormsHelper.MsgBoxMessage != "")
            {
                textBox1.Text = FormsHelper.MsgBoxMessage;
                this.BringToFront();
                try
                {
                    //Play Sound if something changed
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Network_Monitor.Properties.Resources.Exclamation);
                    player.Play();
                }
                catch
                {

                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Close form and clear List of status changed hosts..
            FormsHelper.MessageBoxVisible = false;
            FormsHelper.MsgBoxMessage = "";
            this.Close();
        }
    }
}
